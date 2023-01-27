using OmegaCore.Exceptions;
using OmegaCore.Extensions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaList<T> : IOmegaList<T>
    {
        private const int INITIAL_CAPACITY = 100;
        private readonly T[] _internalArray;

        public T this[int index] { get => _internalArray[index]; set => _internalArray[index] = value; }

        public int Count { get; private set; }

        public OmegaList(IOmegaCollection<T> collection)
        {
            _internalArray = new T[collection.Count];

            foreach (T item in collection)
                _internalArray[Count++] = item;

        }

        public OmegaList(T[] elements)
        {
            _internalArray = new T[elements.Length];
            elements.OmegaCopy(_internalArray);
            Count = elements.Length;
        }

        public OmegaList(int capacity = INITIAL_CAPACITY)
        {
            _internalArray = new T[capacity];
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _internalArray[Count++] = item;
        }

        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        public T First()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[0];
        }

        public T Last()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[Count - 1];
        }

        public bool IsEmpty() => Count == 0;

        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (IsEmpty())
                return false;

            int indexOfItem = _internalArray.IndexOf(item);

            if (indexOfItem >= 0)
            {
                _internalArray.Shift(indexOfItem);
                Count--;
                return true;
            }

            return false;
        }

        public T Retrieve(T item)
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            int indexOfItem = _internalArray.IndexOf(item);

            if (indexOfItem >= 0)
                return _internalArray[indexOfItem];

            throw new ElementNotFoundException();
        }

        public IOmegaEnumerator<T> GetEnumerator() => new OmegaListIterator<T>(this);

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Dispose() => Clear();

        public void CopyTo(T[] array, int lenght) => array.OmegaCopy(array);
    }
}
