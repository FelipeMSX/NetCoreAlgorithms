using Core.Abstracts;

namespace Core.Iterators
{
    public class OmegaListIterator<T> : IOmegaterator<T>
    {
        private Interfaces.IOmegaList<T> _source { get; }
        private int _currentIndex = 0;

        public OmegaListIterator(Interfaces.IOmegaList<T> source)
        {
            _source = source;
        }

        public override bool MoveNext()
        {
            if(_currentIndex < _source.Count  )
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
