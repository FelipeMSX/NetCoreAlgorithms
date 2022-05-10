using System;
using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Iterators;
using NSubstitute;

namespace Core.Tests.Shared
{
 
public class SimpleArray : Interfaces.IList<int>
    {

        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public int Current => throw new NotImplementedException();

        object INumerator.Current => throw new NotImplementedException();

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

        public INumerator<int> GetEnumerator()
        {
            return this;
            
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

        INumerator INumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
    }

    public class teste : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}