using Algorithms.Exceptions;
using OmegaCore.Exceptions;
using OmegaCore.Extensions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaStack<T> : IOmegaStack<T>
    {
        private const int INITIAL_CAPACITY = 100;
        private const int GROWING_FACTOR = 2;
        private T[] _internalArray;

        public int Count { get; private set; }

        public bool Resizable { get; private set; } = true;

        public int MaxCapacity { get; private set; }

        public T this[int index] { get => _internalArray[index]; }

        public OmegaStack()
        {
            _internalArray = new T[INITIAL_CAPACITY];
            MaxCapacity = INITIAL_CAPACITY;
        }

        public OmegaStack(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            MaxCapacity = initialCapacity;
            Resizable = resizable;
        }

        public OmegaStack(IOmegaCollection<T> collection)
        {
            Count = collection.Count;
            MaxCapacity = Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            collection.CopyTo(_internalArray, 0);
        }

        public OmegaStack(T[] elements)
        {
            Count = elements.Length;
            MaxCapacity = Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }

        /// <summary>
        /// Adds a new item in the Stack.
        /// It takes O(1).
        /// </summary>
        public void Push(T obj)
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
        /// Removes the first item to comes out.
        /// It takes O(1).
        /// </summary>
        public T Pop()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            Count--;
            T item = _internalArray[Count];
            _internalArray[Count] = default!;

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

            return _internalArray[Count - 1];
        }


        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        public void CopyTo(T[] array, int startIndex) => array.OmegaCopy(array, startIndex, Count - 1);
        
        public void Dispose() => Clear();
        public IOmegaEnumerator<T> GetEnumerator() => new OmegaArrayIterator<T>(_internalArray, Count, true);
        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();
        public bool IsEmpty() => Count == 0;
        public bool IsFull() => Count == MaxCapacity;
    }
}