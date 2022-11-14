namespace OmegaCore.Interfaces
{
    public interface IOmegaQueue<T>
    {
        void Queue(T item);

        T Unqueue();

        T Peek();
    }
}
