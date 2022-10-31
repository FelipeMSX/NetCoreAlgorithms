
namespace OmegaCore.Interfaces
{
    public interface IOmegaCollection<T> : IOmegaNumerable<T>
    {
        int Count { get; }
        void Add(T item);
        bool Remove(T item);
        T Retrieve(T item);
        T First();
        T Last();
        void Clear();
    }
}
