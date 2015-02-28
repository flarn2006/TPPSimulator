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

        public void BuildPathfindingData(Node<TNodeData> startNode)
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

                for (uint i = 1; i < nodeCount; i++) {
                    foreach (Edge<TNodeData> edge in edgeList) {
                        uint u = edge.startIndex, v = edge.endIndex;
                        if (distance[u] + edge.Weight < distance[v]) {
                            if (distance[u] < Int64.MaxValue) {
                                distance[v] = distance[u] + edge.Weight;
                                predecessor[v] = nodes[u];
                            }
                        }
                    }
                }

                /*foreach (Edge<TNodeData> edge in edgeList) {
                    if (distance[edge.startIndex] + edge.Weight < distance[edge.endIndex]) {
                        throw new NegativeWeightCycleException("Graph contains a negative-weight cycle");
                    }
                }*/

                lastPathfindingStartNode = startNode;
            }
        }

        internal IEnumerable<Node<TNodeData>> FindPath(Node<TNodeData> startNode, Node<TNodeData> endNode)
        {
            BuildPathfindingData(startNode);

            Node<TNodeData> currentNode = endNode;
            int i = 0;
            while (currentNode != startNode && i++ < 1000) {
                yield return currentNode;
                currentNode = predecessor[nodeIndices[currentNode.Data]];
            }
        }

        internal Node<TNodeData> GetPathPredecessor(Node<TNodeData> node)
        {
            return predecessor[nodeIndices[node.Data]];
        }

        internal long GetPathDistance(Node<TNodeData> node)
        {
            return distance[nodeIndices[node.Data]];
        }

        public void ExportTGF(System.IO.StreamWriter streamWriter)
        {
            for (int i = 0; i < nodeCount; i++) {
                streamWriter.WriteLine(String.Format("{0} {1}", i, nodes[i].Data));
            }

            streamWriter.WriteLine("#");

            foreach (Edge<TNodeData> edge in edgeList) {
                streamWriter.WriteLine(String.Format("{0} {1} weight:{2}", edge.startIndex, edge.endIndex, edge.Weight));
            }
        }

        public IEnumerable<Node<TNodeData>> AllNodes
        {
            get { return nodes; }
        }

        public IEnumerable<Edge<TNodeData>> AllEdges
        {
            get { return edgeList; }
        }
    }
}
