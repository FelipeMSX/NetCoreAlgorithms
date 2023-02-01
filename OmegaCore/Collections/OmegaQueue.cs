using Algorithms.Exceptions;
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

        public OmegaQueue()
        {
            _internalArray = new T[INITIAL_CAPACITY];
            MaxCapacity = INITIAL_CAPACITY;
        }

        public OmegaQueue(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            MaxCapacity = initialCapacity;
            Resizable = resizable;
        }

        public OmegaQueue(IOmegaCollection<T> collection)
        {
            MaxCapacity = collection.Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            collection.CopyTo(_internalArray, 0);
            Count = collection.Count;
        }

        public OmegaQueue(T[] elements)
        {
            MaxCapacity = elements.Length * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            elements.OmegaCopy(_internalArray);
            Count = elements.Length;
        }

        /// <summary>
        /// Adds a new item in the queue.
        /// </summary>
        public void Queue(T obj)
        {
            //Validações
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
        /// Removes the first item to comes out. All items must be shifted in one position.
        /// It takes O(N).
        /// </summary>
        public T Unqueue()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            T item = _internalArray[0];
            _internalArray.Shift(0, Count);
            Count--;

            return item;
        }

        /// <summary>
        /// Retrieves the first item from the collection, but it remains in the collection.
        /// Takes O(1) to get the element.
        /// </summary>
        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[0];
        }


        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        public void CopyTo(T[] array, int lenght)
        {
            array.OmegaCopy(array);
        }

        public void Dispose()
        {
            Clear();
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            return new OmegaArrayIterator<T>(_internalArray);
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsEmpty() => Count == 0;
        private bool IsFull() => Count == MaxCapacity;
    }
}