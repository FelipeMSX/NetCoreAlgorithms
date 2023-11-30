using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCoreTests.Shared;
using OmegaCore.Iterators;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;

namespace OmegaCoreTests.Iterators
{
    [TestClass]
    public class OmegaPredicateIteratorTests
    {

        private IOmegaList<SampleObject> _list;
        private OmegaIteratorBase<SampleObject> _iterator;

        private readonly Func<SampleObject, bool> _predicate = (sampleObject) => int.TryParse(sampleObject.Name, out int numericValue);


        [TestInitialize]
        public void TearUp()
        {
            _list = SampleObject.CreateRandomSampleList();
            _iterator = new OmegaPredicateIterator<SampleObject>(_list, _predicate);
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
            _list = new OmegaList<SampleObject>();
            _iterator = new OmegaPredicateIterator<SampleObject>(_list, (x) => true);

            bool success = HelpersTests.CheckListOrderOverIterator(_list, _iterator);
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void MoveNext_IteratingOverEmptyCollection_Success()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            _iterator = new OmegaPredicateIterator<SampleObject>(_list, _predicate);
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
            bool success = CheckNumbers(_iterator);
            _iterator.Reset();

            if (!success)
                success = CheckNumbers(_iterator);

            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Reset_CheckCurrentValueAfterReset_NullValue()
        {
            //Act
            CheckNumbers(_iterator);
            _iterator.Reset();

            //Assert
            Assert.IsTrue(_iterator.Current == null);
        }

        private bool CheckNumbers<T>(OmegaIteratorBase<T> iterator) where T : SampleObject
        {
            bool success = true;

            while (iterator.MoveNext() && success)
                int.Parse(iterator.Current.Name);

            return success;
        }
    }
}

