using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsTests;
using Algorithms.Abstracts;
using Algorithms.Collections;
using Algorithms.Exceptions;

namespace Algorithms_Test.Abstracts
{
    /// <summary>
    /// Testes relacionados a classe abstrata ArrayBase. 
    /// Essa classe de teste foi definada porque existe lógica para testar na classe abstrata.
    /// </summary>
    [TestClass]
    public class ArrayBaseTests
    {
        private StaticQueue<int?> _staticQueue;
        private static StaticQueue<int?> CreateQueue(int capacity, bool resizable)
        {
            return new StaticQueue<int?>(capacity, resizable, true,
                            ((x, y) => x.Value.CompareTo(y.Value)));
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--if (Comparator == null)-->
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(ComparerNotSetException))]

        public void Retrieve_ComparatorNotSet_Exception()
        {
            //Arrange
            _staticQueue = new StaticQueue<int?>(5,true,true,null);
            _staticQueue.Push(1);
            //Act
            _staticQueue.Retrive(1);
            //Assert
            Assert.Inconclusive("The exception is expected because the queue doesn't has a comparator!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço nenhuma vez.
        /// </summary>
        /// <!--for (int i = 0; i < Length; i++)-->
        [TestMethod, TestCategory("ArrayBase")]

        public void Retrieve_EmptyList_NullObject()
        {
            //Arrange
            _staticQueue = CreateQueue(5,true);
            //Act
            int? result = _staticQueue.Retrive(1);
            //Assert
            Assert.IsTrue(result == null);
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o pelo menos vez.
        /// </summary>
        /// <!--for (int i = 0; i < Length; i++)-->
        [TestMethod, TestCategory("ArrayBase")]

        public void Retrieve_ThereAreTwoElements_Object()
        {
            //Arrange
            _staticQueue = CreateQueue(5,true);
            _staticQueue.Push(1);
            //Act
            int? result = _staticQueue.Retrive(1);
            //Assert
            Assert.IsTrue(result == 1);
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o ciclo N vezes.
        /// </summary>
        /// <!--for (int i = 0; i < Length; i++)-->
        [TestMethod, TestCategory("ArrayBase")]

        public void Retrieve_ThereAreFiveElements_Object()
        {
            //Arrange
            _staticQueue = CreateQueue(5,true);
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            _staticQueue.Push(3);
            _staticQueue.Push(4);
            _staticQueue.Push(5);
            //Act
            int? result = _staticQueue.Retrive(5);
            //Assert
            Assert.IsTrue(result == 5);
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--if (!Resizable)-->
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(FullCollectionException))]

        public void IncreaseCapacity_NotResizable_Exception()
        {
            //Arrange
            _staticQueue = CreateQueue(2, false);
            _staticQueue.Push(1);
            //Act
            _staticQueue.IncreaseCapacity(2);
            //Assert
            Assert.Inconclusive("The exception is expected because the collection isn't resizable!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o ciclo nenhuma vez.
        /// </summary>
        /// <!--for (int i = 0; i < Length; i++)-->
        [TestMethod, TestCategory("ArrayBase")]

        public void IncreaseCapacity_IncrementByZero_SizeUnchanged()
        {
            //Arrange
            _staticQueue = CreateQueue(2, true);
            //Act
            _staticQueue.IncreaseCapacity(0);
            //Assert
            Assert.IsTrue(_staticQueue.MaxSize == 2,"The expected is two.");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o ciclo n vezes.
        /// </summary>
        /// <!--for (int i = 0; i < Length; i++)-->
        [TestMethod, TestCategory("ArrayBase")]

        public void IncreaseCapacity_IncrementByTen_MaxSizeIsTwelve()
        {
            //Arrange
            _staticQueue = CreateQueue(2, true);
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            //Act
            _staticQueue.IncreaseCapacity(10);
            //Assert
            Assert.IsTrue(_staticQueue.MaxSize == 12, "The expected is twelve.");
        }
    }
}
