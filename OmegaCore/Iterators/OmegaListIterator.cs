using OmegaCore.Abstracts;
using OmegaCore.Collections.Interfaces;

namespace OmegaCore.Iterators
{
    /// <summary>
    /// Creates a iterator to interact with each item in the array. 
    /// <para>The count value can be used optimize the process because in the array not all positions can have elements</para>
    /// <para>the array can be iterated in the normal or reverse order</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class OmegaListIterator<T> : IOmegaIteratorBase<T>
    {
        private IOmegaList<T> _source;
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
            Current = default!;
        }

        public override void Dispose()
        {
            Current = default!;
            _source = null!;
        }
    }
}