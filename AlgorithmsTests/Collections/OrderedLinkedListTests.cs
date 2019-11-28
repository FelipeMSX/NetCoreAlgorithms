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
        /// Técnica: Caminho de Decisão.
        /// </summary>
        [TestMethod, TestCategory("OrderedLinkedList"), ExpectedException(typeof(NullObjectException))]
        public void Insert_ObjectIsNull_Exception()
        {
            //Arrange
            //Act
            _orderedLinkedList.Insert(null);
            //Assert
            Assert.Inconclusive("An exception is expected!");
        }
    }
}
