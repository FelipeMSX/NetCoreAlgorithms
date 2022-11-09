using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    public class OmegaArrayIterator<T> : IOmegaIteratorBase<T>
    {
        private readonly T[] _source;
        private int _currentIndex = 0;

        public OmegaArrayIterator(T[] source)
        {
            _source = source;
        }

        public override bool MoveNext()
        {
            if (_currentIndex < _source.Length)
            {
                Current = _source[_currentIndex++];
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            _currentIndex = 0;
            Current = default;
        }

    }
}
