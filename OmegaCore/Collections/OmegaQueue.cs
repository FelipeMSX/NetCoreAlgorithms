using Algorithms.Exceptions;
using OmegaCore.Exceptions;
using OmegaCore.Helpers;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaQueue<T> : IOmegaSimpleCollection<T>, IOmegaQueue<T>
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

        public OmegaQueue(int initialCapacity,bool resizable)
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
            elements.CopyTo(_internalArray, 0);
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
                _internalArray = ArrayHelpers.IncreaseCapacity(_internalArray, _capacity);
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

            //Shifts the itens.
            //for (int i = 0; i < Count; i++)
            //    _internalArray[i] = _internalArray[i + 1];
            /*
             * 
             * init = 0; end = 3; lenght = 2; count = 3
             *  n
             *  i  
             *  
             *  i = 0;
             *  i  n
             *  0, 1, 2
             *  1, 2, 3
             *  
             *  -------
             *              
             *  i = 1;
             *  i < 2
             *  
             *  0, 1, 2
             *  [1, 2, 3]
             *  
             *  i = 0
             *  n = 2
             * 
             */

            ArrayHelpers.Shift(_internalArray, 0, Count);

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
            for (int i = 0; i < Count; i++)
                _internalArray[i] = default;

            Count = 0;
        }

        public void CopyTo(T[] array, int lenght)
        {
            for (int i = 0; i < lenght; i++)
                array[i] = _internalArray[i];
        }

        public void Dispose()
        {
            for (int i = 0; i < Count; i++)
                _internalArray[i] = default;

            Count = 0;
            _internalArray = null;
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            return new OmegaArrayIterator<T>(_internalArray);
        }

        private bool IsEmpty() => Count == 0;
        private bool IsFull() => Count == _capacity;

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
