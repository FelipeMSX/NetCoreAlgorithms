using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    public class OmegaTakeIterator<T> : IOmegaIteratorBase<T>
    {
        public int Count { get; }

        private readonly IOmegaEnumerator<T> _sourceEnumerator;

        private int _count;

        public OmegaTakeIterator(IOmegaEnumerable<T> source, int count)
        {
            _sourceEnumerator = source.GetEnumerator();
            Count = count;
            _count = count;
        }

        public override bool MoveNext()
        {

            if (_count <= 0)
                return false;

            if (_sourceEnumerator.MoveNext())
            {
                Current = _sourceEnumerator.Current;
                _count--;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            Current = default;
            _count = Count;
            _sourceEnumerator.Reset();
        }
    }
}
