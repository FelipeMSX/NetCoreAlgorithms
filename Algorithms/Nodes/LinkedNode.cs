using Algorithms.Abstracts;

namespace Algorithms.Nodes
{
    /// <summary>
    /// Represents a single node with just a pointer.
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    /// <typeparam name="E"></typeparam>
    public class LinkedNode<T> : NodeBase<T>
    {
        /// <summary>
        /// The object that can be used as a pointer.
        /// </summary>
        public LinkedNode<T> Next { get; set; }

        public LinkedNode() : base() { }

        public LinkedNode(T obj) : base(obj) { }

        public bool HasNext() => Next != null;

        public override void Invalidate()
        {
            base.Invalidate();
            Next = null;
        }
    }
}
