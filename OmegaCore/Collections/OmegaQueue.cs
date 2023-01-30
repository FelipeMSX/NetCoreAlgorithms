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
        private int _capacity;

        public int Count { get; private set; }

        public bool Resizable { get; private set; } = true;


        public OmegaQueue()
        {
            _internalArray = new T[INITIAL_CAPACITY];
            _capacity = INITIAL_CAPACITY;
        }

        public OmegaQueue(int initialCapacity, bool resizable)
        {
            _internalArray = new T[initialCapacity];
            _capacity = initialCapacity;
            Resizable = resizable;
        }

        public OmegaQueue(IOmegaCollection<T> collection)
        {
            _internalArray = new T[collection.Count];

            foreach (T item in collection)
                _internalArray[Count++] = item;
        }

        //TODO - Does it need to create a new copy?
        public OmegaQueue(T[] elements)
        {
            _internalArray = new T[elements.Length];
            elements.OmegaCopy(_internalArray);
            Count = elements.Length;
        }

        /// <summary>
        /// Adds a new item in the end of the queue.
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
                _capacity *= GROWING_FACTOR;
                _internalArray = _internalArray.IncreaseCapacity(_capacity);
            }

            _internalArray[Count++] = obj;
        }

        /// <summary>
        /// Removes the first item to comes out. All items must be shifted in one position.
        /// It takes O(N) the queue the collection.
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
        private bool IsFull() => Count == _capacity;
    }
}