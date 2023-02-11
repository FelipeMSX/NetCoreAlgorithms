using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCoreTests.Shared
{
    internal class OmegaCollection : IOmegaCollection<int>
    {
        private readonly int[] values = {1,2,3,4,5};

        public int Count => 5;

        public void Add(int item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(int[] array, int startIndex)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public int First()
        {
            throw new System.NotImplementedException();
        }

        public IOmegaEnumerator<int> GetEnumerator() => new OmegaArrayIterator<int>(values, Count);

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }

        public int Last()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int item)
        {
            throw new System.NotImplementedException();
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
