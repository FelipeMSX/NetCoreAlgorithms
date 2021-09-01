using System;
using Algorithms.Interfaces;
using System.Collections.Generic;
using System.Collections;
using Algorithms.Exceptions;
using Algorithms.Helpers;

namespace Algorithms.Abstracts
{

    public abstract class LinkedListBase<TValue, ENode> : IDefaultComparator<TValue>, IInteracbleCollection<TValue>
        where ENode : NodeBase<TValue>, new()
    {

        private readonly IEnumerableHelper<TValue> _enumerableHelper;

        /// <summary>
        /// Holds a pointer to the first node in the linked list. It doens't hold data.
        /// </summary>
        protected ENode Head { get; set; }

        /// <summary>
        /// Holds a pointer to .
        /// </summary>
        protected ENode LastNode { get; set; }

        /// <summary>
        /// Indicates if the collection is empty.
        /// </summary>
        public bool IsEmpty() => Count == 0;

        /// <summary>
        /// Provides a way to compare the objects in the collection.
        /// </summary>
        public Comparison<TValue> Comparator { get; }

        public int Count { get; protected set; }

        protected LinkedListBase(Comparison<TValue> comparator)
        {
            Comparator = comparator ?? throw new NullObjectException("The comparison object cannot be null");
            _enumerableHelper = new EnumerableHelper<TValue>(this,comparator);
        }

        public abstract IEnumerator<TValue> GetEnumerator();
        public abstract void Add(TValue item);
        public abstract void AddLast(TValue item);
        public abstract bool Remove(TValue item);
        public abstract bool RemoveFirst();
        public abstract bool RemoveLast();
        public abstract TValue Retrieve(TValue item);
        public abstract TValue First();
        public abstract TValue Last();

        public void Clear()
        {
            Head = new ENode();
            Count = 0;
        }

        //Explicit Implementation
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(TValue item) => _enumerableHelper.Contains(item);

        public void CopyTo(TValue[] array, int arrayIndex) => _enumerableHelper.CopyTo(array, arrayIndex);


        protected void ValidateObject(TValue item)
        {
            if (item == null)
                throw new NullObjectException();
        }

        protected void CheckEmptyCollection()
        {
            if (IsEmpty())
                throw new EmptyCollectionException();
        }
    }
}
