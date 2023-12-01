using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.ArrayUtils;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class OmegaList<T> : IOmegaList<T>
    {
        private const int INITIAL_CAPACITY = 100;
        private const int GROWING_FACTOR = 2;
        private T[] _internalArray;

        public int Count { get; private set; }
        public bool Resizable { get; private set; } = true;
        public int MaxCapacity { get => _internalArray.Length; }
        public T this[int index] { get => _internalArray[index]; }

        #region Constructors
        /// <summary>
        /// Initializes the list with the default size "100".
        /// <see cref="INITIAL_CAPACITY"/>
        /// </summary>
        public OmegaList()
        {
            _internalArray = new T[INITIAL_CAPACITY];
        }

        /// <summary>
        /// Initializes the list with initial size, and also with a resizable flag.
        /// </summary>
        public OmegaList(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            Resizable = resizable;
        }

        /// <summary>
        /// Transfers all the items from the collection to the list..
        /// </summary>
        public OmegaList(IOmegaCollection<T> collection, bool preserveCollectionCount = false)
        {
            Count = collection.Count;
            int capacity = OmegaList<T>.CalculateInitialCapacity(preserveCollectionCount, Count);
            _internalArray = new T[capacity];
            collection.CopyTo(_internalArray, 0);
        }

        /// <summary>
        /// Transfers all the items from the array to the list. The max capacity will be the current size of the array * GROWING_FACTOR.
        /// </summary>
        public OmegaList(T[] elements, bool preserveCollectionCount = false)
        {
            Count = elements.Length;
            int capacity = OmegaList<T>.CalculateInitialCapacity(preserveCollectionCount, Count);
            _internalArray = new T[capacity];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }
        #endregion

        /// <summary>
        /// Adds an item to collection.
        /// <para> Time: <b>O(1)</b> to add the element</para>
        /// </summary>
        /// <exception cref="Exceptions.ArgumentNullException"/>
        public void Add(T? item)
        {
            Exceptions.ArgumentNullException.CheckAgainstNull(item, nameof(item));

            if (IsFull() && !Resizable)
                throw new Exceptions.FullCollectionException();

            if (IsFull())
            {
                _internalArray = _internalArray.IncreaseCapacity(MaxCapacity * GROWING_FACTOR);
            }

            _internalArray[Count++] = item!;
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

        public bool Remove(T? item)
        {
            //Validations;
            Exceptions.ArgumentNullException.CheckAgainstNull(item, nameof(item));

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

        public void CopyTo(T[] array, int startIndex) => _internalArray.OmegaCopy(array, startIndex, Count - 1);

        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == MaxCapacity;

        public void Dispose() { Clear(); }

        public IOmegaEnumerator<T> GetEnumerator() => new OmegaArrayIterator<T>(_internalArray, Count);

        public void Swap(int source, int destination)
        {
            _internalArray.Swap(source, destination);
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();

        private static int CalculateInitialCapacity(bool preserveCollectionCount, int count) => preserveCollectionCount ? count : count * GROWING_FACTOR;
    }
}