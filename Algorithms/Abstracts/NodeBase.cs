using Algorithms.Interfaces;

namespace Algorithms.Abstracts
{
    /// <summary>
    /// Represents a object that can hold data for creating some nodes.
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    public abstract class NodeBase<T> : IInvalidateObject
    {
        public T Value { get; set; }

        protected NodeBase(T value) => Value = value;

        protected NodeBase() { }

        public virtual void Invalidate() { }
    }
}
