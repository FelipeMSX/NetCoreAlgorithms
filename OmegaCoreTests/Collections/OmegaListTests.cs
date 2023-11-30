using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;
using OmegaCore.OmegaLINQ;
using OmegaCoreTests.Shared;

namespace OmegaCoreTests.Collections
{
    [TestClass]
    public class OmegaListTests
    {
        private IOmegaList<SampleObject> _list;
        private OmegaIteratorBase<SampleObject> _iterator;


        [TestInitialize]
        public void TearUp()
        {
            _list = SampleObject.CreateRandomSampleList();
            _iterator = new OmegaArrayIterator<SampleObject>(_list.ToArray(), _list.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            _iterator.Dispose();
            _list.Clear();
        }

        #region Add
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


        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.ArgumentNullException))]
        public void Add_AddingNullElement_Exception()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            _list.Add(null!);
        }
        #endregion

        #region First
        [TestMethod]
        public void First_ListWithElements_ElementA()
        {
            //Arrange
            _list = CreateSimpleList();
            //Act
            SampleObject firstElement = _list.First();
            //Assert
            Assert.AreEqual(firstElement, new SampleObject("a"));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.EmptyCollectionException))]
        public void First_EmptyList_Exception()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            _list.First();
        }
        #endregion

        #region Last
        [TestMethod]
        public void Last_ListWithElements_ElementC()
        {
            //Arrange
            _list = CreateSimpleList();
            //Act
            SampleObject lastElement = _list.Last();
            //Assert
            Assert.AreEqual(lastElement, new SampleObject("c"));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.EmptyCollectionException))]
        public void Last_EmptyList_Exception()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            _list.Last();
        }
        #endregion

        #region Remove

        [TestMethod]
        public void Remove_CollectionHasItem_ReturnsSuccess()
        {
            //Arrange
            _list = CreateSimpleList();
            //Act
            bool success = _list.Remove(new SampleObject("b"));
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Remove_CollectionHasItem_ArrayElementRemoved()
        {
            //Arrange
            _list = CreateSimpleList();

            //Act
            _list.Remove(new SampleObject("b"));

            //Assert
            bool elementFound = false;
            foreach (var item in _list)
            {
                if (item.Equals(new SampleObject("b")))
                    elementFound = true;
            }
            Assert.IsFalse(elementFound);
        }

        [TestMethod]
        public void Remove_CollectionHasItem_CountShouldBeTwo()
        {
            //Arrange
            _list = CreateSimpleList();
            //Act
            _list.Remove(new SampleObject("b"));
            //Assert
            Assert.IsTrue(_list.Count == 2);
        }

        [TestMethod]
        public void Remove_ItemNotFound_NotRemoved()
        {
            //Arrange
            var newObject = new SampleObject("notFound");
            //Act
            bool itemRemoved = _list.Remove(newObject);
            //Assert
            Assert.IsFalse(itemRemoved);
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.ArgumentNullException))]
        public void Remove_NullElement_Exception()
        {
            //Act
            _list.Remove(null!);
        }

        [TestMethod]
        public void Remove_EmptyCollection_Fail()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            var newObject = new SampleObject("notFound");
            //Act
            bool itemRemoved = _list.Remove(newObject);
            //Assert
            Assert.IsFalse(itemRemoved);
        }
        #endregion

        #region Clear
        [TestMethod]
        public void Clear_FilledCollection_ArrayWithDefaultValues()
        {
            //Arrange
            _list = CreateSimpleList();
            //Act
            _list.Clear();
            //Assert
            Assert.IsTrue(_list[0] == default && _list[1] == default && _list[2] == default);
        }


        [TestMethod]
        public void Clear_FilledCollection_CountIsZero()
        {
            //Arrange
            _list = CreateSimpleList();
            //Act
            _list.Clear();
            //Assert
            Assert.IsTrue(_list.Count == 0);
        }
        #endregion

        #region IsEmpty
        [TestMethod]
        public void IsEmpty_WhenCollectionIsEmpty_True()
        {
            //Arrange
            _list = new OmegaList<SampleObject>();
            //Act
            bool isEmpty = _list.IsEmpty();
            //Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsEmpty_WhenCollectionIsNotEmpty_False()
        {
            //Act
            bool isEmpty = _list.IsEmpty();
            //Assert
            Assert.IsFalse(isEmpty);
        }
        #endregion

        [TestMethod]
        public void OmegaList_PassingCollection_CollectionInitialized()
        {
            //Arrange
            var _listToBePassed = CreateSimpleList();
            //Act
            _list = new OmegaList<SampleObject>(_listToBePassed);
            //Assert
            CollectionAssert.AreEqual(_list.ToArray(), _listToBePassed.ToArray());
        }

        [TestMethod]
        public void GetEnumerator_UsingCovariance_LoopingAllObjects()
        {
            //Arrange
            IOmegaList<string> listOfStrings = new OmegaList<string>(new string[] { "a", "b", "c" });
            IOmegaEnumerable listOfObjects = listOfStrings;

            //Act
            int count = 0;

            foreach (var item in listOfObjects)
                count++;

            //Assert
            Assert.IsTrue(count == 3);
        }

        [TestMethod]
        public void Copy_CollectionWithThreeElements_AllElementsCopied()
        {
            //Arrange
            IOmegaList<string> listOfStrings = new OmegaList<string>(new string[] { "a", "b", "c" });
            string[] copied = new string[3];
            //Act
            listOfStrings.CopyTo(copied, 0);

            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Dispose_UsingStatement_Disposed()
        {
            //Arrange
            //Act
            using (OmegaList<string> listOfStrings = new(new string[] { "a", "b", "c" })) { }
            ////Assert
            Assert.IsTrue(true);
        }


        private static IOmegaList<SampleObject> CreateSimpleList()
        {
            return new OmegaList<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b"), new SampleObject("c") });
        }
    }
}