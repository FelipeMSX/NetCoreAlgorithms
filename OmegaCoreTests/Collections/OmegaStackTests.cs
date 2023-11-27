using Algorithms.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ClearExtensions;
using OmegaCore.Collections;
using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.Extensions;
using OmegaCore.Interfaces;
using OmegaCoreTests.Shared;


namespace OmegaCoreTests.Collections
{
    [TestClass]
    public class OmegaStackTests
    {

        private IOmegaStack<SampleObject> _stack;
        private IArrayUtil _defaultInstance;

        public OmegaStackTests()
        {
            _defaultInstance = ArrayExtensions.Instance;
        }

        [TestInitialize]
        public void TearUp()
        {
            _stack = CreateSimpleStack();
        }

        [TestCleanup]
        public void TearDown()
        {
            _stack.Dispose();
            ArrayExtensions.Instance = _defaultInstance;
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

        [TestMethod, ExpectedException(typeof(NullParameterException))]
        public void Push_AddingNullElement_Exception()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>();
            //Act
            _stack.Push(null!);
        }

        [TestMethod, ExpectedException(typeof(FullCollectionException))]
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
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.IncreaseCapacity(Arg.Any<SampleObject[]>(), 2).Returns(new SampleObject[2] { new SampleObject("a"), null! });
            ArrayExtensions.Instance = arrayExtensions;

            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));
            arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_stack[0].Equals(new SampleObject("a")) && _stack[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void Push_AddingElementToFullCollectionResizable_CountIsTwo()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>(1, true);
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.IncreaseCapacity(Arg.Any<SampleObject[]>(), 2).Returns(new SampleObject[2] { new SampleObject("a"), null! });
            ArrayExtensions.Instance = arrayExtensions;

            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));
            arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_stack.Count == 2);
        }

        [TestMethod]
        public void Push_AddingElementToFullCollectionResizable_MaxCapacityIsTwo()
        {
            //Arrange
            _stack = new OmegaStack<SampleObject>(1, true);
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.IncreaseCapacity(Arg.Any<SampleObject[]>(), 2).Returns(new SampleObject[2] { new SampleObject("a"), null! });
            ArrayExtensions.Instance = arrayExtensions;

            //Act
            _stack.Push(new SampleObject("a"));
            _stack.Push(new SampleObject("b"));
            arrayExtensions.ClearSubstitute();

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

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
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

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
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

            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });
  
            ArrayExtensions.Instance = arrayExtensions;

            SampleObject[] newArray = new SampleObject[2];
            //Act
            _stack.CopyTo(newArray, 0);

            arrayExtensions.Received(1).OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1);
            arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(true);
        }
        #endregion

        #region Constructos
        [TestMethod]
        public void OmegaStack_PassingCollection_ArrayCopied()
        {
            //Arrange
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = arrayExtensions;
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Act
            _stack = new OmegaStack<SampleObject>(collection);
            arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_stack[0].Equals(new SampleObject("a")) && _stack[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void OmegaStack_PassingCollection_CountIsTwo()
        {
            //Arrange
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = arrayExtensions;
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Act
            _stack = new OmegaStack<SampleObject>(collection);
            arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_stack.Count == 2);
        }

        [TestMethod]
        public void OmegaStack_PassingArray_ArrayCopied()
        {
            //Arrange
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = arrayExtensions;
            //Act
            _stack = new OmegaStack<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_stack[0].Equals(new SampleObject("a")) && _stack[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void OmegaStack_PassingArray_CountIsTwo()
        {
            //Arrange
            var arrayExtensions = Substitute.For<IArrayUtil>();
            arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = arrayExtensions;
            //Act
            _stack = new OmegaStack<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_stack.Count == 2);
        }
        #endregion

        [TestMethod]
        public void GetEnumerator_UsingCovariance_ElementsInOrderCBA()
        {
            //Arrange
            IOmegaStack<string> listOfStrings = new OmegaStack<string>(new string[] { "a", "b", "c" });
            IOmegaEnumerable listOfObjects = listOfStrings;

            //Act
            int count = 0;
            object[] arrayToCompare = new object[3]; 
            foreach (var item in listOfObjects)
            {
                arrayToCompare[count++] = item;
            }

            bool elementsInOrder = arrayToCompare[0].Equals("c") && arrayToCompare[1].Equals("b") 
                && arrayToCompare[2].Equals("a");
            //Assert
            Assert.IsTrue(elementsInOrder);
        }

        [TestMethod]
        public void Dispose_UsingStatement_Disposed()
        {
            //Arrange
            var arrayExtensions = Substitute.For<IArrayUtil>();

            arrayExtensions.When(x => x.Clear(Arg.Any<string[]>(), Arg.Any<int>())).Do(x =>
            {
                string[] source = x.ArgAt<string[]>(0);
                source[0] = default!;
                source[1] = default!;

            });
            ArrayExtensions.Instance = arrayExtensions;

            ////Act
            using (OmegaStack<string> stackOfStrings = new())
            {
                stackOfStrings.Push("a");
                stackOfStrings.Push("b");
            }

            arrayExtensions.Received(1).Clear(Arg.Any<string[]>(), Arg.Any<int>());
            arrayExtensions.ClearSubstitute();
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