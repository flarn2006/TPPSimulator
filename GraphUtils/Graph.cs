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
            edges[nodeIndices[startNode.Data], nodeIndices[endNode.Data]] = edge;
            edgeList.Add(edge);

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
            for (int i = 0; i < nodeCount; i++) {
                Edge<TNodeData> edge = edges[nodeIndex, i];
                if (edge != null) {
                    yield return edge.EndNode;
                }
            }
        }

        internal IEnumerable<Node<TNodeData>> FindPath(Node<TNodeData> startNode, Node<TNodeData> endNode)
        {
            if (lastPathfindingStartNode != startNode) {
                // Bellman-Ford algorithm
                // Adapted from Wikipedia <https://en.wikipedia.org/w/index.php?title=Bellman%E2%80%93Ford_algorithm&oldid=642360089#Algorithm>

                distance = new long[nodeCount];
                predecessor = new Node<TNodeData>[nodeCount];

                uint startNodeIndex = nodeIndices[startNode.Data];
                for (uint v = 0; v < nodeCount; v++) {
                    distance[v] = (v == startNodeIndex) ? 0 : Int64.MaxValue;
                    predecessor[v] = null;
                }

                for (uint i = 0; i < nodeCount; i++) {
                    foreach (Edge<TNodeData> edge in edgeList) {
                        uint u = nodeIndices[edge.StartNode.Data];
                        uint v = nodeIndices[edge.EndNode.Data];
                        if (distance[u] + edge.Weight < distance[v]) {
                            distance[v] = distance[u] + edge.Weight;
                            predecessor[v] = nodes[u];
                        }
                    }
                }

                foreach (Edge<TNodeData> edge in edgeList) {
                    if (distance[nodeIndices[edge.StartNode.Data]] + edge.Weight < distance[nodeIndices[edge.EndNode.Data]]) {
                        throw new NegativeWeightCycleException("Graph contains a negative-weight cycle");
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
