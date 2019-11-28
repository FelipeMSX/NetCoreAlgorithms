using Algorithms.Exceptions;
using Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsTests.Sorts
{
    [TestClass]
    public class HeapSortTests
    {
        private int[] vector;

        [TestInitialize]
        public void Initialize()
        {
            vector = new int[] { 100, 40, 20, 30, 4, -500, 0, 20, -25, 25 };
        } 

        [TestMethod, TestCategory("Heapsort")]
        public void Sort_VectorNumbers_CrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort = new HeapSort<int>((x, y) => x.CompareTo(y),HeapSort<int>.Build.Max);

            //Act
            heapsort.Sort(vector);

            //Assert
            bool isOrdered = true;
            for (int i = 0; i < vector.Length -1; i++)
            {
                isOrdered = vector[i] <= vector[i + 1];
                if (!isOrdered)
                    break;
            }
   

            Assert.IsTrue(isOrdered, "A ordem do vetor deveria estar crescente!");
        }

        [TestMethod, TestCategory("Heapsort")]
        public void Sort_ListNumbers_CrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort  = new HeapSort<int>((x, y) => x.CompareTo(y), HeapSort<int>.Build.Max);
            List<int> listNumbers   = new List<int> { 100, 40, 20, 30, 4, -500, 0, 20, -25, 25 };

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

        [TestMethod, TestCategory("Heapsort")]
        public void Sort_VectorNumbers_DecrescentOrderedList()
        {
            //Arrange
            HeapSort<int> heapsort = new HeapSort<int>((x, y) => x.CompareTo(y), HeapSort<int>.Build.Min);

            //Act
            heapsort.Sort(vector);

            //Assert
            bool isOrdered = true;

            for (int i = 0; i < vector.Length - 1; i++)
            {
                isOrdered = vector[i] >= vector[i + 1];
                if (!isOrdered)
                    break;
            }
            Assert.IsTrue(isOrdered, "A ordem da lista deveria estar decrescente!");
        }


        [TestMethod, TestCategory("Heapsort"), ExpectedException(typeof(NullObjectException))]
        public void Sort_NullValue_Exception()
        {
            //Arrange
            HeapSort<int> heapsort = new HeapSort<int>((x, y) => x.CompareTo(y), HeapSort<int>.Build.Min);

            //Act
            heapsort.Sort(null);

            //Assert
            Assert.Inconclusive();
        }

        [TestMethod, TestCategory("Heapsort"), ExpectedException(typeof(ComparerNotSetException))]
        public void Sort_EmptyComparator_Exception()
        {
            //Arrange
            HeapSort<int> heapsort = new HeapSort<int>(null);

            //Act
            heapsort.Sort(vector);

            //Assert
            Assert.Inconclusive();
        }
    }
}
