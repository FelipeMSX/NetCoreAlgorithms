using Algorithms.Exceptions;
using Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms.Helpers
{
    public class EnumerableHelper<T> : IEnumerableHelper<T>
    {
        private readonly IEnumerable<T> _collection;
        private readonly Comparison<T> _comparator;

        public EnumerableHelper(IEnumerable<T> collection, Comparison<T> comparator)
        {
            _collection = collection;
            _comparator = comparator;
        }

        public bool Contains(T item)
        {
            if (_comparator == null)
                throw new NullObjectException("The comparator must be declared.");
            if (item == null)
                throw new ArgumentNullException("The argument cannot be null.");

            return _collection.Any(x => _comparator.Check(item, x) == ComparisonResult.Equal);
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");

            int initialPosition = arrayIndex;

            foreach (T item in _collection)
            {
                array[initialPosition++] = item;
            }
        }
    }
}
