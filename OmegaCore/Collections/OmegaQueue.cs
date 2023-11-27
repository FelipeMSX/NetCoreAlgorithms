using Algorithms.Exceptions;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.Extensions;
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

        public int MaxCapacity { get; private set; }

        public T this[int index] { get => _internalArray[index]; }

        /// <summary>
        /// Initializes the queue with the default size "100".
        /// </summary>
        public OmegaQueue()
        {
            _internalArray = new T[INITIAL_CAPACITY];
            MaxCapacity = INITIAL_CAPACITY;
        }

        /// <summary>
        /// Initializes the queue with initial size, and also with a resizable flag.
        /// </summary>
        public OmegaQueue(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            MaxCapacity = initialCapacity;
            Resizable = resizable;
        }

        /// <summary>
        /// Passes an IOmegaCollection and it will transfer all the elements to the queue.
        /// </summary>
        public OmegaQueue(IOmegaCollection<T> collection)
        {
            Count = collection.Count;
            MaxCapacity = Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            collection.CopyTo(_internalArray, 0);
        }

        /// <summary>
        /// Passes an array and it will transfer all the elements to the queue.
        /// </summary>
        public OmegaQueue(T[] elements)
        {
            Count = elements.Length;
            MaxCapacity = Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }

        /// <summary>
        /// Adds a new item in the queue. If the collection is resizable doubles its size automatically.
        /// </summary>
        /// <exception cref="NullParameterException"/>
        /// <exception cref="FullCollectionException"/>
        public void Queue(T obj)
        {
            //Validations
            if (obj == null)
                throw new NullParameterException();
            else if (IsFull() && !Resizable)
                throw new FullCollectionException();
            else if (IsFull())
            {
                MaxCapacity *= GROWING_FACTOR;
                _internalArray = _internalArray.IncreaseCapacity(MaxCapacity);
            }

            _internalArray[Count++] = obj;
        }

        /// <summary>
        /// Removes the first item in the beginning of the array. All items must be shifted in one position.
        /// It takes O(N).
        /// </summary>
        /// <exception cref="EmptyCollectionException"/>
        public T Unqueue()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            T item = _internalArray[0];
            _internalArray.Shift(0, --Count);

            return item;
        }

        /// <summary>
        /// Retrieves the first item from the collection, but it remains in the collection.
        /// Takes O(1) to get the element.
        /// </summary>
        /// <exception cref="EmptyCollectionException"/>
        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[0];
        }

        /// <summary>
        /// Clears the queue making all positions in the array to be the default value. It does not disable the queue.
        /// </summary>
        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        /// <summary>
        /// Copies all the elements from the queue to the array.
        /// </summary>
        public void CopyTo(T[] array, int startIndex) => array.OmegaCopy(array, startIndex, Count - 1);

        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == MaxCapacity;

        //TODO - I need to find out a way to make the collection usable
        /// <summary>
        /// Invalidates the queue, and after that any operation should be avoid. 
        /// </summary>
        public void Dispose() => Clear();
        public IOmegaEnumerator<T> GetEnumerator() => new OmegaArrayIterator<T>(_internalArray, Count);
        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();
    }
}