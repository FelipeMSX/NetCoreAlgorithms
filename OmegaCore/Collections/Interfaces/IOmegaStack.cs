namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaStack<T> : IOmegaSimpleCollection<T>
    {
        T this[int index] { get; }

        public int MaxCapacity { get; }

        void Push(T item);

        T Pop();

        T Peek();

        bool IsFull();
    }
}