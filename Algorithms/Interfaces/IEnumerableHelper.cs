namespace Algorithms.Interfaces
{
    public interface IEnumerableHelper<T>
    {
        void CopyTo(T[] array, int arrayIndex);
        bool Contains(T item);
    }
}
