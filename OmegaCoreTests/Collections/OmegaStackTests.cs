using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.ArrayUtils;
using OmegaCore.Interfaces;
using OmegaCore.OmegaLINQ;
using OmegaCoreTests.Shared;
using System.Linq;

namespace OmegaCoreTests.Collections
{
    [TestClass]
    public class OmegaStackTests
    {

        private IOmegaStack<SampleObject> _stack;

        [TestInitialize]
        public void TearUp()
        {
            _stack = CreateSimpleStack();
        }

        [TestCleanup]
        public void TearDown()
        {
            _stack.Dispose();
        }

        #region Push
        [TestMethod]
        public void Push_AddingSingleElement_CountEqualsOne()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            //Act
            _stack.Push(new SampleObject("a"));
            //Assert
            Assert.IsTrue(_stack.Count == 1);
        }

        [TestMethod]
        public void Push_AddingSingleElement_ElementIsFound()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            //Act
            _stack.Push(new SampleObject("a"));
            //Assert
            Assert.IsTrue(_stack[0].Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.ArgumentNullException))]
        public void Push_AddingNullElement_Exception()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            //Act
            _stack.Push(null!);
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.FullCollectionException))]
        public void Push_AddingElementToFullCollectionNotResizable_Exception()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>(1, false);
            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));
        }

        [TestMethod]
        public void Push_AddingElementToFullCollectionResizable_ElementsInStack()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>(1, true);

            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));

            //Assert
            Assert.IsTrue(_stack[0].Equals(new SampleObject("a")) && _stack[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void Push_AddingElementToFullCollectionResizable_CountIsTwo()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>(1, true);

            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));

            //Assert
            Assert.IsTrue(_stack.Count == 2);
        }

        [TestMethod]
        public void Push_AddingElementToFullCollectionResizable_MaxCapacityIsTwo()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>(1, true);
            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));

            //Assert
            Assert.IsTrue(_stack.MaxCapacity == 2);
        }

        #endregion

        #region Pop

        [TestMethod]
        public void Pop_PoppingAllElements_CountIsZero()
        {
            //Arrange
            _stack = CreateSimpleStack();
            //Act
            _stack.Pop();
            //Assert
            Assert.IsTrue(_stack.Count == 0);
        }

        [TestMethod]
        public void Pop_PoppingAllElements_ElementsAreNull()
        {
            //Arrange
            _stack = CreateSimpleStack();
            //Act
            _stack.Pop();
            //Assert
            Assert.IsNull(_stack[0]);
        }

        [TestMethod]
        public void Pop_TwoElementsInStack_ElementRemoved()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));
            //Act
            var value = _stack.Pop();
            //Assert
            Assert.IsTrue(value.Equals(new SampleObject("b")));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.EmptyCollectionException))]
        public void Pop_EmptyColllection_Exception()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            //Act
            _stack.Pop();

        }
        #endregion

        #region Peek
        [TestMethod]
        public void Peek_WithOneElement_ElementPeeked()
        {
            //Act
            var value = _stack.Peek();
            //Assert
            Assert.IsTrue(value.Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.EmptyCollectionException))]
        public void Peek_EmptyColllection_Exception()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            //Act
            _stack.Peek();

        }
        #endregion

        #region CopyTo

        [TestMethod]
        public void CopyTo_TwoElementsInStack_AllElementsCopied()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));
            SampleObject[] newArray = new SampleObject[2];

            SampleObject[] expectedOrder = new SampleObject[2] { new SampleObject("b") , new SampleObject("a") };

            //Act
            _stack.CopyTo(newArray, 0);
            //Assert
            CollectionAssert.AreEqual(newArray, expectedOrder);
        }
        #endregion

        #region Constructos
        [TestMethod]
        public void OmegaStack_PassingCollection_ArrayCopied()
        {
            var arrayOfSamples = new SampleObject[] { new SampleObject("a"), new SampleObject("b") };
            var expectedOrder = new SampleObject[2] { new SampleObject("b"), new SampleObject("a") };

            //Arrange
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(
                arrayOfSamples);
            //Act
            _stack = new OmegaStack<SampleObject>(collection);
            //Assert
            CollectionAssert.AreEqual(_stack.ToArray(), expectedOrder);
        }

        [TestMethod]
        public void OmegaStack_PassingCollection_CountIsTwo()
        {
            //Arrange
            var arrayOfSamples = new SampleObject[] { new SampleObject("a"), new SampleObject("b") };

            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(arrayOfSamples);
            //Act
            _stack = new OmegaStack<SampleObject>(collection);
            //Assert
            Assert.IsTrue(_stack.Count == 2);
        }

        [TestMethod]
        public void OmegaStack_PassingArray_ArrayCopied()
        {
            //Arrange
            var arrayOfSamples = new SampleObject[] { new SampleObject("a"), new SampleObject("b") };
            var expectedOrder = new SampleObject[2] { new SampleObject("b"), new SampleObject("a") };
            //Act
            _stack = new OmegaStack<SampleObject>(arrayOfSamples);
            //Assert
            CollectionAssert.AreEqual(_stack.ToArray(), expectedOrder);
        }

        [TestMethod]
        public void OmegaStack_PassingArray_CountIsTwo()
        {
            //Arrange
            //Act
            _stack = new OmegaStack<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Assert
            Assert.IsTrue(_stack.Count == 2);
        }
        #endregion

        [TestMethod]
        public void GetEnumerator_UsingCovariance_ElementsInOrderCBA()
        {
            //Arrange
            IOmegaStack<string> stackOfStrings = new OmegaStack<string>(new string[] { "a", "b", "c" });
            IOmegaEnumerable listOfObjects = stackOfStrings;

            //Act
            int count = 0;
            object[] arrayToCompare = new object[3]; 
            foreach (var item in listOfObjects)
            {
                arrayToCompare[count++] = item;
            }
            //Assert

            var revertedArray = stackOfStrings.ToArray<object>();
            CollectionAssert.AreEqual(arrayToCompare, revertedArray);
        }

        [TestMethod]
        public void Dispose_UsingStatement_Disposed()
        {
            //Arrange
            ////Act
            using (OmegaStack<string> stackOfStrings = new())
            {
                stackOfStrings.Push("a");
                stackOfStrings.Push("b");
            }
            ////Assert
            Assert.IsTrue(true);
        }

        private static IOmegaStack<SampleObject> CreateSimpleStack()
        {
            IOmegaStack<SampleObject> stack = new OmegaStack<SampleObject>();
            stack.Push(new SampleObject("a"));

            return stack;
        }
    }
}