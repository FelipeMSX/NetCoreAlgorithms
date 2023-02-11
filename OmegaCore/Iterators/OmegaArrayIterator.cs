using OmegaCore.Abstracts;

namespace OmegaCore.Iterators
{
    public class OmegaArrayIterator<T> : IOmegaIteratorBase<T>
    {
        private T[]? _source;
        private int _currentIndex = 0;
        private readonly int _count = 0;

        public OmegaArrayIterator(T[] source, int count)
        {
            _source = source;
            _count = count;
        }

        public override bool MoveNext()
        {
            if (_currentIndex < _count)
            {
                Current = _source![_currentIndex++];
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            _currentIndex = 0;
            Current = default!;
        }

        public override void Dispose()
        {
            Current = default!;
            _source = null;
        }
    }
}