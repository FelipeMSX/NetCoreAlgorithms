﻿using OmegaCore.Abstracts;
using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    public class OmegaPredicateIterator<T> : IOmegaIteratorBase<T>
    {
        private IOmegaEnumerator<T>? _sourceEnumerator;

        private Func<T, bool>? _predicate;

        public OmegaPredicateIterator(IOmegaEnumerable<T> source, Func<T, bool> predicate)
        {
            _sourceEnumerator = source.GetEnumerator();
            _predicate = predicate;
        }

        public override bool MoveNext()
        {
            while (_sourceEnumerator!.MoveNext())
            {
                if (_predicate!(_sourceEnumerator.Current!))
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
            _sourceEnumerator!.Reset();
        }

        public override void Dispose()
        {
            _sourceEnumerator!.Dispose();
            Current = default!;
            _sourceEnumerator = null;
            _predicate= null;
        }
    }
}