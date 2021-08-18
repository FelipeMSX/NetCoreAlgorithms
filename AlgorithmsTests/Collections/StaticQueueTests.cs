using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Collections;
using AlgorithmsTests;
using Algorithms.Exceptions;
using Algorithms.Abstracts;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms_Test.Collections
{
    [TestClass]
    public class StaticQueueTests
    {

        private Algorithms.Collections.Queue<int?> _staticQueue;


        [TestInitialize]
        public void Initialize()
        {
            _staticQueue = new Algorithms.Collections.Queue<int?>(100, Shared.DefaultIntComparison);
        }

        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void Push_ThreeObjects_LengthEqualsThree()
        {
            //Arrange
            //Act
            _staticQueue.Push(2);
            _staticQueue.Push(1);
            _staticQueue.Push(4);
            //Assert
            Assert.IsTrue(_staticQueue.Count == 3);
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(NullObjectException)), Timeout(3000)]
        public void Push_NullValue_NullObjectException()
        {
            //Arrange 
            //Act
            _staticQueue.Push(null);
            //Assert
            Assert.Inconclusive("An exception was expected because it tried to add a null value.");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void Push_ObjectInFullCollectionResizable_LengthEqualsThree()
        {
            //Arrange
            _staticQueue = new Algorithms.Collections.Queue<int?>(2, Shared.DefaultIntComparison);
            //Act
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            _staticQueue.Push(3);
            //Assert
            Assert.IsTrue(_staticQueue.Count == 3 && _staticQueue.MaxSize == 1002);
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(FullCollectionException)), Timeout(3000)]

        public void Push_ObjectInFullCollectionNotResizable_FullCollectionException()
        {
            //Arrange
            _staticQueue = new Algorithms.Collections.Queue<int?>(2, Shared.DefaultIntComparison, false);
            //Act
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            _staticQueue.Push(3); // It should be occur an exception here.
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is currently full.");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(EmptyCollectionException)), Timeout(3000)]
        public void Pop_EmptyList_EmptyCollectionException()
        {
            //Arrange
            //Act
            _staticQueue.Pop();
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is currently empty.");
        }

        /// <summary>
        /// Técnica: Ciclo. Executar o for nenhuma vez
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void Pop_AddOneItemAndPop_Success()
        {
            //Arrange
            _staticQueue.Push(1);
            //Act
            int? popedObject1 = _staticQueue.Pop();
            //Assert
            Assert.IsTrue(popedObject1 == 1);

        }

        /// <summary>
        /// Técnica: Ciclo. Executar o for uma vez
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void Pop_AddTwoItemAndPopThem_Success()
        {
            //Arrange
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            //Act
            int? popedObject1 = _staticQueue.Pop();
            int? popedObject2 = _staticQueue.Pop();
            //Assert
            Assert.IsTrue(popedObject1 == 1 && popedObject2 == 2);
        }

        /// <summary>
        /// Técnica: Ciclo. Executar o for N-vezes.
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void Pop_AddThreeItemAndPopThem_Success()
        {
            //Arrange
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            _staticQueue.Push(3);
            //Act
            int? popedObject1 = _staticQueue.Pop();
            int? popedObject2 = _staticQueue.Pop();
            int? popedObject3 = _staticQueue.Pop();

            //Assert
            Assert.IsTrue(popedObject1 == 1 && popedObject2 == 2 && popedObject3 == 3);
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), ExpectedException(typeof(EmptyCollectionException)), Timeout(3000)]
        public void Peek_EmptyCollection_Exception()
        {
            //Arrange
            //Act
            _staticQueue.Peek();
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is empty.");
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void Peek_RetriveOneValue_Success()
        {
            //Arrange
            _staticQueue.Push(8);
            _staticQueue.Push(3);
            _staticQueue.Push(10);
            _staticQueue.Push(1);
            _staticQueue.Push(100);
            //Act
            int? value =_staticQueue.Peek();
            //Assert
            Assert.IsTrue(value == 8,"The value eight was expected.");
        }


        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticQueue"), Timeout(3000)]
        public void GetEnumerator_RetriveValues_Success()
        {
            //Arrange
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            _staticQueue.Push(3);
            _staticQueue.Push(4);
            _staticQueue.Push(5);
            //Act
            IEnumerable<int?> expectedList = _staticQueue.OrderBy(x => x);
            //Assert
            Assert.IsTrue(expectedList.SequenceEqual(_staticQueue), "The collections should be the same.");
        }
    }
}
