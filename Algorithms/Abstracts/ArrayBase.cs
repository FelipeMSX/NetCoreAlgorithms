using System;
using Algorithms.Interfaces;
using Algorithms.Exceptions;
using System.Collections.Generic;
using System.Collections;
using Algorithms.Helpers;
using System.Linq;

namespace Algorithms.Abstracts
{
    public abstract class ArrayBase<T> : IEnumerable<T>, IDefaultComparator<T>
    {
        private readonly IEnumerableHelper<T> _collectionHelper;
        public const int DefaultSize = 1000;

        protected T[] Vector;

        public T this[int index]
        {
            get => Vector[index];
            set => Vector[index] = value;
        }


        protected ArrayBase(int maxSize, Comparison<T> comparator, bool resizable = true, bool allowEqualsElements = true)
        {
            MaxSize             = maxSize;
            Vector              = new T[maxSize];
            Resizable           = resizable;
            Comparator          = comparator ?? throw new NullObjectException("The comparison object cannot be null");
            AllowEqualsElements = allowEqualsElements;
            _collectionHelper   = new EnumerableHelper<T>(this, Comparator);
        }

        protected ArrayBase(Comparison<T> comparator) : this(1000, comparator, true, true)
        {
        }

        #region Properties
        public Comparison<T> Comparator { get; set; }

        private int maxSize;
        public int MaxSize
        {
            get { return maxSize; }
            protected set
            {
                if (value < maxSize)
                    throw new ValueNotValidException("Max size can't be less than current!");
                maxSize = value;
            }
        }

        public bool AllowEqualsElements { get; protected set; }
        public bool Resizable { get; set; }
        public int Count { get; protected set; }
        public bool IsReadOnly => false;

        #endregion

        public abstract IEnumerator<T> GetEnumerator();

        public void Clear()
        {
            Vector = new T[MaxSize];
            Count = 0;
        }

        public bool Empty() => Count == 0;
        public bool Full() => Count == MaxSize;
        public T First() => Empty() ? default(T) : Vector[0];
        public T Last() => Empty() ? default(T) : Vector[Count - 1];

        public virtual T Retrieve(T item)
        {
            if (Comparator == null)
                throw new ComparerNotSetException();

            for (int i = 0; i < Count; i++)
            {
                if (Comparator.Check(Vector[i], item) == ComparisonResult.Equal)
                    return item;
            }

            return default(T);
        }

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


        public bool Contains(T item)  => _collectionHelper.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _collectionHelper.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
