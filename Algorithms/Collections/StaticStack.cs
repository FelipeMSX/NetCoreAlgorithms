using System;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections
{
    /// <summary>
    ///  Estrutura de dados que representa uma pilha.
    ///  <para>Características</para>
    ///  <para>1* Os objetos são colocados no final do vetor.</para>
    ///  <para>2*Ao retirada do objeto é feita no final do vetor.</para>
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    /// <typeparam name="E">Tipo de Objeto da pilha.</typeparam>
    public class StaticStack<T> : QueueStackBase<T> 
	{
        /// <summary>
        /// Inicializa a coleção com o tamanho padrão de 100, e por padrão seu tamanho é reajustável.
        /// </summary>
		public StaticStack() : base()
		{
		}

        /// <param name="maxsize">Valor máximo de itens que a coleção pode armazenar.</param>
        /// <param name="resizable">Define se a coleção deve se expandir ao atingir a capacidade máxima.</param>
        /// <param name="comparator">Fornece um método de comparação para os objetos da coleção.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public StaticStack(int maxsize, bool resizable = true, bool allowEqualsElements = true, Comparison<T> comparator = null) 
            : base (maxsize, resizable, allowEqualsElements, comparator)
		{

		}

		/// <summary>
		///  Coloca um objeto
		/// </summary>
		/// <exception cref="NullObjectException">Objeto não pode ser nulo.</exception>
		/// <exception cref="FullCollectionException">A pilha está cheia e não aceita está configurada para ser redimensionada.</exception>
		/// <param name="obj">Objeto a ser inserido na coleção.</param>
		public override void Push(T obj)
		{
            //Validações
			if (obj == null)
				throw new NullObjectException();
			if (Full())
				IncreaseCapacity(DefaultSize);

			Vector[Length++] = obj;
		}

		/// <summary>
		///  Remove o primeiro objeto da coleção.
		/// </summary>
		/// <exception cref="EmptyCollectionException">Não existe elemento para remover na pilha.</exception>
		/// <returns></returns>
		public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T temp = Vector[--Length];
			Vector[Length] = default;

			return temp;
		}


        /// <summary>
        /// Retorna o primero elemento a sair da pilha sem removê-lo.
        /// </summary>
        /// <exception cref="EmptyCollectionException">Se a pilha estiver vazia causa um erro.</exception>
        /// <returns></returns>
        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            T obj = Vector[Length - 1];

            return obj;
        }
    }
}
