using Algorithms.Exceptions;
using OmegaCore.Exceptions;
using OmegaCore.Extensions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public  class OmegaList<T> : IOmegaList<T>
    {
        private const int INITIAL_CAPACITY = 100;
        private const int GROWING_FACTOR = 2;

        private readonly T[] _internalArray;

        public T this[int index] { get => _internalArray[index]; }

        public int Count { get; private set; }

        /// <summary>
        /// Transfers all the items from the collection to the list.The max capacity will be the current size of the collection * GROWING_FACTOR.
        /// </summary>
        public OmegaList(IOmegaCollection<T> collection)
        {
            Count = collection.Count;
            _internalArray = new T[Count * GROWING_FACTOR];
            collection.CopyTo(_internalArray, 0);
        }

        /// <summary>
        /// Transfers all the items from the array to the list. The max capacity will be the current size of the array * GROWING_FACTOR.
        /// </summary>
        public OmegaList(T[] elements)
        {
            Count = elements.Length;
            _internalArray = new T[Count * GROWING_FACTOR];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }

        /// <summary>
        /// Initializes the collection with a specified capacity.
        /// </summary>
        public OmegaList(int capacity = INITIAL_CAPACITY)
        {
            _internalArray = new T[capacity];
        }

        /// <summary>
        /// Adds an item to list and it takes O(1) to add the element.
        /// </summary>
        /// <exception cref="NullParameterException"/>
        public void Add(T item)
        {
            if (item == null)
                throw new NullParameterException(nameof(item));

            _internalArray[Count++] = item;
        }

        /// <summary>
        /// Clears the list making all positions in the array to be the default value. It does not disable the queue.
        /// </summary>
        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        /// <summary>
        /// Gets the first element in the list.
        /// </summary>
        /// <exception cref="EmptyCollectionException"/>
        public T First()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[0];
        }

        /// <summary>
        /// Gets the last element in the list.
        /// </summary>
        /// <exception cref="EmptyCollectionException"/>
        public T Last()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[Count - 1];
        }

        /// <summary>
        /// Searches for the item in the collection, and after that it is going to be removed.
        /// </summary>
        /// <exception cref="NullParameterException"></exception>
        public bool Remove(T item)
        {
            if (item == null)
                throw new NullParameterException(nameof(item));

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

        /// <summary>
        /// Copies all the elements from the list to the array.
        /// </summary>
        public void CopyTo(T[] array, int startIndex) => _internalArray.OmegaCopy(array, startIndex, Count - 1);

        public bool IsEmpty() => Count == 0;

        //TODO - I need to find out a way to make the collection usable
        /// <summary>
        /// Invalidates the queue, after that any operation should be avoid. 
        /// </summary>
        public void Dispose() { Clear(); }

        public IOmegaEnumerator<T> GetEnumerator() => new OmegaListIterator<T>(this);

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();

    }
}