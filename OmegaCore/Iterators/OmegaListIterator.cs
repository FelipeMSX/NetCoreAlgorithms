using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    public class OmegaListIterator<T> : IOmegaIteratorBase<T>
    {
        private readonly IOmegaList<T> _source;
        private int _currentIndex = 0;

        public OmegaListIterator(IOmegaList<T> source)
        {
            _source = source;
        }

        public override bool MoveNext()
        {
            if (_currentIndex < _source.Count)
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
