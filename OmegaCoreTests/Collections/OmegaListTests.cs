using System;
using OmegaCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCoreTests.Shared;
using OmegaCore.Abstracts;
using OmegaCore.Iterators;
using OmegaCore.Collections;

namespace OmegaCoreTests.Collections
{
    [TestClass]
    public class OmegaListTests
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
            _list.Clear();
        }

        [TestMethod]
        public void Add_AddingSingleElement_CountEqualsOne()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            _list.Add(new SampleObject("a"));
            //Assert
            Assert.IsTrue(_list.Count == 1);
        }

        [TestMethod]
        public void Add_AddingSingleElement_PickingElement()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            var newObject = new SampleObject("a");
            //Act
            _list.Add(newObject);
            //Assert
            Assert.IsTrue(_list[0].Equals(new SampleObject("a")));
        }

    }
}

