using Algorithms.Collections;
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
        [TestMethod, TestCategory("OrderedLinkedList"), ExpectedException(typeof(NullObjectException))]
        public void Insert_ObjectIsNull_Exception()
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
        [TestMethod, TestCategory("OrderedLinkedList")]
        public void Insert_OnlyOneValue_Success()
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
        [TestMethod, TestCategory("OrderedLinkedList")]
        public void Insert_TwoDifferentValuesAndAllowEquals_Success()
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
        [TestMethod, TestCategory("OrderedLinkedList")]
        public void Insert_ThreeDifferentValuesAndAllowEquals_Success()
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
        /// Técnica: Laço. Executar o laço N vezes.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList")]
        public void Insert_ThreeDifferentValues_Ordered()
        {
            //Arrange
            
            //Act
            _orderedLinkedList.Add(10);
            _orderedLinkedList.Add(5);
            _orderedLinkedList.Add(3);
            _orderedLinkedList.Add(-1);
            _orderedLinkedList.Add(100);

            var expectedList = _orderedLinkedList.OrderByDescending(x => x.Value);

            //Assert
            Assert.IsTrue(expectedList.SequenceEqual(_orderedLinkedList), "The size of the collection is wrong.");
        }
    }
}
