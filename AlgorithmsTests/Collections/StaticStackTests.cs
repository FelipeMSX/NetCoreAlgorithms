using System;
using Algorithms.Collections;
using Algorithms.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms_Test.Collections
{
    [TestClass]
    public class StaticStackTests
    {
        private StaticStack<int?> _staticStack;

        [TestInitialize]
        public void Initialize()
        {
            _staticStack = new StaticStack<int?>(1000, Shared.DefaultIntComparison);
        }

        [TestMethod, TestCategory("StaticStack")]
        public void Push_ThreeObjects_LengthEqualsThree()
        {
            //Arrange
            //Act
            _staticStack.Push(2);
            _staticStack.Push(1);
            _staticStack.Push(4);
            //Assert
            Assert.IsTrue(_staticStack.Count == 3);
        }

        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("StaticStack"), ExpectedException(typeof(NullObjectException))]
        public void Push_NullValue_NullObjectException()
        {
            //Arrange 
            //Act
            _staticStack.Push(null);
            //Assert
            Assert.Inconclusive("An exception was expected because it tried to add a null value.");
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void Push_ObjectInFullCollectionResizable_LengthEqualsThree()
        {
            //Arrange
            _staticStack = new StaticStack<int?>(2, Shared.DefaultIntComparison);
            //Act
            _staticStack.Push(1);
            _staticStack.Push(2);
            _staticStack.Push(3);
            //Assert
            Assert.IsTrue(_staticStack.Count == 3 && _staticStack.MaxSize == 1002);
        }

        /// <summary>
        /// Técnica: Caminho e Decisão.
        /// </summary>
        [TestMethod, TestCategory("StaticStack"), ExpectedException(typeof(FullCollectionException))]

        public void Push_ObjectInFullCollectionNotResizable_FullCollectionException()
        {
            //Arrange
            _staticStack = new StaticStack<int?>(2, Shared.DefaultIntComparison, false);
            //Act
            _staticStack.Push(1);
            _staticStack.Push(2);
            _staticStack.Push(3); // It should be occur an exception here.
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is currently full.");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// </summary>
        [TestMethod, TestCategory("StaticStack"), ExpectedException(typeof(EmptyCollectionException))]
        public void Pop_EmptyList_EmptyCollectionException()
        {
            //Arrange
            //Act
            _staticStack.Pop();
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is currently empty.");
        }

        /// <summary>
        /// Técnica: Ciclo. Executar o for nenhuma vez
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void Pop_AddOneItemAndPop_Success()
        {
            //Arrange
            _staticStack.Push(1);
            //Act
            int? popedObject1 = _staticStack.Pop();
            //Assert
            Assert.IsTrue(popedObject1 == 1);

        }

        /// <summary>
        /// Técnica: Ciclo. Executar o for uma vez
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void Pop_AddTwoItemAndPopThem_Success()
        {
            //Arrange
            _staticStack.Push(1);
            _staticStack.Push(2);
            //Act
            int? popedObject1 = _staticStack.Pop();
            int? popedObject2 = _staticStack.Pop();
            //Assert
            Assert.IsTrue(popedObject1 == 2 && popedObject2 == 1);
        }

        /// <summary>
        /// Técnica: Ciclo. Executar o for N-vezes.
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void Pop_AddThreeItemAndPopThem_Success()
        {
            //Arrange
            _staticStack.Push(1);
            _staticStack.Push(2);
            _staticStack.Push(3);
            //Act
            int? popedObject1 = _staticStack.Pop();
            int? popedObject2 = _staticStack.Pop();
            int? popedObject3 = _staticStack.Pop();

            //Assert
            Assert.IsTrue(popedObject1 == 3 && popedObject2 == 2 && popedObject3 == 1);
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticStack"), ExpectedException(typeof(EmptyCollectionException))]
        public void Peek_EmptyCollection_Exception()
        {
            //Arrange
            //Act
            _staticStack.Peek();
            //Assert
            Assert.Inconclusive("An exception was expected because the collection is empty.");
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void Peek_RetriveOneValue_Success()
        {
            //Arrange
            _staticStack.Push(8);
            _staticStack.Push(3);
            _staticStack.Push(10);
            _staticStack.Push(1);
            _staticStack.Push(100);
            //Act
            int? value = _staticStack.Peek();
            //Assert
            Assert.IsTrue(value == 100, "The value one hundred was expected.");
        }


        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void GetEnumerator_RetriveValues_Success()
        {
            //Arrange
            _staticStack.Push(1);
            _staticStack.Push(2);
            _staticStack.Push(3);
            _staticStack.Push(4);
            _staticStack.Push(5);
            //Act
            IEnumerable<int?> expectedList = _staticStack.OrderBy(x => x);
            //Assert
            Assert.IsTrue(expectedList.SequenceEqual(_staticStack), "The collections should be the same.");
        }


        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void First_EmptyStack_DefaultValue()
        {
            //Arrange
            //Act
            int? value = _staticStack.First();
            //Assert
            Assert.IsNull(value, "A null value was expected.");
        }


        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [DataTestMethod]
        [DataRow(1, 2, 3, 3)]
        [DataRow(10, 1, 100, 100)]
        [DataRow(3, 2, 1, 1)]
        [TestMethod, TestCategory("StaticStack")]
        public void First_DynamicValuesStack_DefaultValue(int? valueA, int? valueB, int? valueC, int? expectedValue)
        {
            //Arrange
            _staticStack.Push(valueA);
            _staticStack.Push(valueB);
            _staticStack.Push(valueC);
            //Act
            int? resultValue = _staticStack.First();
            //Assert
            Assert.IsTrue(expectedValue == resultValue, "The returned value is different from the expected value");
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(10,10)]
        [DataRow(3,3)]
        [TestMethod, TestCategory("StaticStack")]
        public void First_OnlyOneValue_DefaultValue(int? valueA, int? expectedValue)
        {
            //Arrange
            _staticStack.Push(valueA);
            //Act
            int? resultValue = _staticStack.First();
            //Assert
            Assert.IsTrue(expectedValue == resultValue, "The returned value is different from the expected value.");
        }


        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("StaticStack")]
        public void Last_EmptyStack_DefaultValue()
        {
            //Arrange
            //Act
            int? value = _staticStack.Last();
            //Assert
            Assert.IsNull(value, "A null value was expected.");
        }


        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [DataTestMethod]
        [DataRow(1, 2, 3, 1)]
        [DataRow(10, 1, 100, 10)]
        [DataRow(3, 2, 1, 3)]
        [TestMethod, TestCategory("StaticStack")]
        public void Last_DynamicValuesStack_DefaultValue(int? valueA, int? valueB, int? valueC, int? expectedValue)
        {
            //Arrange
            _staticStack.Push(valueA);
            _staticStack.Push(valueB);
            _staticStack.Push(valueC);
            //Act
            int? resultValue = _staticStack.Last();
            //Assert
            Assert.IsTrue(expectedValue == resultValue, "The returned value is different from the expected value");
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(10, 10)]
        [DataRow(3, 3)]
        [TestMethod, TestCategory("StaticStack")]
        public void Last_OnlyOneValue_DefaultValue(int? valueA, int? expectedValue)
        {
            //Arrange
            _staticStack.Push(valueA);
            //Act
            int? resultValue = _staticStack.Last();
            //Assert
            Assert.IsTrue(expectedValue == resultValue, "The returned value is different from the expected value.");
        }
    }
}
