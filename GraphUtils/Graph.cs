using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphUtils
{
    public class Graph<TNodeData>
    {
        private Node<TNodeData>[] nodes;
        private Edge<TNodeData>[,] edges;
        private List<Edge<TNodeData>> edgeList;
        private uint nodeCount = 0, maxNodes;
        private Dictionary<TNodeData, uint> nodeIndices;

        private long[] distance;
        private Node<TNodeData>[] predecessor;
        Node<TNodeData> lastPathfindingStartNode = null;

        public Graph(uint maxNodes)
        {
            this.maxNodes = maxNodes;
            nodes = new Node<TNodeData>[maxNodes];
            edges = new Edge<TNodeData>[maxNodes, maxNodes];
            edgeList = new List<Edge<TNodeData>>();
            nodeIndices = new Dictionary<TNodeData, uint>();
        }

        public Node<TNodeData> AddNode(TNodeData data)
        {
            if (nodeCount >= maxNodes) {
                throw new GraphFullException("No more room for nodes in graph");
            }

            if (nodeIndices.ContainsKey(data)) {
                throw new DuplicateNodeException(String.Format("Node with data {0} already exists", data));
            }

            Node<TNodeData> node = new Node<TNodeData>(this, data);
            nodes[nodeCount] = node;
            nodeIndices.Add(data, nodeCount);
            nodeCount++;

            lastPathfindingStartNode = null;
            return node;
        }

        internal Edge<TNodeData> AddEdge(Node<TNodeData> startNode, Node<TNodeData> endNode, int weight)
        {
            if (GetEdge(startNode, endNode) != null) {
                throw new DuplicateEdgeException("Can't create edge; nodes are already connected in this direction");
            }

            Edge<TNodeData> edge = new Edge<TNodeData>(startNode, endNode, weight);
            uint startNodeIndex = nodeIndices[startNode.Data], endNodeIndex = nodeIndices[endNode.Data];
            edges[startNodeIndex, endNodeIndex] = edge;
            edge.startIndex = startNodeIndex;
            edge.endIndex = endNodeIndex;
            edgeList.Add(edge);
            endNode.edges.Add(edge);

            lastPathfindingStartNode = null;
            return edge;
        }

        public Node<TNodeData> GetNode(TNodeData data)
        {
            uint index;
            if (nodeIndices.TryGetValue(data, out index)) {
                return nodes[index];
            } else {
                return null;
            }
        }

        public Edge<TNodeData> GetEdge(TNodeData startNode, TNodeData endNode)
        {
            return edges[nodeIndices[startNode], nodeIndices[endNode]];
        }

        public Edge<TNodeData> GetEdge(Node<TNodeData> startNode, Node<TNodeData> endNode)
        {
            return GetEdge(startNode.Data, endNode.Data);
        }

        public Node<TNodeData> this[TNodeData nodeData]
        {
            get { return GetNode(nodeData); }
        }

        public uint NodeCount
        {
            get { return nodeCount; }
        }

        public uint MaxNodes
        {
            get { return maxNodes; }
        }

        internal IEnumerable<Node<TNodeData>> GetConnectedNodes(Node<TNodeData> node)
        {
            uint nodeIndex = nodeIndices[node.Data];
            return node.edges.Select(edge => edge.EndNode);
        }

        internal IEnumerable<Node<TNodeData>> FindPath(Node<TNodeData> startNode, Node<TNodeData> endNode)
        {
            if (lastPathfindingStartNode != startNode) {
                // Dijkstra's algorithm
                // Adapted from Wikipedia <https://en.wikipedia.org/w/index.php?title=Dijkstra%27s_algorithm&oldid=648542472#Pseudocode>

                distance = new long[nodeCount];
                predecessor = new Node<TNodeData>[nodeCount];

                List<uint> unvisited = new List<uint>();

                uint startNodeIndex = nodeIndices[startNode.Data];
                distance[startNodeIndex] = 0;
                for (uint v = 0; v < nodeCount; v++) {
                    if (v != startNodeIndex) {
                        distance[v] = Int64.MaxValue;
                    }
                    predecessor[v] = null;
                    unvisited.Add(v);
                }

                while (unvisited.Count > 0) {
                    bool first = true;
                    uint u = 0;
                    foreach (uint index in unvisited) {
                        if (first) {
                            u = index;
                            first = false;
                        } else if (distance[index] < distance[u]) {
                            u = index;
                        }
                    }
                    unvisited.Remove(u);

                    foreach (Edge<TNodeData> edge in nodes[u].edges) {
                        long alt = distance[u] + edge.Weight;
                        if (alt < distance[edge.endIndex]) {
                            distance[edge.endIndex] = alt;
                            predecessor[edge.endIndex] = nodes[u];
                        }
                    }
                }

                lastPathfindingStartNode = startNode;
            }

            List<Node<TNodeData>> path = new List<Node<TNodeData>>();
            Node<TNodeData> currentNode = endNode;
            while (currentNode != startNode) {
                path.Add(currentNode);
                currentNode = predecessor[nodeIndices[currentNode.Data]];
            }
            path.Reverse();

            return path;
        }
    }
}
