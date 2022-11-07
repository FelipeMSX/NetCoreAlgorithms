using OmegaCore.Interfaces;

namespace OmegaCore.Abstracts
{
    public abstract class IOmegaIteratorBase<T> : IOmegaEnumerator<T>, IOmegaEnumerable<T>
    {
        public T? Current { get; protected set; }

        object IOmegaEnumerator.Current => Current;

        public void Dispose()
        {
            Current = default;
        }

        public abstract bool MoveNext();
        public abstract void Reset();

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            return GetEnumerator();   
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            return this;
        }
    }
}