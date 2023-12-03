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
        /// <para>Time: <b>O(N log N)</b></para>
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

            for (int index = _internalList.Count - 1; index > 0; index--)
            {
                _internalList.Swap(0, index);
                Heapify(0, index);
            }
        }

        /// <summary>
        /// Subroutine used to build the heap. It checks whether parent value is less than its left or right son.
        /// <para>When the son's value is bigger than its parent value they must swap their position</para>
        /// </summary>
        /// <param name="currentPosition">The current position in index.</param>
        /// <param name="indexBoundary">It can be the list size or the upper limit.</param>
        private void Heapify(int currentPosition, int indexBoundary)
        {
            CheckPosition(currentPosition, Left(currentPosition), indexBoundary);
            CheckPosition(currentPosition, Right(currentPosition), indexBoundary);
        }

        private void CheckPosition(int currentPosition, int sonPosition, int indexBoundary)
        {
            if (sonPosition < indexBoundary && CheckCompareResult(Comparator(_internalList[sonPosition], _internalList[currentPosition])))
            {
                Realocate(currentPosition, sonPosition, indexBoundary);
            }
        }


        /// <summary>
        ///  Returns <see langword="true"/> when it should change their position.
        /// </summary>
        /// <param name="x"> The first object to compare.</param>
        /// <param name="y"> The second object to compare.</param>
        /// <returns>
        ///  <para>
        ///  <b>Build Max:</b> A <paramref name="value"/> less than 0 means it should change".
        ///  </para>
        ///  <para>
        ///  <b>Build Min:</b> A <paramref name="value"/> bigger than 0 means it should change".
        ///  </para>
        /// </returns>
        private bool CheckCompareResult(int value)
        {
            return Operation == Build.Min ? value > 0 : value < 0;
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
    /// <para> <b>Max:</b> the biggest value it will be in the first position of the array. Decrescent Order</para>
    /// <para> <b>Min:</b> the smallest value it will be in the first position of the array. Crescent Order</para>
    /// </summary>
    public enum Build { Max, Min };
}
