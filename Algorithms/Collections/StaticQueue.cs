using System;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections
{
	/// <summary>
	/// Estrutura de dados que representa uma fila.
	/// </summary>
	/// <author>Felipe Morais</author>
	/// <email>felipemsx18@gmail.com</email>
	/// <typeparam name="E">Tipo do objeto armazenado na coleção.</typeparam>
	public class StaticQueue<T> : QueueStackBase<T>
	{

		public StaticQueue() : base()
		{
		}

		/// <param name="maxsize">Valor máximo de itens que a coleção pode armazenar.</param>
		/// <param name="resizable">Define se a coleção deve se expandir ao atingir a capacidade máxima.</param>
		/// <param name="comparator">Fornece um método de comparação para os objetos da coleção.</param>
		public StaticQueue(int maxsize, bool resizable = true, bool allowEqualsElements = true, Comparison<T> comparator = null) 
            : base(maxsize, resizable ,allowEqualsElements, comparator)
		{
		}
		/// <summary>
		///  Insere um elemento na fila.
		/// </summary>
		/// <exception cref="NullObjectException">Objeto não pode ser nulo.</exception>
		/// <exception cref="FullCollectionException">A coleção está cheia.</exception>
		/// <param name="obj">Objeto a ser inserido na fila</param>
		public override void Push(T obj)
		{
			//Validações
			if (obj == null)
				throw new NullObjectException();
            else
			if (Full() && !Resizable)
				throw new FullCollectionException();
            else
            if (Full())
            {
                IncreaseCapacity(DefaultSize);
            }

			Vector[Length++] = obj;
		}

		/// <summary>
		/// Faz a extração do primeiro elemento a deixar a fila e o retorna.
		/// </summary>
		/// <exception cref="EmptyCollectionException">Se a fila estiver vazia causa um erro.</exception>
		/// <returns>Retorna o primeiro elemento a sair da fila</returns>
		public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T obj = Vector[0];

            Length--;
            //Desloca os itens
            for (int i = 0; i < Length; i++)
			{
				Vector[i] = Vector[i + 1];
			}

			return obj;
		}

        /// <summary>
        /// Retorna o primero elemento a sair da fila sem removê-lo.
        /// </summary>
        /// <exception cref="EmptyCollectionException">Se a fila estiver vazia causa um erro.</exception>
        /// <returns></returns>
        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            T obj = Vector[0];

            return obj;
        }
    }
}
