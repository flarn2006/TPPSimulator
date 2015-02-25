using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphUtils
{
    public class Edge<TNodeData>
    {
        private Node<TNodeData> start, end;

        internal Edge(Node<TNodeData> startNode, Node<TNodeData> endNode)
        {
            start = startNode;
            end = endNode;
        }

        public Node<TNodeData> StartNode
        {
            get { return start; }
        }

        public Node<TNodeData> EndNode
        {
            get { return end; }
        }
    }
}
