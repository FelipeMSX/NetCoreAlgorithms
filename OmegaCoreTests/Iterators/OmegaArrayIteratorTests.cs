using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Abstracts;
using OmegaCore.Iterators;
using OmegaCoreTests.Shared;

namespace OmegaCoreTests.Iterators
{
    [TestClass]
    public class OmegaArrayIteratorTests
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
        public void MoveNext_CustomEnumerator_FiveInterations()
        {
            //Arrange
            int interactions = 0;

            //Act
            foreach (var item in _iterator)
                interactions++;

            //Assert
            Assert.AreEqual(5, interactions, "The amount of expected interactions should be 5");
        }

        [TestMethod]
        public void MoveNext_CustomEnumerator_ExpectedOrder()
        {
            //Act
            bool isInOrder = HelpersTests.CheckArrayOrder(_collection, _iterator);

            //Assert
            Assert.IsTrue(isInOrder, "The order of the collection should be {1,2,3,4,5}. It got something different");
        }

        [TestMethod]
        public void Reset_ResetingCollectionTwoTimes_ExpectedOrder()
        {
            //Act
            bool isInOrder = HelpersTests.CheckArrayOrder(_collection, _iterator);

            if (isInOrder)
            {
                _iterator.Reset();
                isInOrder = HelpersTests.CheckArrayOrder(_collection, _iterator);
            }

            //Assert
            Assert.IsTrue(isInOrder, "The order of the collection should be {1,2,3,4,5}. It got something different");
        }

        [TestMethod]
        public void Reset_ResetingCollectionAndGettingDefaultValue_Zero()
        {
            //Act
            HelpersTests.CheckArrayOrder(_collection, _iterator);
            _iterator.Reset();

            //Assert
            Assert.IsTrue(_iterator.Current == 0, "The Current value should be zero. and I got something different");
        }
    }
}

