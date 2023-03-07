using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    /// <summary>
    /// Creates an iterator to interact with each item in the enumerator. 
    /// <para>When the internal count reaches the MaxCount the iterator will be stopped</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class OmegaTakeIterator<T> : IOmegaIteratorBase<T>
    {
        public int MaxCount { get; }

        private IOmegaEnumerator<T>? _sourceEnumerator;

        private int _count;

        public OmegaTakeIterator(IOmegaEnumerable<T> source, int count)
        {
            _sourceEnumerator = source.GetEnumerator();
            MaxCount = count;
        }

        public override bool MoveNext()
        {
            if (_count == MaxCount)
                return false;

            if (_sourceEnumerator!.MoveNext())
            {
                Current = _sourceEnumerator.Current;
                _count++;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            Current = default!;
            _count = MaxCount;
            _sourceEnumerator!.Reset();
        }

        public override void Dispose()
        {
            _sourceEnumerator!.Dispose();
            Current = default!;
            _sourceEnumerator = null!;
        }
    }
}