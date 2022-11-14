
namespace OmegaCore.Interfaces
{
    public interface IOmegaSimpleCollection<T> : IOmegaEnumerable<T>, IOmegaDisposable
    {
        int Count { get; }
        void Clear();
        void CopyTo(T[] array, int lenght);
    }
}
