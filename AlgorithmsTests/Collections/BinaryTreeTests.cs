using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Collections;
using Algorithms.Exceptions;
using Algorithms.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithms_Test.Collections
{
    [TestClass]
    public class BinaryTreeTest
    {
        private BinaryTreeCollection<int?> _binaryTree;

        [TestInitialize]
        public void SetUp()
        {
            _binaryTree = new BinaryTreeCollection<int?>(Shared.DefaultIntComparison);
        }

        [TestCleanup]
        public void Cleanning()
        {
            _binaryTree = null;
        }


        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree"), ExpectedException(typeof(NullObjectException))]
        public void Add_WhenObjectIsNull_Exception()
        {
            //Arrange
            //Act
            _binaryTree.Add(null);
            //Assert
            Assert.Inconclusive("An exception is expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Add_PuttingOneObject_OneObjectAdded()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            //Assert
            Assert.IsTrue(_binaryTree.Count == 1, "The lenght of the binary tree should be 1!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Add_RootAndLeft_Success()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(1);
            //Assert
            Assert.IsTrue(_binaryTree.Count == 2, "The lenght of the binary tree should be 2!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Add_RootAndLeftAndRight_Success()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(1);
            _binaryTree.Add(15);
            //Assert
            Assert.IsTrue(_binaryTree.Count == 3, "The lenght of the binary tree should be 3!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Add_RootAndLeftAndLeftAndRight_Success()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(1);
            _binaryTree.Add(0);
            _binaryTree.Add(15);
            //Assert
            Assert.IsTrue(_binaryTree.Count == 4, "The lenght of the binary tree should be 4!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Add_RootAndRightAndRightAndRight_Success()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(100);
            _binaryTree.Add(200);
            _binaryTree.Add(300);
            //Assert
            Assert.IsTrue(_binaryTree.Count == 4, "The lenght of the binary tree should be 4!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree"), ExpectedException(typeof(EqualsElementException))]
        public void Add_EqualsElements_Fail()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(10);
            //Assert
            Assert.Inconclusive("An exeption was expected!");
        }


        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree"), ExpectedException(typeof(NullObjectException))]
        public void Retrieve_NullValue_Exception()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(1);
            _binaryTree.Retrieve(null);
            //Assert
            Assert.Inconclusive("An exception was expected!");
        }
        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree"), ExpectedException(typeof(EmptyCollectionException))]
        public void Retrieve_TryingRetrieveInEmptyCollection_Exception()
        {
            //Arrange
            //Act
            _binaryTree.Retrieve(1);
            //Assert
            Assert.Inconclusive("An exception was expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Retrieve_RootAndLeft_LeftObjectReturned()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(1);
            int? result = _binaryTree.Retrieve(1);
            //Assert
            Assert.IsTrue(result == 1, "The binary tree should be returned the element 1!");
        }


        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree"), ExpectedException(typeof(ElementNotFoundException))]
        public void Retrieve_TryingRetrieveAnNonExistentElement_Exception()
        {
            //Arrange
            //Act
            _binaryTree.Add(10);
            _binaryTree.Add(1);
            int? result = _binaryTree.Retrieve(200);
            //Assert
            Assert.Inconclusive("An exception was expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void GetEnumerator_RootAndRightAndRightAndRight_CrescentOrder()
        {
            //Arrange
            _binaryTree.Add(10);
            _binaryTree.Add(100);
            _binaryTree.Add(200);
            _binaryTree.Add(300);
            //Act
            IEnumerable<int?> expectedList = new List<int?>() { 10,100,200,300 };

            //Assert
            Assert.IsTrue(_binaryTree.SequenceEqual(expectedList), "The binary tree should be in crescent order!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void GetEnumerator_RootAndLeftAndLeftAndRight_CrescentOrder()
        {
            //Arrange
            _binaryTree.Add(10);
            _binaryTree.Add(5);
            _binaryTree.Add(1);
            _binaryTree.Add(300);
            //Act
            IEnumerable<int?> expectedList = new List<int?>() { 1, 5, 10, 300 };
            //Assert
            Assert.IsTrue(_binaryTree.SequenceEqual(expectedList), "The binary tree should be in crescent order!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_WhenObjectIsNull_Exception()
        {
            //Arrange
            _binaryTree.Add(100);
            //Act
            bool success = _binaryTree.Remove(null);
            //Assert
            Assert.IsFalse(success, "An exception is expected!");
        }


        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_WhenCollectionIsEmpty_Exception()
        {
            //Arrange
            //Act
            bool success = _binaryTree.Remove(10);
            //Assert
            Assert.IsFalse(success, "An exception is expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_WhenTreeNotContainsValueWithOnlyOneObject_Exception()
        {
            //Arrange
            _binaryTree.Add(100);
            //Act
            bool success = _binaryTree.Remove(150);
            //Assert
            Assert.IsFalse(success, "An exception is expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_WhenTreeHasOnlyOneValue_Success()
        {
            //Arrange
            _binaryTree.Add(100);
            //Act
            bool success = _binaryTree.Remove(100);
            //Assert
            Assert.IsTrue(success, "The value 100 was expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_NodeHasNoChildren_Success()
        {
            //Arrange
            _binaryTree.Add(100);
            _binaryTree.Add(50);

            //Act
            bool success = _binaryTree.Remove(50);
            //Assert
            Assert.IsTrue(success, "The value 50 was expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_NodeHasLeftChildren_Success()
        {
            //Arrange
            _binaryTree.Add(100);
            _binaryTree.Add(50);
            _binaryTree.Add(25);

            //Act
            bool success = _binaryTree.Remove(50);
            //Assert
            Assert.IsTrue(success, "The value 50 was expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_NodeHasRightChildren_Success()
        {
            //Arrange
            _binaryTree.Add(100);
            _binaryTree.Add(50);
            _binaryTree.Add(60);

            //Act
            bool success = _binaryTree.Remove(50);
            //Assert
            Assert.IsTrue(success, "The value 50 was expected!");
        }


        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_NodeHasRightAndLeftChildren_Success()
        {
            //Arrange
            _binaryTree.Add(100);
            _binaryTree.Add(50);
            _binaryTree.Add(60);
            _binaryTree.Add(25);
            //Act
            bool success = _binaryTree.Remove(50);
            //Assert
            Assert.IsTrue(success, "The value 50 was expected!");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("BinaryTree")]
        public void Remove_NodeHasRightAndLeftChildrenAndRightNodeHasLeftChildren_Success()
        {
            //Arrange
            _binaryTree.Add(100);
            _binaryTree.Add(50);
            _binaryTree.Add(60);
            _binaryTree.Add(25);
            _binaryTree.Add(55);
            //Act
            bool success = _binaryTree.Remove(50);
            //Assert
            Assert.IsTrue(success, "The value 50 was expected!");
        }
    }
}
