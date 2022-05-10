
namespace Core.Interfaces
{
    public interface ICollection<T> : INumerator<T>, INumerable
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
