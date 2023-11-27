using OmegaCore.Abstracts;

namespace OmegaCore.Iterators
{
    /// <summary>
    /// Creates a iterator to interact with each item in the array. 
    /// <para>The count value can be used optimize the process because in the array not all positions can have elements</para>
    /// <para>the array can be iterated in the normal or reverse order</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class OmegaArrayIterator<T> : IOmegaIteratorBase<T>
    {
        private T[] _source;
        private int _currentIndex = 0;
        private readonly int _count = 0;
        private readonly bool _revert;

        public OmegaArrayIterator(T[] source, int count, bool revert = false)
        {
            _source = source;
            _count = count;
            _revert = revert;

            if (revert)
                _currentIndex = count;
        }

        public override bool MoveNext()
        {
            if (_revert)
            {
                if (_currentIndex > 0)
                {
                    Current = _source[--_currentIndex];
                    return true;
                }
            }
            else
            {
                if (_currentIndex < _count)
                {
                    Current = _source[_currentIndex++];
                    return true;
                }
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
            _source = null!;
        }
    }
}