using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphUtils
{
    [Serializable]
    public class GraphException : Exception
    {
        public GraphException() { }
        public GraphException(string message) : base(message) { }
        public GraphException(string message, Exception inner) : base(message, inner) { }
        protected GraphException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class GraphFullException : GraphException
    {
        public GraphFullException() { }
        public GraphFullException(string message) : base(message) { }
        public GraphFullException(string message, Exception inner) : base(message, inner) { }
        protected GraphFullException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class DuplicateNodeException : GraphException
    {
        public DuplicateNodeException() { }
        public DuplicateNodeException(string message) : base(message) { }
        public DuplicateNodeException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateNodeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class DuplicateEdgeException : GraphException
    {
        public DuplicateEdgeException() { }
        public DuplicateEdgeException(string message) : base(message) { }
        public DuplicateEdgeException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateEdgeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class IncorrectGraphException : GraphException
    {
        public IncorrectGraphException() { }
        public IncorrectGraphException(string message) : base(message) { }
        public IncorrectGraphException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectGraphException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class NodeNotFoundException : GraphException
    {
        public NodeNotFoundException() { }
        public NodeNotFoundException(string message) : base(message) { }
        public NodeNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected NodeNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class NegativeWeightCycleException : GraphException
    {
        public NegativeWeightCycleException() { }
        public NegativeWeightCycleException(string message) : base(message) { }
        public NegativeWeightCycleException(string message, Exception inner) : base(message, inner) { }
        protected NegativeWeightCycleException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
