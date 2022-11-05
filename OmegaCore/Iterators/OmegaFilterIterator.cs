using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    public class OmegaFilterIterator<T> : IOmegaIteratorBase<T>
    {
        private readonly IOmegaEnumerator<T> _sourceEnumerator;

        private readonly Func<T, bool> _predicate;

        public OmegaFilterIterator(IOmegaEnumerable<T> source, Func<T, bool> predicate)
        {
            _sourceEnumerator = source.GetEnumerator();
            _predicate = predicate;
        }

        public override bool MoveNext()
        {
            while (_sourceEnumerator.MoveNext())
            {
                if (_predicate(_sourceEnumerator.Current))
                {
                    Current = _sourceEnumerator.Current;
                    return true;
                }
            }
            return false;
        }

        public override void Reset()
        {
            Current = default;
            _sourceEnumerator.Reset();
        }
    }
}
