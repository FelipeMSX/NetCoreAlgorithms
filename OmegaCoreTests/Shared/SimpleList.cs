using System;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCoreTests.Shared
{

    public class SimpleList<T> : IOmegaList<T>
    {

        private readonly T[] _internalArray;
        public T this[int index] { get => _internalArray[index]; set => _internalArray[index] = value; }

        public int Count => _internalArray.Length;

        public SimpleList(T[] internalArray)
        {
            _internalArray = internalArray;
        }

        public SimpleList()
        {
            _internalArray = Array.Empty<T>();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T First()
        {
            throw new NotImplementedException();
        }


        public T Last()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T Retrieve(T item)
        {
            throw new NotImplementedException();
        }

    
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            return new OmegaListIterator<T>(this);
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}