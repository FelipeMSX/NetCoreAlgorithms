using System;
using OmegaCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCoreTests.Shared;
using OmegaCore.Abstracts;
using OmegaCore.Iterators;
using OmegaCore.Collections;
using OmegaCore.Exceptions;

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


        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void Add_AddingNullElement_Exception()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            _list.Add(null!);
        }

        [TestMethod]
        public void First_ListWithElements_ElementA()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            var newObjectA = new SampleObject("a");
            var newObjectB = new SampleObject("b");
            var newObjectC = new SampleObject("C");
            _list.Add(newObjectA);
            _list.Add(newObjectB);
            _list.Add(newObjectC);
            //Act
            SampleObject firstElement  = _list.First();
            //Assert
            Assert.AreEqual(firstElement, newObjectA);
        }

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
        public void First_EmptyList_Exception()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
           _list.First();
        }

        [TestMethod]
        public void Last_ListWithElements_ElementC()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            var newObjectA = new SampleObject("a");
            var newObjectB = new SampleObject("b");
            var newObjectC = new SampleObject("C");
            _list.Add(newObjectA);
            _list.Add(newObjectB);
            _list.Add(newObjectC);
            //Act
            SampleObject lastElement = _list.Last();
            //Assert
            Assert.AreEqual(lastElement, newObjectC);
        }

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
        public void Last_EmptyList_Exception()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            _list.Last();
        }
    }
}

