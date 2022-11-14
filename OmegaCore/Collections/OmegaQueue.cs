using OmegaCore.Exceptions;
using OmegaCore.Helpers;
using OmegaCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaCore.Collections
{
    public class OmegaQueue<T> : IOmegaSimpleCollection<T>, IOmegaQueue<T>
    {

        private const int INITIAL_CAPACITY = 100;
        private const int GROWING_FACTOR = 2;
        private T[] _internalArray;

        public int Count { get; private set; }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int lenght)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a new item in the ending of the queue.
        /// </summary>
        public void Queue(T obj)
        {
            ////Validações
            //if (obj == null)
            //    throw new NullObjectException();
            //else
            //if (Full() && !Resizable)
            //    throw new FullCollectionException();
            //else
            //if (Full())
            //{
            //    _internalArray = ArrayHelpers.IncreaseCapacity(_internalArray, _internalArray.Length * GROWING_FACTOR);
            //}
            //_internalArray[Count++] = obj;
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

            Count--;
            //Shifts the itens.
            for (int i = 0; i < Count; i++)
                _internalArray[i] = _internalArray[i + 1];

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


        public IOmegaEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private bool IsEmpty() => Count == 0;

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
