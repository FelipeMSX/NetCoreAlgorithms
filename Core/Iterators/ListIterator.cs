using System;
using System.Collections;
using Core.Abstracts;
using Core.Interfaces;

namespace Core.Iterators
{
    public class ArrayIterator<T> : Iterator<T>
    {
        private T[] _source { get; }
        private int _currentIndex = 0;

        public ArrayIterator(T[] source)
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
