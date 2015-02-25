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

        public Edge<TData> ConnectToNode(Node<TData> otherNode)
        {
            if (otherNode.graph != graph) {
                throw new IncorrectGraphException("Cannot connect two nodes in different graphs.");
            }

            return graph.AddEdge(this, otherNode);
        }
    }
}
