using Algorithms.Collections;
using Algorithms.Collections.Dynamic;
using Algorithms.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Test.Collections
{
    [TestClass]
    public class OrderedLinkedListTests
    {
        private OrderedLinkedList<int?> _orderedLinkedList;


        [TestInitialize]
        public void SetUp()
        {
            _orderedLinkedList = new OrderedLinkedList<int?>(Shared.DefaultIntComparison);
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), ExpectedException(typeof(NullObjectException)), Timeout(3000)]
        public void Add_ObjectIsNull_Exception()
        {
            //Arrange
            //Act
            _orderedLinkedList.Add(null);
            //Assert
            Assert.Inconclusive("An exception is expected!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), Timeout(3000)]
        public void Add_OnlyOneValue_Success()
        {
            //Arrange
            //Act
            _orderedLinkedList.Add(1);
            //Assert
            Assert.IsTrue(_orderedLinkedList.Count == 1,"The size of the collection is wrong.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), Timeout(3000)]
        public void Add_TwoDifferentValuesAndAllowEquals_Success()
        {
            //Arrange
            //Act
            _orderedLinkedList.Add(1);
            _orderedLinkedList.Add(2);
            //Assert
            Assert.IsTrue(_orderedLinkedList.Count == 2, "The size of the collection is wrong.");
        }


        /// <summary>
        /// Técnica: Laço. Executar o laço N vezes.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), Timeout(3000)]
        public void Add_ThreeDifferentValuesAndAllowEquals_Success()
        {
            //Arrange
            //Act
            _orderedLinkedList.Add(1);
            _orderedLinkedList.Add(2);
            _orderedLinkedList.Add(3);
            //Assert
            Assert.IsTrue(_orderedLinkedList.Count == 3, "The size of the collection is wrong.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), Timeout(3000)]
        public void Add_TwoValuesInFirstPosition_Ordered()
        {
            //Arrange
            //Act
            _orderedLinkedList.Add(10);
            _orderedLinkedList.Add(5);
            var expectedList = _orderedLinkedList.OrderBy(x => x.Value);
            //Assert
            Assert.IsTrue(expectedList.SequenceEqual(_orderedLinkedList), "The collection is not ordered correctly.");
        }


        /// <summary>
        /// Técnica: Laço. Executar o laço N vezes.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), Timeout(3000)]
        public void Add_DesorderedValues_Ordered()
        {
            //Arrange
            //Act
            _orderedLinkedList.Add(10);
            _orderedLinkedList.Add(5);
            _orderedLinkedList.Add(3);
            _orderedLinkedList.Add(6);
            _orderedLinkedList.Add(100);

            var expectedList = _orderedLinkedList.OrderBy(x => x.Value);
            //Assert
            Assert.IsTrue(expectedList.SequenceEqual(_orderedLinkedList), "The collection is not ordered correctly.");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), ExpectedException(typeof(EqualsElementException)), Timeout(3000)]
        public void Add_EqualsElementsInsertionOnHead_Exception()
        {
            //Arrange
            _orderedLinkedList = new OrderedLinkedList<int?>(Shared.DefaultIntComparison, false);
            //Act
            _orderedLinkedList.Add(10);
            _orderedLinkedList.Add(10);
            //Assert
            Assert.Inconclusive("An exception was expected");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), ExpectedException(typeof(EqualsElementException)), Timeout(3000)]
        public void Add_EqualsElementsMiddle_Exception()
        {
            //Arrange
            _orderedLinkedList = new OrderedLinkedList<int?>(Shared.DefaultIntComparison, false);
            //Act
            _orderedLinkedList.Add(10);
            _orderedLinkedList.Add(100);
            _orderedLinkedList.Add(1000);
            _orderedLinkedList.Add(100);
            //Assert
            Assert.Inconclusive("An exception was expected");
        }
    }
}
