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
        internal uint startIndex, endIndex;
        private int weight;

        internal Edge(Node<TNodeData> startNode, Node<TNodeData> endNode, int weight)
        {
            start = startNode;
            end = endNode;
            this.weight = weight;
        }

        public Node<TNodeData> StartNode
        {
            get { return start; }
        }

        public Node<TNodeData> EndNode
        {
            get { return end; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
