using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmegaCoreTests.Iterators
{
    [TestClass]
    public class ArrayIteratorTests
    {

        private int[] _collection;

        [TestInitialize]
        public void TearUp()
        {
            _collection = new int[5] { 1, 2, 3, 4, 5 };
        }

        [TestCleanup]
        public void TearDown()
        {
            _collection = null;
        }

        [TestMethod]
        public void Loop_CustomEnumerator_FiveInterations()
        {
            //Arrange
            int interactions = 0;

            //Act
            foreach (var item in _collection)
            {
                interactions++;
            }

            //Assert
            Assert.AreEqual(5, interactions, "The amount of expected interactions should be 5");
        }

        [TestMethod]
        public void Loop_CustomEnumerator_ExpectedOrder()
        {
            //Arrange
            bool isInOrder= true;
            int count = 0;

            //Act
            foreach (var item in _collection)
            {
                if(item != _collection[count++])
                {
                    isInOrder = false;
                    break;
                }
            }

            //Assert
            Assert.IsTrue(isInOrder, "The order of the collection should be {1,2,3,4,5}. It got something different");
        }
    }
}

