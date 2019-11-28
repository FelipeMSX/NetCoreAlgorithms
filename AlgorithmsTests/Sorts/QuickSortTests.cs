using Algorithms.Exceptions;
using Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmsTests.Sorts
{
    [TestClass]
	public class QuickSortTests
	{
        private int[] vectorInteger;
        [TestInitialize]
        public void Initialize()
        {
            vectorInteger = new int[] { 100,-10, 40, 20, 30, 4, 500, 20, 25, 25, -20 };
        }

        [TestMethod]
        [TestCategory("QuickSort")]
        public void Sort_StringList_CrescenteOrderedList()
        {
            //Arrange
            QuickSort<int> quickSort = new QuickSort<int>((x, y) => x.CompareTo(y));

            //Act
            quickSort.Sort(vectorInteger);

            //Assert
            bool isOrdered = true;
            for (int i = 0; i < vectorInteger.Length - 1; i++)
            {
                isOrdered = vectorInteger[i].CompareTo(vectorInteger[i + 1]) <= 0;
                if (!isOrdered)
                    break;
            }

            Assert.IsTrue(isOrdered, "A ordem da lista deveria estar crescente!");
        }

        [TestMethod, TestCategory("QuickSort"), ExpectedException(typeof(NullObjectException))]
        public void Sort_NullValue_Exception()
        {
            //Arrange
            QuickSort<int> quicksort = new QuickSort<int>((x, y) => x.CompareTo(y));

            //Act
            quicksort.Sort(null);

            //Assert
            Assert.Inconclusive();
        }

        [TestMethod, TestCategory("QuickSort"), ExpectedException(typeof(ComparerNotSetException))]
        public void Sort_EmptyComparator_Exception()
        {
            //Arrange
            QuickSort<int> quicksort = new QuickSort<int>(null);

            //Act
            quicksort.Sort(vectorInteger);

            //Assert
            Assert.Inconclusive();
        }
    }
}
