using System;
using OmegaCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCoreTests.Shared;
using OmegaCore.Abstracts;
using OmegaCore.Iterators;
using OmegaCore.Collections;
using OmegaCore.Exceptions;
using NSubstitute;
using OmegaCore.Extensions;
using NSubstitute.ClearExtensions;


namespace OmegaCoreTests.Collections
{
    [TestClass]
    public class OmegaListTests
    {

        private IOmegaList<SampleObject> _list;
        private IOmegaIteratorBase<SampleObject> _iterator;
        private IArrayExtensions _defaultInstance;

        public OmegaListTests()
        {
            _defaultInstance = ArrayExtensions.Instance;
        }

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
            ArrayExtensions.Instance = _defaultInstance;
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


        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
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

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
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

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
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
            var _arrayExtensions = CreateMockForRemoveMethod();
            //Act
            bool success = _list.Remove(new SampleObject("b"));
            _arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Remove_CollectionHasItem_ArrayElementRemoved()
        {
            //Arrange
            _list = CreateSimpleList();
            var _arrayExtensions = CreateMockForRemoveMethod();

            //Act
            _list.Remove(new SampleObject("b"));
            _arrayExtensions.ClearSubstitute();

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
            var _arrayExtensions = CreateMockForRemoveMethod();
            //Act
            _list.Remove(new SampleObject("b"));
            _arrayExtensions.ClearSubstitute();
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

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
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

            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.Clear(Arg.Any<SampleObject[]>(), Arg.Any<int>())).Do(x =>
            {
                SampleObject[] source = x.ArgAt<SampleObject[]>(0);
                source[0] = default!;
                source[1] = default!;
                source[2] = default!;
            });

            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            _list.Clear();
            _arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(_list[0] == default && _list[1] == default && _list[2] == default);
        }


        [TestMethod]
        public void Clear_FilledCollection_CountIsZero()
        {
            //Arrange
            _list = CreateSimpleList();

            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.Clear(Arg.Any<SampleObject[]>(), Arg.Any<int>())).Do(x =>
            {
                SampleObject[] source = x.ArgAt<SampleObject[]>(0);
                source[0] = default!;
                source[1] = default!;
                source[2] = default!;
            });

            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            _list.Clear();
            _arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(_list.Count == 0);
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
            bool hasItems = true;

            foreach (var item in _list)
            {
                if (!item.Equals(new SampleObject("a")) && !item.Equals(new SampleObject("b")) && !item.Equals(new SampleObject("c")))
                    hasItems = false;
            }

            Assert.IsTrue(hasItems);
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

            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.OmegaCopy(Arg.Any<string[]>(), Arg.Any<string[]>(), Arg.Any<int>())).Do(x =>
            {
                string[] source = x.ArgAt<string[]>(0);
                string[] destination = x.ArgAt<string[]>(1);
                destination[0] = source[0];
                destination[1] = source[1];
                destination[2] = source[2];
            });
            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            listOfStrings.CopyTo(copied, 3);
            _arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(copied[0] == listOfStrings[0] && copied[1] == listOfStrings[1] && copied[2] == listOfStrings[2]);
        }

        private static IArrayExtensions CreateMockForRemoveMethod()
        {
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.IndexOf(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject>()).Returns(1);
            _arrayExtensions.When(x => x.Shift(Arg.Any<SampleObject[]>(), Arg.Any<int>(), Arg.Any<int>())).Do(x =>
            {
                SampleObject[] source = x.Arg<SampleObject[]>();
                source[1] = source[2];
                source[2] = default!;
            });

            ArrayExtensions.Instance = _arrayExtensions;

            return _arrayExtensions;
        }

        private static IOmegaList<SampleObject> CreateSimpleList()
        {
            return new OmegaList<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b"), new SampleObject("c") });
        }
    }
}