namespace OmegaCore.Interfaces
{
    public interface IOmegaQueue<T> : IOmegaSimpleCollection<T>
    {
        T this[int index] { get; }

        public int MaxCapacity { get; }

        void Queue(T item);

        T Unqueue();

        T Peek();
    }
}