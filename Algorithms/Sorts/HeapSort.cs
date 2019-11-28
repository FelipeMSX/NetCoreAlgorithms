using Algorithms.Interfaces;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    /// <typeparam name="E"></typeparam>
    public class HeapSort<T> : IDefaultComparator<T>
    {
        /// <summary>
        /// Compara dois objetos e retorna um inteiro indicando o grau de comparação entre eles.
        /// </summary>
        public Comparison<T> Comparator { get; set; }

        /// <summary>
        /// Indica se o Heap será construído com o maior valor no top da árvore"MAX", 
        /// ou o menor valor no top da árvore "MIN".
        /// </summary>
        public enum Build { Max, Min };

        /// <summary>
        /// Indica como o heap deverá ser construído. Max ou Min.
        /// </summary>
        public Build Operation { get; }

    
        /// <param name="comparator">Define a forma que os elementos serão comparados na lista</param>
        /// <param name="build">A forma que o heap será construído.</param>
        public HeapSort(Comparison<T> comparator, Build build)
        {
            Comparator = comparator;
            Operation = build;
        }

        /// <param name="comparator">Define a forma que os elementos serão comparados na lista</param>
        public HeapSort(Comparison<T> comparator) : this(comparator, Build.Max) { }

        /// <summary>
        /// Ordena os elementos de um vetor utilizando o algoritmo do HeapSort
        /// </summary>
        /// <param name="list">Lista de elementos.</param>
        /// <exception cref="ComparerNotSetException"/>
        /// <exception cref="NullObjectException"/>
		public void Sort(IList<T> list)
        {
            //validações
            if (Comparator == null)
                throw new ComparerNotSetException();
            if (list == null)
                throw new NullObjectException();

            Heapsort(list);
        }


        private void Heapsort(IList<T> list)
        {
            BuildHeap(list, list.Count);
            for (int i = list.Count - 1; i > 0; i--)
            {
                ListFunctions.Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        /// <summary>
        /// Sub-rotina utilizada para construiro heapMin. Vefirificando se o nó pai possui filhos maiores que ele.
        /// Caso o pai tenha filho com nó maior é necessário efetuar a troca.
        /// </summary>
        /// <param name="list">Lista de objetos para ordenação.</param>
        /// <param name="currentPosition">Posição do item a ser analisado.</param>
        /// <param name="listLength">Tamanho da lista Ou o limite superior.</param>
        private void Heapify(IList<T> list, int currentPosition, int listLength)
        {
            int leftPosition = Left(currentPosition);
            int rightPosition = Right(currentPosition);

            if (Operation == Build.Min)
            {
                // leftPosition < position. Verifica se não extrapola os limites do vetor.
                // Se o filho esquerdo for maior que o pai é necessário trocar.
                if (leftPosition < listLength && Comparator(list[leftPosition], list[currentPosition]) <= 0)
                    Realocate(list, currentPosition, leftPosition, listLength);

                // rightPosition < position. Verifica se não extrapola os limites do vetor.
                // Se o filho direito for maior que o pai é necessário trocar.
                if (rightPosition < listLength && Comparator(list[rightPosition], list[currentPosition]) <= 0)
                    Realocate(list, currentPosition, rightPosition, listLength);
            }
            else
            {
                // leftPosition > position. Verifica se não extrapola os limites do vetor.
                // Se o filho esquerdo for menor que o pai é necessário trocar.
                if (leftPosition < listLength && Comparator(list[leftPosition], list[currentPosition]) >= 0)
                    Realocate(list, currentPosition, leftPosition, listLength);

                // rightPosition > position. Verifica se não extrapola os limites do vetor.
                // Se o filho direito for maior que o pai é necessário trocar.
                if (rightPosition < listLength && Comparator(list[rightPosition], list[currentPosition]) >= 0)
                    Realocate(list, currentPosition, rightPosition, listLength);
            }
        }

        /// <summary>
        /// Faz a troca de dois elementos da lista e chama o processo de Heapify novamente para o objeto trocado.
        /// </summary>
        private void Realocate(IList<T> list, int currentPosition, int swapPosition, int listLength)
        {
            ListFunctions.Swap(list, currentPosition, swapPosition);
            Heapify(list, swapPosition, listLength);
        }

        /// <summary>
        /// Constrói o heap a partir da lista.
        /// </summary>
		private void BuildHeap(IList<T> list, int listLength)
        {
            for (int i = (listLength / 2) - 1; i >= 0; i--)
                Heapify(list, i, listLength);
        }

        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 2;
        }
   }
}
