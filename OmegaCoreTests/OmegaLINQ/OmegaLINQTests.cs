using Microsoft.VisualStudio.TestTools.UnitTesting;
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private IOmegaList<int> _enumerableCollection;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void TearUp()
        {

            _enumerableCollection = new SimpleList<int>(new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [TestCleanup]
        public void TearDown()
        {
            //Dar dispose;
            _enumerableCollection = null;
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
            _enumerableCollection = new SimpleList<int>();
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
            _enumerableCollection = new SimpleList<int>();
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
            IOmegaList<string> collection = new SimpleList<string>(new string[3] { "a", "b", "c" });
            //Act
            string? result = collection.FirstOrDefault((x) => x == "c");
            //Assert
            Assert.IsTrue(result == "c");
        }

        [TestMethod]
        public void FirstOrDefault_WithReferenceObjectAndFullCollection_Null()
        {
            //Arrange
            IOmegaList<string> collection = new SimpleList<string>(new string[3] { "a", "b", "c" });
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
            IEnumerable<int> result = _enumerableCollection.Take(value);
            int count = 0;

            bool isValid = true;
            foreach (int item in result)
            {
                if (item != _enumerableCollection[count++])
                {
                    isValid = false;
                    break;
                }
            }
            //Assert
            Assert.IsTrue(isValid);
        }
        #endregion
    }
}

