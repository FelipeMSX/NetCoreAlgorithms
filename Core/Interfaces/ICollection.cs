
namespace Core.Interfaces
{
    public interface ICollection<T> : INumerable<T>
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
