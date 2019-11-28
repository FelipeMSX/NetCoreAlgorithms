using System;
using Algorithms.Interfaces;
using Algorithms.Exceptions;

namespace Algorithms.Abstracts
{
    /// <summary>
    /// Define uma classe abstrata para qualquer estrutura que precise de um vetor.
    /// Vetor pode ter sua capacidade aumentada caso necessário.
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    /// <typeparam name="E">Tipo do objeto armazenado na coleção.</typeparam>
    public abstract class ArrayBase<T> : ICommon<T>, IDefaultComparator<T>
    {
        #region Properties
        /// <summary>
        /// Constante que define um valor inicial padrão para a coleção.
        /// </summary>
        public const int DefaultSize = 100;

        /// <summary>
        /// Fornece um método de comparação para os objetos da coleção.
        /// </summary>
        public Comparison<T> Comparator { get; set; }

        /// <summary>
        /// Vetor que armazena os objetos genéricos da coleção.
        /// </summary>
        public T[] Vector { get; protected set; }

        /// <summary>
        /// Tamanho atual da coleção.
        /// </summary>
        public int Length { get; protected set; }

        private int maxSize;

        /// <summary>
        /// Controla o crescimento da coleção, definindo um limite a ela.
        /// </summary>
        /// <exception cref="ValueNotValidException">Valor não pode ser menor que o atual.</exception>
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

        /// <summary>
        /// Define se a coleção deve se expandir ao atingir a capacidade máxima.
        /// </summary>
        public bool Resizable { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize">Quantidade de itens que a coleção pode armazenar.</param>
        /// <param name="resizable">Define se a coleção deve se expandir ao atingir a capacidade máxima.</param>
        /// <param name="comparator">Fornece um método de comparação para os objetos da coleção.</param>
        protected ArrayBase(int maxSize, bool resizable = true, bool allowEqualsElements = true, Comparison<T> comparator = null)
        {
            MaxSize = maxSize;
            Vector = new T[maxSize];
            Resizable = resizable;
            Comparator = comparator;
        }

        protected ArrayBase() : this(100, true,true, null)
        {
        }

        #region Interfaces

        /// <summary>
        /// Remove todos os objetos da coleção.
        /// </summary>
        public void Clear()
        {
            Vector = new T[MaxSize];
            Length = 0;
        }

        /// <summary>
        /// Informa se a coleção está vazia.
        /// </summary>
        public bool Empty() => Length == 0;

        /// <summary>
        /// Informa se a coleção está cheia.
        /// </summary>
        public bool Full() => Length == MaxSize;

        /// <summary>
        /// Retorna o primeiro elmento da coleção. Se estiver vazia retorna o valor default do tipo do objeto.
        /// </summary>
        public T First() => Empty() ? default(T) : Vector[0];

        /// <summary>
        /// Retorna o último elmento da coleção. Se estiver vazia retorna o valor default do tipo do objeto.
        /// </summary>
        public T Last() => Empty() ? default(T) : Vector[Length - 1];

        /// <summary>
        /// Percorre a coleção até encontrar o objeto. Somente retorna o objeto não o remove. É necessário definir um Comparator a coleção.
        /// </summary>
        /// <exception cref="ComparerNotSetException">Caso a coleção não tenha um comparator definido.</exception>
        /// <param name="obj">Objeto com as keys necessárias para encontrar um objeto na coleção.</param>
        /// <returns></returns>
        /// 
        public T Retrive(T obj)
        {
            if (Comparator == null)
                throw new ComparerNotSetException();

            for (int i = 0; i < Length; i++)
            {
                if (Comparator(Vector[i], obj) == 0)
                    return obj;
            }

            return default(T);
        }
        #endregion

        /// <summary>
        /// Aumenta a capacidade da coleção de acordo com o ResizeValue.
        /// </summary>
        /// <exception cref="FullCollectionException">A coleção não foi configurada para aumentar dinamicamente seu tamanho a medida do necessário.</exception>
        public void IncreaseCapacity(int increment)
        {
            if (!Resizable)
                throw new FullCollectionException();

            MaxSize += increment;
            T[] temp = new T[MaxSize];

            for (int i = 0; i < Length; i++)
            {
                temp[i] = Vector[i];
            }
            Vector = temp;
        }
    }
}
