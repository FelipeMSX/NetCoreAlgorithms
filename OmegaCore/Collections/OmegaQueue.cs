using OmegaCore.Collections.Interfaces;
using OmegaCore.ArrayUtils;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaQueue<T> : IOmegaQueue<T>
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
        /// Initializes the queue with the default size "100".
        /// <see cref="INITIAL_CAPACITY"/>
        /// </summary>
        public OmegaQueue()
        {
            _internalArray = new T[INITIAL_CAPACITY];
        }

        /// <summary>
        /// Initializes the queue with initial size, and also with a resizable flag.
        /// </summary>
        public OmegaQueue(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            Resizable = resizable;
        }

        /// <summary>
        /// Passes an IOmegaCollection and it will transfer all the elements to the queue.
        /// </summary>
        public OmegaQueue(IOmegaCollection<T> collection, bool preserveCollectionCount = false)
        {
            Count = collection.Count;
            int capacity = OmegaQueue<T>.CalculateInitialCapacity(preserveCollectionCount, Count);
            _internalArray = new T[capacity];
            collection.CopyTo(_internalArray, 0);
        }

        /// <summary>
        /// Passes an array and it will transfer all the elements to the queue.
        /// </summary>
        public OmegaQueue(T[] elements, bool preserveCollectionCount = false)
        {
            Count = elements.Length;
            int capacity = OmegaQueue<T>.CalculateInitialCapacity(preserveCollectionCount, Count);
            _internalArray = new T[capacity];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }

        #endregion


        public void Queue(T? item)
        {
            //Validations
            Exceptions.ArgumentNullException.CheckAgainstNull(item, nameof(item));
     
            if (IsFull() && !Resizable)
                throw new Exceptions.FullCollectionException();

            if (IsFull())
            {
                _internalArray = _internalArray.IncreaseCapacity(MaxCapacity * GROWING_FACTOR);
            }

            _internalArray[Count++] = item!;
        }

        public T Unqueue()
        {
            if (IsEmpty())
                throw new Exceptions.EmptyCollectionException();

            T item = _internalArray[0];
            _internalArray.Shift(0, --Count);

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exceptions.EmptyCollectionException();

            return _internalArray[0];
        }

        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        /// <summary>
        /// Copies all the elements from the queue to the array. The first element is the first to be popped out.
        /// </summary>
        public void CopyTo(T[] array, int startIndex) => _internalArray.OmegaCopy(array, startIndex, Count - 1);

        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == MaxCapacity;

        public void Dispose()
        {
            Clear();
        }

        public IOmegaEnumerator<T> GetEnumerator() => new OmegaArrayIterator<T>(_internalArray, Count);

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();

        private static int CalculateInitialCapacity(bool preserveCollectionCount, int count) => preserveCollectionCount ? count : count * GROWING_FACTOR;
    }
}