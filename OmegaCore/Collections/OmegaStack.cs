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
    public class OmegaStack<T> : IOmegaStack<T>
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
        /// Initializes the stack with the default size "100".
        /// </summary>
        public OmegaStack()
        {
            _internalArray = new T[INITIAL_CAPACITY];
        }

        /// <summary>
        /// Initializes the stack with initial size, and also with a resizable flag.
        /// </summary>
        public OmegaStack(int initialCapacity, bool resizable = true)
        {
            _internalArray = new T[initialCapacity];
            Resizable = resizable;
        }

        /// <summary>
        /// Passes an IOmegaCollection and it will transfer all the elements to the stack.
        /// </summary>
        public OmegaStack(IOmegaCollection<T> collection, bool preserveCollectionCount = false)
        {
            Count = collection.Count;
            int capacity = OmegaStack<T>.CalculateInitialCapacity(preserveCollectionCount, Count);
            _internalArray = new T[capacity];
            collection.CopyTo(_internalArray, 0);
        }

        /// <summary>
        /// Passes an array and it will transfer all the elements to the stack.
        /// </summary>
        public OmegaStack(T[] elements, bool preserveCollectionCount = false)
        {
            Count = elements.Length;
            int capacity = OmegaStack<T>.CalculateInitialCapacity(preserveCollectionCount, Count);
            _internalArray = new T[capacity];
            elements.OmegaCopy(_internalArray, 0, Count - 1);
        }
        #endregion

        public void Push(T? item)
        {
            //Validations
            Exceptions.ArgumentNullException.CheckAgainstNull(item, nameof(item));
   
            if (IsFull() && !Resizable)
                throw new FullCollectionException();
            else if (IsFull())
            {
                _internalArray = _internalArray.IncreaseCapacity(MaxCapacity * GROWING_FACTOR);
            }

            _internalArray[Count++] = item!;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();

            Count--;
            T item = _internalArray[Count];
            _internalArray[Count] = default!;

            return item;
        }

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

        /// <summary>
        /// Copies all the elements from the stack to the array. the result array will be the internal representation of the stack.
        /// </summary>
        public void CopyTo(T[] array, int startIndex)
        {
            _internalArray.OmegaCopy(array, startIndex, Count - 1);
            array.Reverse();
        }
        
        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == MaxCapacity;

        public void Dispose() => Clear();

        public IOmegaEnumerator<T> GetEnumerator() => new OmegaArrayIterator<T>(_internalArray, Count, true);

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();

        private static int CalculateInitialCapacity(bool preserveCollectionCount, int count) => preserveCollectionCount ? count : count * GROWING_FACTOR;

    }
}