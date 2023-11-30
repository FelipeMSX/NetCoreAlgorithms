using Algorithms.Interfaces;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using System.Collections.Generic;
using OmegaCore.Collections.Interfaces;
using OmegaCore.OmegaLINQ;

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

        private readonly IHeapSortBuildStrategy<T> _buildStrategy;

        #region Constructors
        /// <param name="comparator">Defines a simple way to compare two objects</param>
        /// <param name="build">The heap can be building using MIN or MAX strategy</param>
        public HeapSort(OmegaComparison<T> comparator, Build build)
        {
            Comparator = comparator;
            Operation = build;
        }

        /// <param name="comparator">Defines a simple way to compare two objects</param>
        public HeapSort(OmegaComparison<T> comparator) : this(comparator, Build.Max) { }

        #endregion

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
            //validações
            if (Comparator == null)
                throw new ComparatorNotSetException();
            if (list == null)
                throw new NullObjectException();

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

            PositionData position = new()
            {
                Current = currentPosition,
                Left = leftPosition,
                Right = rightPosition,
                ListLength = listLength,
            };

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

        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 2;
        }

        public void teste()
        {

        }




    }


    public readonly struct PositionData
    {
        public required int Current { get; init; }
        public required int Left { get; init; }
        public required int Right { get; init; }
        public required int ListLength { get; init; }
    }

    public interface IHeapSortBuildStrategy<T>
    {
        Build Build { get; }
        bool CheckLeft(IOmegaList<T> list, OmegaComparison<T> comparator, PositionData positionData);
        bool CheckRight(IOmegaList<T> list, OmegaComparison<T> comparator, PositionData positionData);
    }

    public class HeapSortBuildMinStrategy<T> : IHeapSortBuildStrategy<T>
    {
        public Build Build { get; private set; }

        public HeapSortBuildMinStrategy()
        {
            Build = Build.Min;


        }

        //        if (Operation == Build.Min)
        //{
        //    // leftPosition < position. Verifica se não extrapola os limites do vetor.
        //    // Se o filho esquerdo for maior que o pai é necessário trocar.
        //    if (leftPosition<listLength && Comparator(list[leftPosition], list[currentPosition]) <= 0)
        //        Realocate(list, currentPosition, leftPosition, listLength);

        //    // rightPosition < position. Verifica se não extrapola os limites do vetor.
        //    // Se o filho direito for maior que o pai é necessário trocar.
        //    if (rightPosition<listLength && Comparator(list[rightPosition], list[currentPosition]) <= 0)
        //        Realocate(list, currentPosition, rightPosition, listLength);
        //}

        public bool CheckLeft(IOmegaList<T> list, OmegaComparison<T> comparator, PositionData positionData)
        {
            bool boundaryCheck = positionData.Left < positionData.ListLength;
            bool checkLeftAgainstCurrent = comparator(list[positionData.Left], list[positionData.Current]) <= 0;
            return boundaryCheck && checkLeftAgainstCurrent;
        }

        public bool CheckRight(IOmegaList<T> list, OmegaComparison<T> comparator, PositionData positionData)
        {
            throw new System.NotImplementedException();
        }
    }

    public class HeapSortBuildMaxStrategy<T> 
    {
        public Build Build { get; }

        public HeapSortBuildMaxStrategy()
        {
            Build = Build.Max;
        }

        public bool CheckLeft(IOmegaList<T> list, int currentPosition, int leftPosition, int listLength)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckRight(IOmegaList<T> list, int currentPosition, int rightPosition, int listLength)
        {
            throw new System.NotImplementedException();
        }
    }


    ///// </summary>
    /// <summary>
    /// Indicates whether the heap will be build using the MIN or MAX strategy.
    /// </summary>
    public enum Build { Max, Min };
}
