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
    public class OmegaQueueTests
    {

        private IOmegaQueue<SampleObject> _queue;

        [TestInitialize]
        public void TearUp()
        {
            _queue = CreateSimpleQueue();
        }

        [TestCleanup]
        public void TearDown()
        {
            _queue.Dispose();
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

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.ArgumentNullException))]
        public void Queue_AddingNullElement_Exception()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>();
            //Act
            _queue.Queue(null!);
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.FullCollectionException))]
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
            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
            //Assert
            Assert.IsTrue(_queue[0].Equals(new SampleObject("a")) && _queue[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void Queue_AddingElementToFullCollectionResizable_CountIsTwo()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>(1, true);
            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
            //Assert
            Assert.IsTrue(_queue.Count == 2);
        }

        [TestMethod]
        public void Queue_AddingElementToFullCollectionResizable_MaxCapacityIsTwo()
        {
            //Arrange
            _queue = new OmegaQueue<SampleObject>(1, true);
            //Act
            _queue.Queue(new SampleObject("a"));
            _queue.Queue(new SampleObject("b"));
            //Assert
            Assert.IsTrue(_queue.MaxCapacity == 2);
        }

        #endregion

        #region Unqueue

        [TestMethod]
        public void Unqueue_UnqueueAllElements_CountIsZero()
        {
            //Arrange
            //Act
            _queue.Unqueue();
            //Assert
            Assert.IsTrue(_queue.Count == 0);
        }

        [TestMethod]
        public void Unqueue_UnqueueAllElements_ElementsAreNull()
        {
            //Arrange
            //Act
            _queue.Unqueue();
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
            //Act
            var value = _queue.Unqueue();
            //Assert
            Assert.IsTrue(value.Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.EmptyCollectionException))]
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
            //Act
            var value = _queue.Peek();
            //Assert
            Assert.IsTrue(value.Equals(new SampleObject("a")));
        }

        [TestMethod, ExpectedException(typeof(OmegaCore.Exceptions.EmptyCollectionException))]
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
            SampleObject[] newArray = new SampleObject[2];
            //Act
            _queue.CopyTo(newArray, 0);
            //Assert
            Assert.IsTrue(true);
        }
        #endregion


        [TestMethod]
        public void Dispose_UsingStatement_Disposed()
        {
            //Arrange
            ////Act
            using (OmegaQueue<string> queueOfStrings = new())
            {
                queueOfStrings.Queue("a");
                queueOfStrings.Queue("b");
            }
            ////Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void OmegaQueue_PassingCollection_ArrayCopied()
        {
            //Arrange
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(
                new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Act
            _queue = new OmegaQueue<SampleObject>(collection);

            //Assert
            Assert.IsTrue(_queue[0].Equals(new SampleObject("a")) && _queue[1].Equals(new SampleObject("b")));
        }

        [TestMethod]
        public void OmegaQueue_PassingCollection_CountIsTwo()
        {
            //Arrange
            IOmegaCollection<SampleObject> collection = new OmegaList<SampleObject>(
                new SampleObject[] { new SampleObject("a"), new SampleObject("b") });
            //Act
            _queue = new OmegaQueue<SampleObject>(collection);

            //Assert
            Assert.IsTrue(_queue.Count == 2);
        }

        [TestMethod]
        public void OmegaQueue_PassingArray_ArrayCopied()
        {
            //Arrange
            var arrayToTest = new SampleObject[] { new SampleObject("a"), new SampleObject("b") };
            //Act
            _queue = new OmegaQueue<SampleObject>(arrayToTest);
            var queueArray = _queue.ToArray();
            //Assert
            CollectionAssert.AreEqual(queueArray, arrayToTest);
        }

        [TestMethod]
        public void OmegaQueue_PassingArray_CountIsTwo()
        {
            //Arrange
            //Act
            _queue = new OmegaQueue<SampleObject>(new SampleObject[] { new SampleObject("a"), new SampleObject("b") });

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