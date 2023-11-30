using Algorithms.Interfaces;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using System.Collections.Generic;
using OmegaCore.Collections.Interfaces;
using OmegaCore.OmegaLINQ;
using OmegaCore.Exceptions;
using System;

namespace Algorithms.Sorts
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipeprodev@gmail.com</email>
    public class HeapSort<T> : IOmegaComparator<T>, ISortable<T>
    {
        public OmegaComparison<T> Comparator { get; set; }

        /// <summary>
        /// The current build strategy of the heap.
        /// </summary>
        public Build Operation { get; }

        /// <param name="comparator">Defines a simple way to compare two objects</param>
        /// <param name="build">The heap can be building using MIN or MAX strategy</param>
        public HeapSort(OmegaComparison<T> comparator, Build build = Build.Max)
        {
            Comparator = comparator;
            Operation = build;
        }


        /// <summary>
        /// Orders the collection using the heapsort algorithm.
        /// <para>Time: <b>O(n log n)</b></para>
        /// <para>Memory: <b>O(1)</b></para>
        /// </summary>
        /// <param name="list">Lista de elementos.</param>
        /// <exception cref="ComparatorNotSetException"/>
        /// <exception cref="NullObjectException"/>
        public void Sort(IOmegaList<T> list)
        {
            //Validations
            OmegaCore.Exceptions.ArgumentNullException.CheckAgainstNull(list, nameof(list));

            if (Comparator == null)
                throw new ComparatorNotSetException();

            Heapsort(list);
        }

        private void Heapsort(IOmegaList<T> list)
        {
            BuildHeap(list, list.Count);
            for (int i = list.Count - 1; i > 0; i--)
            {
                //Change this for the ArrayExtensions.
                //ListFunctions.Swap(list, 0, i);
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
        private void Heapify(IOmegaList<T> list, int currentPosition, int listLength)
        {
            int leftPosition = Left(currentPosition);
            int rightPosition = Right(currentPosition);

            // leftPosition < position. Verifica se não extrapola os limites do vetor.
            // Se o filho esquerdo for maior que o pai é necessário trocar.
            if (leftPosition < listLength && CheckCompareResult(Comparator(list[leftPosition], list[currentPosition])))
                Realocate(list, currentPosition, leftPosition, listLength);

            // rightPosition < position. Verifica se não extrapola os limites do vetor.
            // Se o filho direito for maior que o pai é necessário trocar.
            if (rightPosition < listLength && CheckCompareResult(Comparator(list[leftPosition], list[currentPosition])))
                Realocate(list, currentPosition, rightPosition, listLength);

        }
        private bool CheckCompareResult(int compareResult)
        {
            return Operation == Build.Min ? compareResult <= 0 : compareResult >= 0;
        }

        /// <summary>
        /// Faz a troca de dois elementos da lista e chama o processo de Heapify novamente para o objeto trocado.
        /// </summary>
        private void Realocate(IOmegaList<T> list, int currentPosition, int swapPosition, int listLength)
        {
            ///*ListFunctions*/.Swap(list, currentPosition, swapPosition);
            Heapify(list, swapPosition, listLength);
        }

        /// <summary>
        /// Constrói o heap a partir da lista.
        /// </summary>
		private void BuildHeap(IOmegaList<T> list, int listLength)
        {
            for (int i = (listLength / 2) - 1; i >= 0; i--)
                Heapify(list, i, listLength);
        }

        /// <summary>
        /// Based on the position calculates his left son.
        /// </summary>
        /// <returns>Returns the position of the left son in the array</returns>
        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        /// <summary>
        /// Based on the position calculates his right son.
        /// </summary>
        /// <returns>Returns the position of the right son in the array</returns>
        private static int Right(int position)
        {
            return 2 * position + 2;
        }
    }

    /// <summary>
    /// Indicates whether the heap will be build using the MIN or MAX strategy.
    /// </summary>
    public enum Build { Max, Min };
}
