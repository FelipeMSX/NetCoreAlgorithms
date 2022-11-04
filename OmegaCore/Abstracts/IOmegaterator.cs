using OmegaCore.Interfaces;

namespace OmegaCore.Abstracts
{
    public abstract class IOmegaterator<T> : IOmegaNumerator<T>, IOmegaNumerator
    {
        public T Current { get; protected set; }

        object IOmegaNumerator.Current
        {
            get
            {
                if (Current == null)
                    throw new NullReferenceException();

                return Current;
            }
        }

        public void Dispose()
        {
            
        }

        public abstract bool MoveNext();
        public abstract void Reset();
    }
}