using Algorithms.Exceptions;
using Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Iterators;
using OmegaCore.OmegaLINQ;

namespace AlgorithmsTests.Sorts
{
    [TestClass]
    public class HeapSortTests
    {
        private IOmegaList<int> list;

        private IOmegaList<int> expectedCrescentOrder = new OmegaList<int>(new int[] { -500, -25, 0, 4, 20, 20, 25, 30, 40, 100 }, true);
        private IOmegaList<int> expectedDecrescentOrder = new OmegaList<int>(new int[] { 100, 40, 30, 25, 20, 20, 4, 0, -25, -500 }, true);


        [TestInitialize]
        public void TearUp()
        {
            list = new OmegaList<int>(new int[] { 100, 40, 20, 30, 4, -500, 0, 20, -25, 25 }, true);
        }

        [TestCleanup]
        public void TearDown()
        {
            list.Clear();
        }

        [TestMethod, TestCategory("Heapsort"), Timeout(3000)]
        public void Sort_VectorNumbers_CrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort = new((x, y) => x.CompareTo(y), Build.Min);

            //Act
            heapsort.Sort(list);

            //Assert
            CollectionAssert.AreEqual(expectedCrescentOrder.ToArray(), list.ToArray());
        }

        [TestMethod, TestCategory("Heapsort"), Timeout(3000)]
        public void Sort_ListNumbers_CrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort = new((x, y) => x.CompareTo(y));

            //Act
            heapsort.Sort(list);

            //Assert
            CollectionAssert.AreEqual(expectedDecrescentOrder.ToArray(), list.ToArray());
        }


        [TestMethod, TestCategory("Heapsort"), ExpectedException(typeof(OmegaCore.Exceptions.ArgumentNullException)), Timeout(3000)]
        public void Sort_NullValue_Exception()
        {
            //Arrange
            HeapSort<int> heapsort = new((x, y) => x.CompareTo(y), Build.Min);

            //Act
            heapsort.Sort(null);

            //Assert
            Assert.Inconclusive();
        }

        [TestMethod, TestCategory("Heapsort"), ExpectedException(typeof(ComparatorNotSetException)), Timeout(3000)]
        public void Sort_EmptyComparator_Exception()
        {
            //Arrange
            HeapSort<int> heapsort = new(null);

            //Act
            heapsort.Sort(list);

            //Assert
            Assert.Inconclusive();
        }
    }
}
