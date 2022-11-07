using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaList<T> : IOmegaList<T>
    {
        private const int INITIAL_CAPACITY = 100;
        private readonly T[] _internalArray;
        public T this[int index] { get => _internalArray[index]; set => _internalArray[index] = value; }

        public int Count {get; private set; }   


        //TODO - Does it to create a new copy?
        public OmegaList(T[] internalArray)
        {
            _internalArray = internalArray;
        }

        public OmegaList(int capacity = INITIAL_CAPACITY)
        {
            _internalArray = new T[capacity];
        }

        public void Add(T item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            _internalArray[Count++] = item;
        }

        public void Clear()
        {
        }

        public T First()
        {
            return _internalArray[0];
        }

        public T Last()
        {
            return _internalArray[Count -1];
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Retrieve(T item)
        {
            throw new System.NotImplementedException();
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            return new OmegaListIterator<T>(this);
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
        }
    }
}
