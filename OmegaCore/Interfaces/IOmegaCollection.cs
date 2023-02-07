namespace OmegaCore.Interfaces
{
    public interface IOmegaCollection<T> : IOmegaSimpleCollection<T>
    {
        void Add(T item);
        bool Remove(T item);
        T First();
        T Last();
        bool IsEmpty();
    }
}