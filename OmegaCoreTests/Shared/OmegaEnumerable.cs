using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCoreTests.Shared
{
    internal class OmegaEnumerable : IOmegaEnumerable<int>
    {
        private readonly int[] values = {1,2,3,4,5};

        public IOmegaEnumerator<int> GetEnumerator() => new OmegaArrayIterator<int>(values);

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
