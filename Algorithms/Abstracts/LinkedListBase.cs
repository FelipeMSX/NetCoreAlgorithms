using System;
using Algorithms.Interfaces;
using System.Collections.Generic;
using System.Collections;
using Algorithms.Exceptions;
using System.Linq;
using Algorithms.Helpers;

namespace Algorithms.Abstracts
{

    public abstract class LinkedListBase<TValue, ENode> : IEnumerable<TValue>, IDefaultComparator<TValue>
        where ENode : NodeBase<TValue>, new()
    {

        private readonly IEnumerableHelper<TValue> _enumerableHelper;

        /// <summary>
        /// Aponta para o primeiro item da coleção da coleção. Não armazena dados.
        /// </summary>
        protected ENode Head { get; set; }

        /// <summary>
        /// Informa se a coleção está vazia.
        /// </summary>
        public bool IsEmpty() => Count == 0;

        /// <summary>
        /// Fornece um método de comparação para os objetos da coleção.
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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(TValue item) => _enumerableHelper.Contains(item);

        public void CopyTo(TValue[] array, int arrayIndex) => _enumerableHelper.CopyTo(array, arrayIndex);
    }
}
