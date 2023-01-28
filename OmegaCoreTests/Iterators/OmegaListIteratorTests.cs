using OmegaCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCoreTests.Shared;
using OmegaCore.Abstracts;
using OmegaCore.Iterators;
using OmegaCore.Collections;

namespace OmegaCoreTests.Iterators
{
    [TestClass]
    public class OmegaListIteratorTests
    {

        private IOmegaList<SampleObject> _list;
        private IOmegaIteratorBase<SampleObject> _iterator;

        [TestInitialize]
        public void TearUp()
        {
            _list = SampleObject.CreateSampleList();
            _iterator = new OmegaListIterator<SampleObject>(_list);
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
            bool success = HelpersTests.CheckListOrder(_list, _iterator);
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void MoveNext_IteratingOverEmptyCollection_Success()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            _iterator = new OmegaListIterator<SampleObject>(_list);
            bool success = true;

            //Act   
            while (_iterator.MoveNext() && success)
                success = false;

            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Reset_FilledCollectionIteraveTwoTimes_Success()
        {
            //Act
            bool success = HelpersTests.CheckListOrder(_list, _iterator);
            _iterator.Reset();

            if (!success)
                success = HelpersTests.CheckListOrder(_list, _iterator);

            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Reset_CheckCurrentValueAfterReset_NullValue()
        {
            //Act
            HelpersTests.CheckListOrder(_list, _iterator);
            _iterator.Reset();

            //Assert
            Assert.IsTrue(_iterator.Current == null);
        }
    }
}

