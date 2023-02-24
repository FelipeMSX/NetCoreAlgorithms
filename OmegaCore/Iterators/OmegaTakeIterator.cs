using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    /// <summary>
    /// Creates a iterator to interact with each item in the array. 
    /// <para>The count value can be used optimize the process because in the array not all positions can have elements</para>
    /// <para>the array can be iterated in the normal or reverse order</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class OmegaTakeIterator<T> : IOmegaIteratorBase<T>
    {
        public int Count { get; }

        private IOmegaEnumerator<T>? _sourceEnumerator;

        private int _count;

        public OmegaTakeIterator(IOmegaEnumerable<T> source, int count)
        {
            _sourceEnumerator = source.GetEnumerator();
            Count = count;
            _count = count;
        }

        public override bool MoveNext()
        {
            if (_count <= 0)
                return false;

            if (_sourceEnumerator!.MoveNext())
            {
                Current = _sourceEnumerator.Current;
                _count--;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            Current = default!;
            _count = Count;
            _sourceEnumerator!.Reset();
        }

        public override void Dispose()
        {
            _sourceEnumerator!.Dispose();
            Current = default!;
            _sourceEnumerator= null!;
        }
    }
}