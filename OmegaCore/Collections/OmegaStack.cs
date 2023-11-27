using Algorithms.Exceptions;
using OmegaCore.Collections.Interfaces;
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

        /// <summary>
        /// Initializes the stack with the default size "100".
        /// </summary>
        public OmegaStack()
        {
            _internalArray = new T[INITIAL_CAPACITY];
            MaxCapacity = INITIAL_CAPACITY;
        }

        /// <summary>
        /// Initializes the stack with initial size, and also with a resizable flag.
        /// </summary>
        public OmegaStack(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            MaxCapacity = initialCapacity;
            Resizable = resizable;
        }

        /// <summary>
        /// Passes an IOmegaCollection and it will transfer all the elements to the stack.
        /// </summary>
        public OmegaStack(IOmegaCollection<T> collection)
        {
            Count = collection.Count;
            MaxCapacity = Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            collection.CopyTo(_internalArray, 0);
        }

        /// <summary>
        /// Passes an array and it will transfer all the elements to the stack.
        /// </summary>
        public OmegaStack(T[] elements)
        {
            Count = elements.Length;
            MaxCapacity = Count * GROWING_FACTOR;
            _internalArray = new T[MaxCapacity];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }

        /// <summary>
        /// Adds a new item in the stack.
        /// It takes O(1).
        /// </summary>
        /// <exception cref="NullParameterException"></exception>
        /// <exception cref="FullCollectionException"></exception>
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
        /// Removes the first item to comes out in the stack.
        /// It takes O(1).
        /// </summary>
        /// <exception cref="EmptyCollectionException"></exception>
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
        /// <exception cref="EmptyCollectionException"></exception>
        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            return _internalArray[Count - 1];
        }

        /// <summary>
        /// Clears the queue making all positions in the array to be the default value. It does not disable the stack.
        /// </summary>
        public void Clear()
        {
            _internalArray.Clear(Count);
            Count = 0;
        }

        /// <summary>
        /// Copies all the elements from the stack to the array. the result array will be the internal representation of the stack.
        /// </summary>
        public void CopyTo(T[] array, int startIndex) => array.OmegaCopy(array, startIndex, Count - 1);
        
        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == MaxCapacity;

        //TODO - I need to find out a way to make the collection usable
        /// <summary>
        /// Invalidates the queue, and after that any operation should be avoid. 
        /// </summary>
        public void Dispose() => Clear();
        public IOmegaEnumerator<T> GetEnumerator() => new OmegaArrayIterator<T>(_internalArray, Count, true);
        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();
    }
}