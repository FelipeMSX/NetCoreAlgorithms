
namespace Algorithms.Interfaces
{
    public interface IInteracbleCollection<T> : IDefaultCollection<T>
    {
        void AddLast(T item);
        bool RemoveFirst();
        bool RemoveLast();
    }
}
