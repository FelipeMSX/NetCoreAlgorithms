using Core.Abstracts;

namespace Core.Iterators
{
    public class OmegaArrayIterator<T> : IOmegaterator<T>
    {
        private T[] _source { get; }
        private int _currentIndex = 0;

        public OmegaArrayIterator(T[] source)
        {
            _source = source;
        }

        public override bool MoveNext()
        {
            if(_currentIndex < _source.Length  )
            {
                Current = _source[_currentIndex++];
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            _currentIndex = 0;
            Current = _source[_currentIndex];
        }
    }
}
