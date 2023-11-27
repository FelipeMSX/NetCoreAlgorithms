using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.OmegaLINQ;
using OmegaCoreTests.Shared;
using System.Collections;
using System.Collections.Generic;

namespace OmegaCoreTests.OmegaLINQ
{
    [TestClass]
    public class OmegaLINQTests
    {

        private IOmegaList<int> _list;

        [TestInitialize]
        public void TearUp()
        {
            _list = new OmegaList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [TestCleanup]
        public void TearDown()
        {
            //Dar dispose;
            _list.Dispose();
        }

        #region First
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void First_WhenFilledCollection_Found(int value)
        {
            //Act
            int result = _list.First((x) => x == value);
            //Assert
            Assert.IsTrue(result == value);
        }

        [TestMethod, ExpectedException(typeof(ElementNotFoundException))]
        public void First_WhenEmptyCollection_Exception()
        {
            //Arrange
            _list = new OmegaList<int>();
            //Act
            _list.First((x) => true);
        }

        [TestMethod, ExpectedException(typeof(ElementNotFoundException))]
        public void First_WhenElementIsNotInTheCollection_Exception()
        {
            //Act
            _list.First((x) => 30 == x);
        }
        #endregion

        #region FirstOrDefault
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void FirstOrDefault_WhenFilledCollection_Found(int value)
        {
            //Act
            int result = _list.FirstOrDefault((x) => x == value);
            //Assert
            Assert.IsTrue(result == value);
        }

        [TestMethod]
        public void FirstOrDefault_WhenEmptyCollection_Zero()
        {
            //Arrange
            _list = new OmegaList<int>();
            //Act
            int result = _list.FirstOrDefault((x) => true);
            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void FirstOrDefault_WhenElementIsNotInTheCollection_Zero()
        {
            //Act
            int result = _list.FirstOrDefault((x) => 30 == x);
            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void FirstOrDefault_WithReferenceObjectAndFullCollection_Found()
        {
            //Arrange
            IOmegaList<string> collection = new OmegaList<string>(new string[3] { "a", "b", "c" });
            //Act
            string? result = collection.FirstOrDefault((x) => x == "c");
            //Assert
            Assert.IsTrue(result == "c");
        }

        [TestMethod]
        public void FirstOrDefault_WithReferenceObjectAndFullCollection_Null()
        {
            //Arrange
            IOmegaList<string> collection = new OmegaList<string>(new string[3] { "a", "b", "c" });
            //Act
            string? result = collection.FirstOrDefault((x) => x == "d");
            //Assert
            Assert.IsTrue(result == null);
        }
        #endregion

        #region Take
        [TestMethod]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(10)]

        public void Take_WhenFilledCollection_Found(int value)
        {
            //Act
            IOmegaEnumerable<int> result = _list.Take(value);
            int itemMatch = 0;

            bool isValid = true;
            foreach (int item in result)
            {
                if (item != _list[itemMatch])
                {
                    isValid = false;
                    break;
                }
                itemMatch++;
            }
            //Assert
            Assert.IsTrue(isValid);
        }
        #endregion

        #region Filter
        [TestMethod]
        public void Filter_WhenFilledCollection_FiveElements()
        {
            //Act
            IOmegaEnumerable<int> result = _list.Filter((x) => x % 2 == 0);
            int count = 0;

            foreach (int item in result)
                count++;
            //Assert
            Assert.IsTrue(count == 5);
        }

        [TestMethod]
        public void Filter_WhenFilledCollectionAndFilterEverything_Empty()
        {
            //Act
            IOmegaEnumerable<int> result = _list.Filter((x) => false);
            int count = 0;

            foreach (int item in result)
                count++;
            //Assert
            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public void Filter_EmptyCollection_Empty()
        {
            //Arrange
            _list = new OmegaList<int>();
            //Act
            IOmegaEnumerable<int> result = _list.Filter((x) => true);
            int count = 0;

            foreach (int item in result)
                count++;

            //Assert
            Assert.IsTrue(count == 0);
        }
        #endregion

        #region Count
        [TestMethod]
        public void Count_WhenFilledCollectionWithPredicate_FiveElements()
        {
            //Act
            int result = _list.Count((x) => x % 2 == 0);
            //Assert
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void Count_EmptyCollectionWithPredicate_Zero()
        {
            //Arrange
            _list = new OmegaList<int>();
            //Act
            int result = _list.Count((x) => x % 2 == 0);
            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void Count_WhenFilledCollectionWithPredicate_TenElements()
        {
            //Act
            int result = _list.Count((x) => true);
            //Assert
            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void Count_EmptyCollection_Zero()
        {
            //Arrange
            _list = new OmegaList<int>();
            //Act
            int result = _list.Count();
            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void Count_WhenFilledCollection_TenElements()
        {
            //Act
            int result = _list.Count();
            //Assert
            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void Count_WithList_Five()
        {
            //Arrange
            IOmegaList<int> list = new OmegaList<int>(new int[] { 1, 2, 3, 4, 5 });
            //Act
            int result = list.Count();
            //Assert
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void Count_WithCollectionType_Five()
        {
            //Arrange
            IOmegaCollection<int> collection = new OmegaCollection();
            //Act
            int result = collection.Count();
            //Assert
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void Count_WithEnumerableType_Five()
        {
            //Arrange
            IOmegaEnumerable<int> enumerable = new OmegaEnumerable();
            //Act
            int result = enumerable.Count();
            //Assert
            Assert.IsTrue(result == 5);
        }

        #endregion

        #region ToArray
        [TestMethod]
        public void ToArray_CopyCollection_AllElementsCopied()
        {
            //Act
            int[] arrayCopied = _list.ToArray();
            //Assert
            bool allNumbersAreEquals = true;
            int count = 0;

            while (count < _list.Count && allNumbersAreEquals)
            {
                if (arrayCopied[count] != _list[count])
                {
                    allNumbersAreEquals = false;
                }
                count++;
            }
            Assert.IsTrue(allNumbersAreEquals);
        }

        [TestMethod]
        public void ToArray_CopyEnumerable_AllElementsCopied()
        {
            //Arrange
            IOmegaEnumerable<int> enumerable = new OmegaEnumerable();

            //Act
            int[] arrayCopied = enumerable.ToArray();
            //Assert
            bool allNumbersAreEquals = true;
            int count = 0;

            foreach (int item in enumerable)
            {
                if (arrayCopied[count] != _list[count])
                {
                    allNumbersAreEquals = false;
                    break;
                }
                count++;
            }

            Assert.IsTrue(allNumbersAreEquals);
        }
        #endregion

        #region Some
        [TestMethod]
        public void Some_WhenFilledCollection_HasElement()
        {
            //Act
            bool hasItem = _list.Some((x) => x % 2 == 0);
            //Assert
            Assert.IsTrue(hasItem);
        }

        [TestMethod]
        public void Some_WhenFilledCollection_False()
        {
            //Act
            bool hasItem = _list.Some((x) => x > 40);
            //Assert
            Assert.IsFalse(hasItem);
        }
        #endregion

        #region ForEach
        [TestMethod]
        public void ForEach_WhenFilledCollection_CountIsTen()
        {
            //Act
            int count = 0;
            _list.ForEach(x => count++);
            //Assert
            Assert.IsTrue(count == 10);
        }

        [TestMethod]
        public void ForEach_WhenFilledCollection_AllElementsAreTheSame()
        {
            //Act
            bool allElementsAreTheSame = true;
            int count = 0;
            _list.ForEach(x => 
            {
                if(_list[count++] != x)
                    allElementsAreTheSame = false;
            });

            //Assert
            Assert.IsTrue(allElementsAreTheSame);
        }
        #endregion

    }
}