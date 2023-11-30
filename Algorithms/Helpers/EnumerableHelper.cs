using Algorithms.Exceptions;
using Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Helpers
{
    public class EnumerableHelper<T> : IEnumerableHelper<T>
    {
        private readonly IEnumerable<T> _collection;
        private readonly Comparison<T> _comparator;

        public EnumerableHelper(IEnumerable<T> collection, Comparison<T> comparator)
        {
            _collection = collection ?? throw new System.ArgumentNullException("The array cannot be null.");
            _comparator = comparator ?? throw new ComparatorNotSetException("The comparator must be declared."); 
        }

        /// <summary>
        /// Verifies if there is an specific item in the collection.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"/>
        public bool Contains(T item)
        {
            if (item == null)
                throw new System.ArgumentNullException("The argument cannot be null.");

            return _collection.Any(x => _comparator.Check(item, x) == ComparisonResult.Equal);
        }

        /// <summary>
        /// Creates a copy of the collection to an array.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new System.ArgumentNullException("The array cannot be null.");

            int initialPosition = arrayIndex;

            foreach (T item in _collection)
            {
                array[initialPosition++] = item;
            }
        }
    }
}
