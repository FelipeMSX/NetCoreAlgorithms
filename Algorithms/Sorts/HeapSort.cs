using Algorithms.Exceptions;
using Algorithms.Interfaces;
using OmegaCore.Collections.Interfaces;

namespace Algorithms.Sorts
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class HeapSort<T> : IOmegaComparator<T>, ISortable<T>
    {
        public OmegaComparison<T> Comparator { get; set; }

        /// <summary>
        /// The current build strategy of the heap.
        /// </summary>
        public Build Operation { get; }

        private IOmegaList<T> _internalList;

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

            _internalList = list;
            Heapsort();
        }

        private void Heapsort()
        {
            BuildHeap(_internalList.Count);

            for (int i = _internalList.Count - 1; i > 0; i--)
            {
                _internalList.Swap(0, i);
                Heapify(0, i);
            }
        }

        /// <summary>
        /// Sub-rotina utilizada para construiro heapMin. Vefirificando se o nó pai possui filhos maiores que ele.
        /// Caso o pai tenha filho com nó maior é necessário efetuar a troca.
        /// </summary>
        /// <param name="currentPosition">The current position in index.</param>
        /// <param name="listLength">It can be the list size or the upper limit.</param>
        private void Heapify(int currentPosition, int listLength)
        {
            int leftPosition = Left(currentPosition);
            int rightPosition = Right(currentPosition);

            // leftPosition < position. Verifica se não extrapola os limites do vetor.
            // Se o filho esquerdo for maior que o pai é necessário trocar.
            if (leftPosition < listLength && CheckCompareResult(Comparator(_internalList[leftPosition], _internalList[currentPosition])))
                Realocate(currentPosition, leftPosition, listLength);

            // rightPosition < position. Verifica se não extrapola os limites do vetor.
            // Se o filho direito for maior que o pai é necessário trocar.
            if (rightPosition < listLength && CheckCompareResult(Comparator(_internalList[rightPosition], _internalList[currentPosition])))
                Realocate(currentPosition, rightPosition, listLength);

        }

        private bool CheckCompareResult(int compareResult)
        {
            return Operation == Build.Min ? compareResult <= 0 : compareResult >= 0;
        }

        /// <summary>
        /// Changes two elements in the list and call Heapify again to continue the process.
        /// </summary>
        private void Realocate(int currentPosition, int swapPosition, int listLength)
        {
            _internalList.Swap(currentPosition, swapPosition);
            Heapify(swapPosition, listLength);
        }

        /// <summary>
        /// Only called in the beginning  to start all the sort process.
        /// </summary>
		private void BuildHeap(int listLength)
        {
            for (int i = (listLength / 2) - 1; i >= 0; i--)
                Heapify(i, listLength);
        }

        /// <summary>
        /// Based on the <paramref name="position"/> calculates its left son.
        /// </summary>
        /// <returns>Returns the position of the left son in the array</returns>
        private static int Left(int position)
        {
            return 2 * position + 1;
        }

        /// <summary>
        /// Based on the <paramref name="position"/> calculates its right son.
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
