using Core.Interfaces;

namespace Core.Abstracts
{
    public abstract class Iterator<T> : INumerator<T>, INumerable<T>
    {
        public T Current { get; protected set; }

        object INumerator.Current => Current;

        INumerator INumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public INumerator<T> GetEnumerator()
        {
            return this;
        }

        public abstract bool MoveNext();
        public abstract void Reset();
    }
}