namespace OmegaCore.Interfaces
{
    public interface IOmegaQueue<T> : IOmegaSimpleCollection<T>
    {
        void Queue(T item);

        T Unqueue();

        T Peek();
    }
}