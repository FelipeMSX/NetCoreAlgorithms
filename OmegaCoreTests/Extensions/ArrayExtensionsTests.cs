using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Abstracts;
using OmegaCore.Extensions;
using OmegaCore.Iterators;
using OmegaCoreTests.Shared;
using System;

namespace OmegaCoreTests.Extensions
{
    [TestClass]
    public class ArrayExtensionsTests
    {

        private int[] _collection;
        private IOmegaIteratorBase<int> _iterator;


        [TestInitialize]
        public void TearUp()
        {
            _collection = new int[5] { 1, 2, 3, 4, 5 };
            _iterator = new OmegaArrayIterator<int>(_collection, 5);
        }

        [TestCleanup]
        public void TearDown()
        {
            _collection = null!;
            _iterator.Dispose();
        }

        #region IncreaseCapacity
        [TestMethod]
        public void IncreaseCapacity_FilledCollection_DoubleCapacity()
        {
            //Act
            _collection = _collection.IncreaseCapacity(_collection.Length * 2);
            //Assert
            Assert.AreEqual(10, _collection.Length, "The expected size should be 10");
        }

        [TestMethod]
        public void IncreaseCapacity_FilledCollection_AllElementsInTheSource()
        {
            //Act
            int[] newCollection = _collection.IncreaseCapacity(_collection.Length * 2);

            bool success = true;
            int count = 0;
            while (success && count < _collection.Length)
            {
                if (!newCollection[count].Equals(_collection[count]))
                    success = false;

                count++;
            }
            //Assert
            Assert.IsTrue(success, "All elements should be in the new collection, but for some reason it wasn't");
        }
        #endregion

        #region OmegaCopy  

        [TestMethod]
        public void OmegaCopy_CopyCollection_AllElementsCopied()
        {
            //Act
            int[] newCollection = new int[_collection.Length];
            _collection.OmegaCopy(newCollection, 0, _collection.Length - 1);

            bool allElementsFound = true;
            int count = 0;
            while (allElementsFound && count < _collection.Length)
            {
                if (!newCollection[count].Equals(_collection[count]))
                    allElementsFound = false;

                count++;
            }
            //Assert
            Assert.IsTrue(allElementsFound, "All elements should be in the new collection, but for some reason it wasn't");
        }

        [TestMethod]
        public void OmegaCopy_CopyTheLastItem_TwoElementsCopied()
        {
            //Arrange
            int[] newCollection = new int[_collection.Length];
            //Act
            _collection.OmegaCopy(newCollection, 0, _collection.Length - 1);
            //Assert
            Assert.IsTrue((newCollection[_collection.Length - 1] == 5), "The element should be 5");
        }

        [TestMethod]
        public void OmegaCopy_CopyWithStartIndexElementAndCheckingDefaultValue_DefaultValue()
        {
            //Arrange
            int[] newCollection = new int[_collection.Length];
            //Act
            _collection.OmegaCopy(newCollection, 1, _collection.Length - 1);
            //Assert
            Assert.IsTrue((newCollection[0] == default), "The element should be default");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void OmegaCopy_DestinationLengthLesserTheSource_Exception()
        {
            //Arrange
            int[] destination = new int[2];
            //Act
            _collection.OmegaCopy(destination, 0, _collection.Length);
        }
        #endregion

        #region Shift
        [TestMethod]
        public void Shift_ShiftingUntilTheEnd_AllElementsShifted()
        {
            //Act
            _collection.Shift(0);
            //Assert
            Assert.IsTrue(_collection[0] == 2 && _collection[1] == 3 && _collection[2] == 4 && _collection[3] == 5);
        }

        [TestMethod]
        public void Shift_ShiftingUntilTheEnd_TheLastElementIsDefault()
        {
            //Act
            _collection.Shift(0, _collection.Length - 1);
            //Assert
            Assert.IsTrue(_collection[4] == default);
        }

        [TestMethod]
        public void Shift_CollectionWithOneElement_Exception()
        {
            //Arrange
            int[] newCollection = new int[1] { 1 };
            //Act
            newCollection.Shift(0, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Shift_CollectionSizeIsLesserThanInitIntervals_Exception()
        {
            //Act
            _collection.Shift(6, 8);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Shift_CollectionSizeIsLesserThanEndIntervals_Exception()
        {
            //Act
            _collection.Shift(2, 6);
        }
        #endregion

        #region Clear
        [TestMethod]
        public void Clear_WithCollectionLength_AllValuesAreDefault()
        {
            //Act
            _collection.Clear();

            bool isValid = true;
            int count = 0;

            while (isValid && count < _collection.Length)
                isValid = _collection[count++] == default;

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Clear_WithSpecifiedSize_TwoElementsCleared()
        {
            //Act
            _collection.Clear(2);

            bool isValid = true;
            int count = 0;

            while (isValid && count < 2)
                isValid = _collection[count++] == default;

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Clear_NegativeValue_NothingHappens()
        {
            //Act
            _collection.Clear(-1);
            //Assert
            Assert.IsTrue(_collection[0] == 1);
        }
        #endregion

        #region IndexOf
        [TestMethod]
        public void IndexOf_FilledCollection_LastElementIndex()
        {
            //Act
            int indexOfItem = _collection.IndexOf(5);
            //Assert
            Assert.IsTrue(indexOfItem == 4);
        }

        [TestMethod]
        public void IndexOf_FilledCollection_FirstElementIndex()
        {
            //Act
            int indexOfItem = _collection.IndexOf(1);
            //Assert
            Assert.IsTrue(indexOfItem == 0);
        }

        [TestMethod]
        public void IndexOf_FilledCollection_ItemNotFound()
        {
            //Act
            int indexOfItem = _collection.IndexOf(10);
            //Assert
            Assert.IsTrue(indexOfItem == -1);
        }

        [TestMethod]
        public void IndexOf_EmptyCollection_ItemNotFound()
        {
            //Act
            int indexOfItem = _collection.IndexOf(10);
            //Assert
            Assert.IsTrue(indexOfItem == -1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void IndexOf_NullValue_Exception()
        {
            string[] stringCollection = new string[4] { "a", "b", "c", "d" };
            //Act
            stringCollection.IndexOf(null);
        }
        #endregion

        #region Swap
        [TestMethod]
        public void Swap_SwappingItemFiveAndItemOne_Swapped()
        {
            //Act
            _collection.Swap(0, 4);
            //Assert
            Assert.IsTrue(_collection[0] == 5 && _collection[4] == 1);
        }
        #endregion

        #region Reverse

        [TestMethod]
        public void Reserve_WhenArrayIsOdd_Reversed()
        {
            int[] expectedOrder = new int[5] { 5, 4, 3, 2, 1 };
            //Act
            _collection.Reverse();
            //Assert
            Assert.IsTrue(HelpersTests.CheckArrayOverArray(expectedOrder, _collection));
        }

        [TestMethod]
        public void Reserve_WhenArrayIsEven_Reversed()
        {
            //Arrange
            _collection = new int[4] { 1, 2, 3, 4 };
            int[] expectedOrder = new int[4] { 4, 3, 2, 1 };
            //Act
            _collection.Reverse();
            //Assert
            Assert.IsTrue(HelpersTests.CheckArrayOverArray(expectedOrder, _collection));
        }

        [TestMethod]
        public void Reserve_WithCount_Reversed()
        {
            //Arrange
            int[] expectedOrder = new int[5] { 3, 2, 1, 4, 5 };
            //Act
            _collection.Reverse(3);
            //Assert
            Assert.IsTrue(HelpersTests.CheckArrayOverArray(expectedOrder, _collection));
        }
        #endregion
    }
}

