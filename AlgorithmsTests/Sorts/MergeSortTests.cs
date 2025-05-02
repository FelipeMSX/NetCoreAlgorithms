using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorts;
using Algorithms.Exceptions;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Collections;
using OmegaCore.OmegaLINQ;


namespace AlgorithmsTests.Sorts
{
	[TestClass]
	public class MergeSortTests
	{
        private IOmegaList<int> _listOfNumbers;

        private IOmegaList<int> _expectedCrescentOrder = new OmegaList<int>([-500, -25, 0, 4, 20, 20, 25, 30, 40, 100], true);

        [TestInitialize]
		public void Initialize()
		{
            _listOfNumbers = new OmegaList<int>([100, 40, 20, 30, 4, -500, 0, 20, -25, 25], true);
		}

		[TestMethod]
		[TestCategory("MergeSort"), Timeout(3000)]
		public void Sort_StringList_CrescenteOrderedList()
		{		
            //Arrange
			MergeSort<int> merge = new MergeSort<int>((x,y) => x.CompareTo(y));

            //Act
            merge.Sort(_listOfNumbers);
            //Assert
            CollectionAssert.AreEqual(_expectedCrescentOrder.ToArray(), _listOfNumbers.ToArray());
        }


        [TestMethod, TestCategory("MergeSort"), ExpectedException(typeof(OmegaCore.Exceptions.ArgumentNullException)), Timeout(3000)]
        public void Sort_NullValue_Exception()
        {
            //Arrange
            MergeSort<int> merge = new MergeSort<int>((x, y) => x.CompareTo(y));

            //Act
            merge.Sort(null);

            //Assert
            Assert.Inconclusive();
        }

        [TestMethod, TestCategory("MergeSort"), ExpectedException(typeof(ComparatorNotSetException)), Timeout(3000)]
        public void Sort_EmptyComparator_Exception()
        {
            //Arrange
            MergeSort<int> merge = new MergeSort<int>(null);

            //Act
            merge.Sort(_listOfNumbers);

            //Assert
            Assert.Inconclusive();
        }
    }
}
