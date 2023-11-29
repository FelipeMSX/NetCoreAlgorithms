using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsTests;
using Algorithms.Abstracts;
using Algorithms.Collections;
using Algorithms.Exceptions;
using NSubstitute;
using Algorithms.Collections.Static;

namespace Algorithms_Test.Abstracts
{
    /// <summary>
    /// Testes relacionados a classe abstrata ArrayBase. 
    /// Essa classe de teste foi definada porque existe lógica para testar na classe abstrata.
    /// </summary>
    [TestClass]
    public class ArrayBaseTests
    {
        //The test must be executed in a devired class;
        private Queue<int?> _arrayBase;

        [TestInitialize]
        public void TearUp()
        {
            _arrayBase = new Queue<int?>(Shared.DefaultIntComparison);
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Clear_EmptyCollection_Success()
        {
            //Arrange
            //Act
            _arrayBase.Clear();
            //Assert
            Assert.IsTrue(_arrayBase.Count == 0,"The size of the collection should be zero.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"),Timeout(3000)]
        public void Clear_CollectionWithItems_Success()
        {
            //Arrange
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            //Act
            _arrayBase.Clear();
            //Assert
            Assert.IsTrue(_arrayBase.Count == 0, "The size of the collection should be zero.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Empty_WhenCollectionIsEmpty_Success()
        {
            //Arrange
            //Act
            bool result = _arrayBase.Empty();
            //Assert
            Assert.IsTrue(result, "The collection should be empty.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Empty_WhenCollectionIsNotEmpty_Success()
        {
            //Arrange
            _arrayBase.Push(1);
            //Act
            bool result = _arrayBase.Empty();
            //Assert
            Assert.IsFalse(result, "The collection should be not empty.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Full_WhenCollectionIsFull_Success()
        {
            //Arrange
            for (int i = 0; i < ArrayBase<int?>.DefaultSize; i++)
            {
                _arrayBase.Push(i);
            }
            //Act
            bool result = _arrayBase.Full();
            //Assert
            Assert.IsTrue(result, "The collection should be full.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Full_WhenCollectionIsNotFull_Success()
        {
            //Arrange
            _arrayBase.Push(1);
            //Act
            bool result = _arrayBase.Full();
            //Assert
            Assert.IsFalse(result, "The collection should be not full.");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void First_WhenTheCollectionIsEmpty_DefaultValue()
        {
            //Arrange
            //Act
            int? result = _arrayBase.First();
            //Assert
            Assert.IsNull(result, "The value should be a null value.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void First_WhenTheCollectionIsNotEmpty_Value()
        {
            //Arrange
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            //Act
            int? result = _arrayBase.First();
            //Assert
            Assert.AreEqual(result, 1, "The value should be one.");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Last_WhenTheCollectionIsEmpty_DefaultValue()
        {
            //Arrange
            //Act
            int? result = _arrayBase.Last();
            //Assert
            Assert.IsNull(result, "The value should be a null value.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Last_WhenTheCollectionIsNotEmpty_Value()
        {
            //Arrange
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            //Act
            int? result = _arrayBase.Last();
            //Assert
            Assert.AreEqual(result, 2, "The value should be two.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(EmptyCollectionException)), Timeout(3000)]
        public void Retrieve_WhenTheCollectionIsNotEmpty_Exception()
        {
            //Arrange
            //Act
            int? result = _arrayBase.Retrieve(1);
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is empty.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(NullObjectException)), Timeout(3000)]
        public void Retrieve_WhenPassNullValue_Exception()
        {
            //Arrange
            _arrayBase.Push(1);
            //Act
            int? result = _arrayBase.Retrieve(null);
            //Assert
            Assert.Inconclusive("An exception was expected because a null value is not allowed.");
        }

        /// <summary>
        /// Técnica: Laço. Executar uma vez.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Retrieve_RetrieveValue_Success()
        {
            //Arrange
            int? value = 1;
            _arrayBase.Push(value);
            //Act
            int? result = _arrayBase.Retrieve(value);
            //Assert
            Assert.AreEqual(value, result, "The retrieved value should be one.");
        }

        /// <summary>
        /// Técnica: Laço. Executar o laço N-vezes.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void Retrieve_RetrieveValueInTheEndOfTheCollection_Success()
        {
            //Arrange
            int? value = 5;
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            _arrayBase.Push(4);
            _arrayBase.Push(value);
            //Act
            int? result = _arrayBase.Retrieve(value);
            //Assert
            Assert.AreEqual(value, result, "The retrieved value should be five.");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(ElementNotFoundException)), Timeout(3000)]
        public void Retrieve_RetrieveANonexistentValueInTheCollection_Exception()
        {
            //Arrange
            int? value = 6;
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            _arrayBase.Push(4);
            _arrayBase.Push(5);
            //Act
            int? result = _arrayBase.Retrieve(value);
            //Assert
            Assert.Inconclusive("An exception was expected because the value is not present in the collection.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(FullCollectionException)), Timeout(3000)]
        public void IncreaseCapacity_WhenCollectionIsNotResizable_Exception()
        {
            //Arrange
            _arrayBase = new Queue<int?>(5,Shared.DefaultIntComparison, false);
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            _arrayBase.Push(4);
            _arrayBase.Push(5);
            //Act
            _arrayBase.IncreaseCapacity(5);
            //Assert
            Assert.Inconclusive("An exception was expected because the collection can't be resizable.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), ExpectedException(typeof(ValueNotValidException)), Timeout(3000)]
        public void IncreaseCapacity_WhenInvalidValue_Exception()
        {
            //Arrange
            _arrayBase = new Queue<int?>(5, Shared.DefaultIntComparison, true);
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            _arrayBase.Push(4);
            _arrayBase.Push(5);
            //Act
            _arrayBase.IncreaseCapacity(-5);
            //Assert
            Assert.Inconclusive("An exception was expected because the increment size can't be lesser the current.");
        }

        /// <summary>
        /// Técnica: Laço. Executar o laço nenhuma vez.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void IncreaseCapacity_WhenCollectionIsEmpty_Success()
        {
            //Arrange
            _arrayBase = new Queue<int?>(5, Shared.DefaultIntComparison, true);
            //Act
            _arrayBase.IncreaseCapacity(5);
            //Assert
            Assert.AreEqual(_arrayBase.MaxSize, 10, "The maximum size of the collection should be ten.");
        }

        /// <summary>
        /// Técnica: Laço. Executar o laço N-Vezes.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"), Timeout(3000)]
        public void IncreaseCapacity_WhenCollectionHasValues_Success()
        {
            //Arrange
            _arrayBase = new Queue<int?>(5, Shared.DefaultIntComparison, true);
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            _arrayBase.Push(4);
            _arrayBase.Push(5);
            //Act
            _arrayBase.IncreaseCapacity(5);
            //Assert
            Assert.AreEqual(_arrayBase.MaxSize, 10, "The maximum size of the collection should be ten.");
        }

        /// <summary>
        /// Técnica: Laço. Executar o laço N-Vezes.
        /// </summary>
        [TestMethod, TestCategory("ArrayBase"),ExpectedException(typeof(ComparatorNotSetException)), Timeout(3000)]
        public void ArrayBaseConstructor_PassNullComparator_Exception()
        {
            //Arrange
            _arrayBase = new Queue<int?>(5, null, true);
            _arrayBase.Push(1);
            _arrayBase.Push(2);
            _arrayBase.Push(3);
            _arrayBase.Push(4);
            _arrayBase.Push(5);
            //Act
            _arrayBase.IncreaseCapacity(5);
            //Assert
            Assert.AreEqual(_arrayBase.MaxSize, 10, "The maximum size of the collection should be ten.");
        }
    }
}
