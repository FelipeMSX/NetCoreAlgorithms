using System;

namespace Algorithms.Abstracts
{
	/// <summary>
	/// Classe abstrata utilizada na criação de qualquer coleção que utilize uma pilha ou fila.
	/// </summary>
	/// <author>Felipe Morais</author>
	/// <email>felipemsx18@gmail.com</email>
	/// <typeparam name="E">Tipo do objeto armazenado na coleção.</typeparam>
	public abstract class QueueStackBase<T> : ArrayBase<T>
	{

		public abstract void Push(T obj);
		public abstract T Pop();
        public abstract T Peek();

		protected QueueStackBase() : base()
		{
		}

        protected QueueStackBase(int maxsize, bool resizable = true, bool allowEqualsElements = true, Comparison<T> comparator = null) 
            : base (maxsize, resizable, allowEqualsElements, comparator)
		{
		}
	}
}
