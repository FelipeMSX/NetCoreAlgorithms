using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Abstracts;
using OmegaCore.Extensions;
using OmegaCore.Iterators;
using System;
using System.Collections.Specialized;

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
            _iterator = new OmegaArrayIterator<int>(_collection);
        }

        [TestCleanup]
        public void TearDown()
        {
            _collection = null!;
            _iterator.Dispose();
        }

        [TestMethod]
        public void IncreaseCapacity_FilledCollection_DoubleCapacity()
        {
            //Act
            _collection = _collection.IncreaseCapacity(_collection.Length * 2);
            //Assert
            Assert.AreEqual(10, _collection.Length, "The expected size should be 10");
        }

        [TestMethod]
        public void Copy_FilledCollection_AllElementsInTheSource()
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


        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Copy_DestinationLengthLesserTheSource_Exception()
        {
            //Act
            int[] destination = new int[2];
            _collection.OmegaCopy(destination);
        }

        [TestMethod]
        public void Copy_CollectionLengthIsZero_Empty()
        {
            //Act
            int[] destination = new int[2];
            _collection = Array.Empty<int>();
            _collection.OmegaCopy(destination);
            //Assert
            Assert.IsTrue(destination[0] == default);
        }

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

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Shift_EmptyCollection_Exception()
        {
            //Arrange
            int[] newCollection = new int[0];
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
    }
}

