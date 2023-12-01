using Algorithms.Exceptions;
using Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;

namespace AlgorithmsTests.Sorts
{
    [TestClass]
    public class HeapSortTests
    {
        private IOmegaList<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new OmegaList<int>(new int[] { 100, 40, 20, 30, 4, -500, 0, 20, -25, 25 });
        } 

        [TestMethod, TestCategory("Heapsort"), Timeout(3000)]
        public void Sort_VectorNumbers_CrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort = new((x, y) => x.CompareTo(y),Build.Max);

            //Act
            heapsort.Sort(list);

            //Assert
            bool isOrdered = true;
            for (int i = 0; i < list.Count -1; i++)
            {
                isOrdered = list[i] <= list[i + 1];
                if (!isOrdered)
                    break;
            }
   

            Assert.IsTrue(isOrdered, "A ordem do vetor deveria estar crescente!");
        }

        [TestMethod, TestCategory("Heapsort"), Timeout(3000)]
        public void Sort_ListNumbers_CrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort  = new((x, y) => x.CompareTo(y), Build.Max);
            OmegaList<int> listNumbers = new(new int[]{ 100, 40, 20, 30, 4, -500, 0, 20, -25, 25 });

            //Act
            heapsort.Sort(listNumbers);

            //Assert
            bool isOrdered = true;
            
            for (int i = 0; i < listNumbers.Count - 1; i++)
            {
                isOrdered = listNumbers[i] <= listNumbers[i + 1];
                if (!isOrdered)
                    break;
            }

            Assert.IsTrue(isOrdered, "A ordem da lista deveria estar crescente!");
        }

        [TestMethod, TestCategory("Heapsort"), Timeout(3000)]
        public void Sort_VectorNumbers_DecrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort = new((x, y) => x.CompareTo(y),Build.Min);

            //Act
            heapsort.Sort(list);

            //Assert
            bool isOrdered = true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                isOrdered = list[i] >= list[i + 1];
                if (!isOrdered)
                    break;
            }
            Assert.IsTrue(isOrdered, "A ordem da lista deveria estar decrescente!");
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
