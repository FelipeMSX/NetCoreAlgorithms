using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    /// <summary>
    /// Creates a iterator to interact with each item in the array. 
    /// <para>The count value can be used optimize the process because in the array not all positions can have elements</para>
    /// <para>the array can be iterated in the normal or reverse order</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class OmegaPredicateIterator<T> : OmegaIteratorBase<T>
    {
        private IOmegaEnumerator<T> _sourceEnumerator;

        private Func<T, bool> _predicate;

        public OmegaPredicateIterator(IOmegaEnumerable<T> source, Func<T, bool> predicate)
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
            Current = default!;
            _sourceEnumerator.Reset();
        }

        public override void Dispose()
        {
            _sourceEnumerator.Dispose();
            Current = default!;
            _sourceEnumerator = null!;
            _predicate= null!;
        }
    }
}