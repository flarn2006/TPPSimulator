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
        private uint nodeCount = 0, maxNodes;
        private Dictionary<TNodeData, uint> nodeIndices;
        private int traversalID = -1;

        public Graph(uint maxNodes)
        {
            this.maxNodes = maxNodes;
            nodes = new Node<TNodeData>[maxNodes];
            edges = new Edge<TNodeData>[maxNodes, maxNodes];
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

            return node;
        }

        internal Edge<TNodeData> AddEdge(Node<TNodeData> startNode, Node<TNodeData> endNode, int weight)
        {
            if (GetEdge(startNode, endNode) != null) {
                throw new DuplicateEdgeException("Can't create edge; nodes are already connected in this direction");
            }

            Edge<TNodeData> edge = new Edge<TNodeData>(startNode, endNode, weight);
            edges[nodeIndices[startNode.Data], nodeIndices[endNode.Data]] = edge;

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

        internal IEnumerable<Node<TNodeData>> FindPath(Node<TNodeData> startNode, Node<TNodeData> endNode, bool newTraversal = true)
        {
            if (newTraversal) traversalID++;

            if (startNode == endNode) {
                yield return startNode;
            } else {
                yield return startNode;
                foreach (Node<TNodeData> node in startNode.GetConnectedNodes()) {
                    if (node.traversalID != traversalID) {
                        node.traversalID = traversalID;
                        foreach (Node<TNodeData> pathNode in FindPath(node, endNode, false)) {
                            yield return pathNode;
                        }
                    }
                }
            }
        }
    }
}
