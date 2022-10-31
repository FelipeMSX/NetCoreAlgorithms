using System;
using Core.Interfaces;
using Core.Iterators;

namespace Core.Tests.Shared
{
 
public class SimpleArray : IOmegaList<int>
    {

        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public int Current => throw new NotImplementedException();


        public void Add(int item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int First()
        {
            throw new NotImplementedException();
        }


        public int Last()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        public int Retrieve(int item)
        {
            throw new NotImplementedException();
        }

    
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public IOmegaNumerator<int> GetEnumerator()
        {
            return new OmegaListIterator<int>(this);
        }

        INumerator INumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}