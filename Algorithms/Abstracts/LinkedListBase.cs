using System;
using Algorithms.Interfaces;
using System.Collections.Generic;
using System.Collections;
using Algorithms.Exceptions;
using System.Linq;
using Algorithms.Helpers;

namespace Algorithms.Abstracts
{

    public abstract class LinkedListBase<T, E> : IEnumerable<T>, IDefaultComparator<T>
        where E : NodeBase<T>, new()
    {

        private readonly IEnumerableHelper<T> _enumerableHelper;

        /// <summary>
        /// Aponta para o primeiro item da coleção da coleção. Não armazena dados.
        /// </summary>
        protected E Head { get; set; }

        /// <summary>
        /// Informa se a coleção está vazia.
        /// </summary>
        public bool IsEmpty() => Count == 0;

        /// <summary>
        /// Fornece um método de comparação para os objetos da coleção.
        /// </summary>
        public Comparison<T> Comparator { get; }
        public int Count { get; protected set; }
        public bool IsReadOnly => false;

        public LinkedListBase(Comparison<T> comparator)
        {
            Comparator = comparator;
            _enumerableHelper = new EnumerableHelper<T>(this,comparator);
        }
        public abstract IEnumerator<T> GetEnumerator();
        public abstract void Add(T item);
        public abstract bool Remove(T item);
        public abstract T Retrieve(T item);
        public abstract T First();
        public abstract T Last();
        public void Clear()
        {
            Head = new E();
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(T item)
        {
            if (Comparator == null)
                throw new NullObjectException("The comparator must be declared.");
            if (item == null)
                throw new ArgumentNullException("The argument cannot be null.");

            return this.Any(x => Comparator.Check(item, x) == ComparisonResult.Equal);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");

            int initialPosition = arrayIndex;

            foreach (T item in this)
            {
                array[initialPosition++] = item;
            }
        }
    }
}
