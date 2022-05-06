using Core.Interfaces;

namespace Core.Abstracts
{
    public abstract class Iterator<T> : IEnumeratorX<T>, IEnumerableX<T>
    {
        public T Current { get; protected set; }

        object IEnumeratorX.Current => Current;

        IEnumeratorX IEnumerableX.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumeratorX<T> GetEnumerator()
        {
            return this;
        }

        public abstract bool MoveNext();
        public abstract void Reset();
    }
}