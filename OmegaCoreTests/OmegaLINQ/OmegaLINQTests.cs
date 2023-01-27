﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Collections;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.OmegaLINQ;
using OmegaCoreTests.Shared;
using System.Collections.Generic;

namespace OmegaCoreTests.OmegaLINQ
{
    [TestClass]
    public class OmegaLINQTests
    {

        private IOmegaList<int> _enumerableCollection;

        [TestInitialize]
        public void TearUp()
        {
            _enumerableCollection = new OmegaList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [TestCleanup]
        public void TearDown()
        {
            //Dar dispose;
            _enumerableCollection.Dispose();
        }

        #region First
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void First_WhenFilledCollection_Found(int value)
        {
            //Act
            int result = _enumerableCollection.First((x) => x == value);
            //Assert
            Assert.IsTrue(result == value);
        }

        [TestMethod, ExpectedException(typeof(ElementNotFoundException))]
        public void First_WhenEmptyCollection_Exception()
        {
            //Arrange
            _enumerableCollection = new OmegaList<int>();
            //Act
            _enumerableCollection.First((x) => true);
        }

        [TestMethod, ExpectedException(typeof(ElementNotFoundException))]
        public void First_WhenElementIsNotInTheCollection_Exception()
        {
            //Act
            _enumerableCollection.First((x) => 30 == x);
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
            int result = _enumerableCollection.FirstOrDefault((x) => x == value);
            //Assert
            Assert.IsTrue(result == value);
        }

        [TestMethod]
        public void FirstOrDefault_WhenEmptyCollection_Zero()
        {
            //Arrange
            _enumerableCollection = new OmegaList<int>();
            //Act
            int result = _enumerableCollection.FirstOrDefault((x) => true);
            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void FirstOrDefault_WhenElementIsNotInTheCollection_Zero()
        {
            //Act
            int result = _enumerableCollection.FirstOrDefault((x) => 30 == x);
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
        [DataRow(3)]
        public void Take_WhenFilledCollection_Found(int value)
        {
            //Act
            IOmegaEnumerable<int> result = _enumerableCollection.Take(value);
            int itemMatch = 0;

            bool isValid = true;
            foreach (int item in result)
            {
                if (item != _enumerableCollection[itemMatch])
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
            IOmegaEnumerable<int> result = _enumerableCollection.Filter((x) => x % 2 == 0);
            int count = 0;

            foreach (int item in result)
            {
                count++;
            }
            //Assert
            Assert.IsTrue(count == 5);
        }
        #endregion

        #region Count
        [TestMethod]
        public void Count_WhenFilledCollectionWithPredicate_FiveElements()
        {
            //Act
            int result = _enumerableCollection.Count((x) => x % 2 == 0);

            //Assert
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void Count_EmptyCollectionWithPredicate_Zero()
        {
            //Arrange
            _enumerableCollection = new OmegaList<int>();
            //Act
            int result = _enumerableCollection.Count((x) => x % 2 == 0);

            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void Count_WhenFilledCollectionWithPredicate_TenElements()
        {
            //Act
            int result = _enumerableCollection.Count((x) => true);

            //Assert
            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void Count_EmptyCollection_Zero()
        {
            //Arrange
            _enumerableCollection = new OmegaList<int>();
            //Act
            int result = _enumerableCollection.Count();

            //Assert
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void Count_WhenFilledCollection_TenElements()
        {
            //Act
            int result = _enumerableCollection.Count();

            //Assert
            Assert.IsTrue(result == 10);
        }
        #endregion
    }
}

