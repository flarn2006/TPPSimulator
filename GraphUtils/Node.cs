using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphUtils
{
    public class Node<TData>
    {
        private Graph<TData> graph;
        private TData data;
        internal int traversalID = -1;
        
        internal Node(Graph<TData> graph, TData data)
        {
            this.graph = graph;
            this.data = data;
        }

        public Graph<TData> Graph
        {
            get { return graph; }
        }

        public TData Data
        {
            get { return data; }
        }

        public IEnumerable<Node<TData>> GetConnectedNodes()
        {
            return graph.GetConnectedNodes(this);
        }

        public Edge<TData> ConnectToNode(Node<TData> endNode, int edgeWeight = 1)
        {
            if (endNode.graph != graph) {
                throw new IncorrectGraphException("Cannot connect two nodes in different graphs.");
            }

            return graph.AddEdge(this, endNode, edgeWeight);
        }

        public Edge<TData> ConnectToNode(TData endNodeData, int edgeWeight = 1)
        {
            Node<TData> endNode = graph.GetNode(endNodeData);

            if (endNode == null) {
                throw new NodeNotFoundException(String.Format("This node's graph does not contain a node with data \"{0}\".", endNodeData));
            }

            return graph.AddEdge(this, endNode, edgeWeight);
        }

        public IEnumerable<Node<TData>> FindPath(Node<TData> endNode)
        {
            if (endNode.graph != graph) {
                throw new IncorrectGraphException("Cannot find a path between two nodes in different graphs.");
            }

            return graph.FindPath(this, endNode);
        }

        public IEnumerable<Node<TData>> FindPath(TData endNodeData)
        {
            Node<TData> endNode = graph.GetNode(endNodeData);

            if (endNode == null) {
                throw new NodeNotFoundException(String.Format("This node's graph does not contain a node with data \"{0}\".", endNodeData));
            }

            return graph.FindPath(this, endNode);
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
