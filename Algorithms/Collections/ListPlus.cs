﻿using System.Text;
using System.Threading.Tasks;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Interfaces;

namespace Algorithms.Collections
{
    public class ListPlus<T> : IOmegaList<T>
    {
        public T this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Count => throw new System.NotImplementedException();

        public int MaxCapacity => throw new System.NotImplementedException();

        public bool Resizable => throw new System.NotImplementedException();

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public T First()
        {
            throw new System.NotImplementedException();
        }



        public T Last()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Retrieve(T item)
        {
            throw new System.NotImplementedException();
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int startIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFull()
        {
            throw new System.NotImplementedException();
        }

        public void Swap(int source, int destination)
        {
            throw new System.NotImplementedException();
        }
    }
}
