using Algorithms.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ClearExtensions;
using OmegaCore.Collections;
using OmegaCore.Exceptions;
using OmegaCore.Extensions;
using OmegaCore.Interfaces;
using OmegaCoreTests.Shared;


namespace OmegaCoreTests.Collections
{
    [TestClass]
    public class OmegaQueueTests
    {

        private IOmegaQueue<SampleObject> _queue;
        private IArrayExtensions _defaultInstance;

        public OmegaQueueTests()
        {
            _defaultInstance = ArrayExtensions.Instance;
        }

        [TestInitialize]
        public void TearUp()
        {
            _queue = SampleObject.CreateSampleQueue();
        }

        [TestCleanup]
        public void TearDown()
        {
            _queue.Clear();
            ArrayExtensions.Instance = _defaultInstance;
        }

        #region Queue
        [TestMethod]
        public void Queue_AddingSingleElement_CountEqualsOne()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            //Act
            _queue.Queue(new SampleObject("a"));
            //Assert
            Assert.IsTrue(_queue.Count == 1);
        }

        [TestMethod]
        public void Queue_AddingSingleElement_ElementIsFound()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            //Act
            _queue.Queue(new SampleObject("a"));
            //Assert
            Assert.IsTrue(_queue[0].Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(NullParameterException))]
        public void Queue_AddingNullElement_Exception()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            //Act
            _queue.Queue(null!);
        }

        [TestMethod, ExpectedException(typeof(FullCollectionException))]
        public void Queue_AddingElementToFullCollectionNotResizable_Exception()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>(1, false);
            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
        }

        [TestMethod]
        public void Queue_AddingElementToFullCollectionResizable_ElementsInQueue()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>(1, true);
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.IncreaseCapacity(Arg.Any<SampleObject[]>(), 2).Returns(new SampleObject[2] { new SampleObject("a"), null! });
            ArrayExtensions.Instance = _arrayExtensions;


            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue[0].Equals(new SampleObject("a")) && _queue[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void Queue_AddingElementToFullCollectionResizable_CountIsTwo()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>(1, true);
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.IncreaseCapacity(Arg.Any<SampleObject[]>(), 2).Returns(new SampleObject[2] { new SampleObject("a"), null! });
            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue.Count == 2);
        }

        [TestMethod]
        public void Queue_AddingElementToFullCollectionResizable_MaxCapacityIsTwo()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>(1, true);
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.IncreaseCapacity(Arg.Any<SampleObject[]>(), 2).Returns(new SampleObject[2] { new SampleObject("a"), null! });
            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue.MaxCapacity == 2);
        }

        #endregion

        #region Unqueue

        [TestMethod]
        public void Unqueue_UnqueueAllElements_CountIsZero()
        {
            //Arrange
            _queue = CreateSimpleQueue();
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.Shift(Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] source = x.ArgAt<SampleObject[]>(0);
                source[0] = default!;
                source[1] = default!;
            });
            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            _queue.Unqueue();
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue.Count == 0);
        }

        [TestMethod]
        public void Unqueue_UnqueueAllElements_ElementsAreNull()
        {
            //Arrange
            _queue = CreateSimpleQueue();
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.Shift(Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] source = x.ArgAt<SampleObject[]>(0);
                source[0] = default!;
                source[1] = default!;
            });
            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            _queue.Unqueue();
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsNull(_queue[0]);
        }

        [TestMethod]
        public void Unqueue_TwoElementsInQueue_ElementRemoved()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));

            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.Shift(Arg.Any<SampleObject[]>(), 0, 2)).Do(x =>
            {
                SampleObject[] source = x.ArgAt<SampleObject[]>(0);
                source[0] = new SampleObject("b");
                source[1] = default!;
            });
            ArrayExtensions.Instance = _arrayExtensions;

            //Act
            var value = _queue.Unqueue();
            _arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(value.Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
        public void Unqueue_EmptyColllection_Exception()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            //Act
            _queue.Unqueue();

        }
        #endregion

        #region Peek
        [TestMethod]
        public void Peek_WithOneElement_ElementPeeked()
        {
            //Arrange
            _queue = CreateSimpleQueue();
            //Act
            var value = _queue.Peek();
            //Assert
            Assert.IsTrue(value.Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(EmptyCollectionException))]
        public void Peek_EmptyColllection_Exception()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            //Act
            _queue.Peek();

        }
        #endregion

        #region CopyTo

        [TestMethod]
        public void CopyTo_TwoElementsInQueue_AllElementsCopied()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));

            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });
            ArrayExtensions.Instance = _arrayExtensions;

            SampleObject[] newArray = new SampleObject[2];
            //Act
            _queue.CopyTo(newArray, 0);

            _arrayExtensions.Received(1).OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1);
            _arrayExtensions.ClearSubstitute();
            //Assert
            Assert.IsTrue(true);
        }
        #endregion


        [TestMethod]
        public void Dispose_UsingStatement_Disposed()
        {
            //Arrange
            var _arrayExtensions = Substitute.For<IArrayExtensions>();

            _arrayExtensions.When(x => x.Clear(Arg.Any<string[]>(), Arg.Any<int>())).Do(x =>
            {
                string[] source = x.ArgAt<string[]>(0);
                source[0] = default!;
                source[1] = default!;

            });
            ArrayExtensions.Instance = _arrayExtensions;

            ////Act
            using (OmegaQueue<string> queueOfStrings = new())
            {
                queueOfStrings.Queue("a");
                queueOfStrings.Queue("b");
            }

            _arrayExtensions.Received(1).Clear(Arg.Any<string[]>(), Arg.Any<int>());
            _arrayExtensions.ClearSubstitute();
            ////Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void OmegaQueue_PassingCollection_ArrayCopied()
        {
            //Arrange
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = _arrayExtensions;
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Act
            _queue = new OmegaQueue<SampleObject>(collection);
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue[0].Equals(new SampleObject("a")) && _queue[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void OmegaQueue_PassingCollection_CountIsTwo()
        {
            //Arrange
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = _arrayExtensions;
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Act
            _queue = new OmegaQueue<SampleObject>(collection);
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue.Count == 2);
        }

        [TestMethod]
        public void OmegaQueue_PassingArray_ArrayCopied()
        {
            //Arrange
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = _arrayExtensions;
            //Act
            _queue = new OmegaQueue<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue[0].Equals(new SampleObject("a")) && _queue[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void OmegaQueue_PassingArray_CountIsTwo()
        {
            //Arrange
            var _arrayExtensions = Substitute.For<IArrayExtensions>();
            _arrayExtensions.When(x => x.OmegaCopy(Arg.Any<SampleObject[]>(), Arg.Any<SampleObject[]>(), 0, 1)).Do(x =>
            {
                SampleObject[] destination = x.ArgAt<SampleObject[]>(1);
                destination[0] = new SampleObject("a");
                destination[1] = new SampleObject("b");
            });

            ArrayExtensions.Instance = _arrayExtensions;
            //Act
            _queue = new OmegaQueue<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            _arrayExtensions.ClearSubstitute();

            //Assert
            Assert.IsTrue(_queue.Count == 2);
        }

        [TestMethod]
        public void GetEnumerator_UsingCovariance_LoopingAllObjects()
        {
            //Arrange
            IOmegaQueue<string> listOfStrings = new OmegaQueue<string>(new string[] { "a", "b", "c" });
            IOmegaEnumerable listOfObjects = listOfStrings;

            //Act
            int count = 0;

            foreach (var item in listOfObjects)
                count++;

            //Assert
            Assert.IsTrue(count == 3);
        }

        private static IOmegaQueue<SampleObject> CreateSimpleQueue()
        {
            IOmegaQueue<SampleObject> queue = new OmegaQueue<SampleObject>();
            queue.Queue(new SampleObject("a"));

            return queue;
        }
    }
}