using System;
using Algorithms.Interfaces;
using System.Collections.Generic;
using System.Collections;

namespace Algorithms.Abstracts
{
	/// <summary>
	/// Classe abstrata utilizada em todas as coleções que se assemelham a uma lista dinâmica e suas variações.
	/// </summary>
	/// <author>Felipe Morais</author>
	/// <email>felipemsx18@gmail.com</email>
	/// <typeparam name="E">Objeto armazenado pela coleção.</typeparam>
	/// <typeparam name="T">Tipo do node utilizado na coleção.</typeparam>
	public abstract class LinkedListBase<E, T> : ICommon<E>, IEnumerable<E>, IDefaultComparator<E>
		where T : NodeBase<E>
	{

		/// <summary>
		/// Aponta para o primeiro item da coleção da coleção. Não armazena dados.
		/// </summary>
		protected T Head { get; set; }

		/// <summary>
		/// Atual tamanho da coleção.
		/// </summary>
		public int Length { get; protected set; }

        /// <summary>
        /// Informa se a coleção está vazia.
        /// </summary>
        public bool Empty() => Length == 0;

        /// <summary>
        /// Fornece um método de comparação para os objetos da coleção.
        /// </summary>
        public Comparison<E> Comparator { get; set; }

		public abstract void Insert(E obj);
		public abstract E Remove(E obj);
		public abstract E First();
		public abstract E Last();
		public abstract E Retrive(E obj);
        public abstract void Clear();

        public abstract IEnumerator<E> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
    }
}
