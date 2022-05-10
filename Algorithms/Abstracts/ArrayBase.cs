using System;
using Algorithms.Interfaces;
using Algorithms.Exceptions;
using System.Collections.Generic;
using System.Collections;
using Algorithms.Helpers;
using System.Linq;
using Core;

namespace Algorithms.Abstracts
{
    public abstract class ArrayBase<T> : IEnumerable<T>
    {
        private readonly IEnumerableHelper<T> _collectionHelper;
        private readonly Comparison<T> _comparator;

        protected T[] Vector;

        /// <summary>
        /// The initial size of the collection.
        /// </summary>
        public const int DefaultSize = 1000;

        public T this[int index]
        {
            get => Vector[index];
        }


        protected ArrayBase(int maxSize, Comparison<T> comparator, bool resizable = true)
        {
            MaxSize             = maxSize;
            Vector              = new T[maxSize];
            Resizable           = resizable;
            _comparator         = comparator ?? throw new ComparerNotSetException("The comparison object cannot be null");
            _collectionHelper   = new EnumerableHelper<T>(this, _comparator);

        }

        protected ArrayBase(Comparison<T> comparator) : this(1000, comparator, true)
        {
        }

        #region Properties

        private int maxSize;

        /// <summary>
        /// Represents the maximum size of the collection. The size can grow if the collecion is resizable.
        /// </summary>
        public int MaxSize
        {
            get { return maxSize; }
            protected set
            {
                if (value < maxSize)
                    throw new ValueNotValidException("The new value can't be less than current!");
                maxSize = value;
            }
        }

        /// <summary>
        /// Allows the collection to dynamic resize your size.
        /// </summary>
        public bool Resizable { get; set; }

        /// <summary>
        /// Counts the number of items in the collection.
        /// </summary>
        public int Count { get; protected set; }

        #endregion

        public abstract IEnumerator<T> GetEnumerator();

        /// <summary>
        /// Puts the collection in the initial state, this means no items and size equal to zero.
        /// </summary>
        public void Clear()
        {
            Vector = new T[MaxSize];
            Count = 0;
        }

        /// <summary>
        /// Returns true if the collection doesn't has elements, otherwise it returns false.
        /// </summary>
        public bool Empty() => Count == 0;

        /// <summary>
        /// Returns true if the collection has reached its maximum size, otherwise it returns false.
        /// </summary>
        public bool Full() => Count == MaxSize;

        /// <summary>
        /// Gets the first item that must leave the collection.
        /// </summary>
        public virtual T First() => Empty() ? default(T) : Vector[0];

        /// <summary>
        /// Gets the last item that must leave the collection.
        /// </summary>
        public virtual T Last() => Empty() ? default(T) : Vector[Count - 1];

        /// <summary>
        /// Searchs in the collection for the item and it must return the item found. Throws exception when the item is not found.
        /// </summary>
        /// <exception cref="ElementNotFoundException"/>
        /// <exception cref="EmptyCollectionException"/>
        /// <exception cref="NullObjectException"/>
        public virtual T Retrieve(T item)
        {
            if (Empty())
                throw new EmptyCollectionException();
            else if (item == null)
                throw new NullObjectException();

            for (int i = 0; i < Count; i++)
            {
                if (_comparator.Check(Vector[i], item) == ComparisonResult.Equal)
                    return item;
            }

            throw new ElementNotFoundException();
        }

        /// <summary>
        /// Increases collection capacity by input parameter. All elements will be transfered to the new vector.
        /// </summary>
        /// <param name="increment">The value should be greater than zero.</param>
        /// <exception cref="FullCollectionException"/>
        /// <exception cref="ValueNotValidException"/>
        public void IncreaseCapacity(int increment)
        {
            if (!Resizable)
                throw new FullCollectionException();

            MaxSize += increment;
            T[] temp = new T[MaxSize];

            for (int i = 0; i < Count; i++)
            {
                temp[i] = Vector[i];
            }
            Vector = temp;
        }


        /// <summary>
        /// Verifies if there is an specific item in the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        public bool Contains(T item)  => _collectionHelper.Contains(item);

        /// <summary>
        /// Creates a copy of the collection to an array.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        public void CopyTo(T[] array, int arrayIndex) => _collectionHelper.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
