using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorts;
using Algorithms.Exceptions;

namespace AlgorithmsTests.Sorts
{
	[TestClass]
	public class MergeSortTests
	{
		private int[] vectorInteger;

		[TestInitialize]
		public void Initialize()
		{
			vectorInteger = new int[] { 100,40,20,30,4,500,20,25,25 };
		}

		[TestMethod]
		[TestCategory("MergeSort")]
		public void Sort_StringList_CrescenteOrderedList()
		{		
            //Arrange
			MergeSort<int> merge = new MergeSort<int>((x,y) => x.CompareTo(y));

            //Act
            merge.Sort(vectorInteger);

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


        [TestMethod, TestCategory("MergeSort"), ExpectedException(typeof(NullObjectException))]
        public void Sort_NullValue_Exception()
        {
            //Arrange
            MergeSort<int> merge = new MergeSort<int>((x, y) => x.CompareTo(y));

            //Act
            merge.Sort(null);

            //Assert
            Assert.Inconclusive();
        }

        [TestMethod, TestCategory("MergeSort"), ExpectedException(typeof(ComparerNotSetException))]
        public void Sort_EmptyComparator_Exception()
        {
            //Arrange
            MergeSort<int> merge = new MergeSort<int>(null);

            //Act
            merge.Sort(vectorInteger);

            //Assert
            Assert.Inconclusive();
        }
    }
}
