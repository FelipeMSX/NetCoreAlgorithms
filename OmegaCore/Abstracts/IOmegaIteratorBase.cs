using OmegaCore.Interfaces;

namespace OmegaCore.Abstracts
{
    public abstract class IOmegaIteratorBase<T> : IOmegaEnumerator<T>, IOmegaEnumerable<T>
    {
        public T Current { get; protected set; }

        object IOmegaEnumerator.Current => Current!;

        public abstract bool MoveNext();
        public abstract void Reset();
        public abstract void Dispose();

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();   
        
        public IOmegaEnumerator<T> GetEnumerator() =>  this;

    }
}