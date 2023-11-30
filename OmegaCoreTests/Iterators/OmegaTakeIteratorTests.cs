using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCoreTests.Shared;
using OmegaCore.Iterators;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;

namespace OmegaCoreTests.Iterators
{
    [TestClass]
    public class OmegaTakeIteratorTests
    {

        private IOmegaList<SampleObject> _list;
        private OmegaIteratorBase<SampleObject> _iterator;

        [TestInitialize]
        public void TearUp()
        {
            _list = SampleObject.CreateRandomSampleList();
            _iterator = new OmegaTakeIterator<SampleObject>(_list,10);
        }

        [TestCleanup]
        public void TearDown()
        {
            _iterator.Dispose();
            _list.Dispose();
        }

        [TestMethod]
        public void MoveNext_WithFilledCollection_AllElementsReturned()
        {
            //Act
            bool success = HelpersTests.CheckListOrderOverIterator(_list, _iterator);
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void MoveNext_IteratingOverEmptyCollection_Success()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            _iterator = new OmegaTakeIterator<SampleObject>(_list,0);
            bool success = true;

            //Act   
            while (_iterator.MoveNext() && success)
                success = false;

            //Assert
            Assert.IsTrue(success);
        }


        [TestMethod,Timeout(10000)]
        public void MoveNext_IteratingUntilTheEnd_Success()
        {
            //Arrange
            _list = SampleObject.CreateRandomSampleList();
            _iterator = new OmegaTakeIterator<SampleObject>(_list, 9999999);
            //Act   
            while (_iterator.MoveNext())
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Reset_FilledCollectionIteraveTwoTimes_Success()
        {
            //Act
            bool success = CheckListOrder(_list, _iterator,10);
            _iterator.Reset();

            if (!success)
                success = CheckListOrder(_list, _iterator,10);

            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Reset_CheckCurrentValueAfterReset_NullValue()
        {
            //Act
            CheckListOrder(_list, _iterator, 10);
            _iterator.Reset();

            //Assert
            Assert.IsTrue(_iterator.Current == null);
        }

        private static bool CheckListOrder<T>(IOmegaList<T> list, OmegaIteratorBase<T> iterator, int expectedCount)
        {
            bool isInOrder = true;
            int index = 0;
            int count = expectedCount;

            while (iterator.MoveNext() && isInOrder)
            {
                if (!list[index++]!.Equals(iterator.Current))
                    isInOrder = false;

                count--;
            }

            if (count > 0)
                return false;

            return isInOrder;
        }
    }
}

