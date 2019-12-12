using System;
using Algorithms.Collections;
using Algorithms.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Test.Collections
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int?> _linkedList;

        [TestInitialize]
        public void SetUp()
        {
            _linkedList = new LinkedList<int?>(Shared.DefaultIntComparison);
        }
       

        /// <summary>
        /// Técnica: Caminho de Decisão.
        /// </summary>
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(NullObjectException))]
        public void Add_ObjectIsNull_Exception()
        {
            //Arrange
            //Act
            _linkedList.Add(null);
            //Assert
            Assert.Inconclusive("An exception is expected!");
        }

        /// <summary>
        /// Técnica: Caminho de Decisão.
        /// </summary>
        [TestMethod, TestCategory("LinkedList")]
        public void Add_AddFirstElement_SizeEqualsOne()
        {
            //Arrange
            //Act
            _linkedList.Add(1);
            //Assert
            Assert.IsTrue(_linkedList.Count == 1, "The size of the collection is meant to be one!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço nenhuma vez.
        /// </summary>
        /// <!--while (searchNode.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void Add_AddTwoElements_SizeEqualsTwo()
        {
            //Arrange
            //Act
            _linkedList.Add(1);
            _linkedList.Add(2);
            //Assert
            Assert.IsTrue(_linkedList.Count == 2,"The size of the collection is meant to be two!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço uma vez.
        /// </summary>
        /// <!--while (searchNode.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void Add_AddTwoElements2_SizeEqualsThree()
        {
            //Arrange
            //Act
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Assert
            Assert.IsTrue(_linkedList.Count == 3, "The size of the collection is meant to be three!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço 3 vezes.
        /// </summary>
        /// <!--while (searchNode.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void Add_AddFourElements_SizeEqualsFour()
        {
            //Arrange
            //Act
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            _linkedList.Add(4);
            //Assert
            Assert.IsTrue(_linkedList.Count == 4, "The size of the collection is meant to be four!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--if (obj == null)-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(NullObjectException))]
        public void Remove_NullObject_Exception()
        {
            //Arrange
            //Act
            _linkedList.Remove(null);
            //Assert
            Assert.Inconclusive("An exception is expected!");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--if (Empty())-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(EmptyCollectionException))]
        public void Remove_EmptyList_Exception()
        {
            //Arrange
            //Act
            _linkedList.Remove(1);
            //Assert
            Assert.Inconclusive("An exception is expected!");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--(Comparator(Head.Next.Value, obj) == 0)-->
        [TestMethod, TestCategory("LinkedList")]
        public void Remove_ListSizeEqualsOne_Object()
        {
            //Arrange
            _linkedList.Add(10);
            //Act

            bool result =_linkedList.Remove(10);
            //Assert
            Assert.IsTrue(result, "An Object with value ten is expected!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--(previous != null)-->
        [TestMethod, TestCategory("LinkedList")]
        public void Remove_ElementInMiddleOfList_Object()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Act
            bool result = _linkedList.Remove(2);
            //Assert
            Assert.IsTrue(result, "An Object with value one is expected!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--(previous != null)-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(ElementNotFoundException))]
        public void Remove_ThereAreNotElementsInTheList_Exception()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Act
            bool result = _linkedList.Remove(5);
            //Assert
            Assert.Inconclusive("An exception is expected because the element doesn't exist in the collection!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--if(Empty())-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(EmptyCollectionException))]
        public void Retrieve_ThereIsNotElementsInTheList_Exception()
        {
            //Arrange
            //Act
            int? result = _linkedList.Retrieve(5);
            //Assert
            Assert.Inconclusive("An exception is expected because there is no elements in the list!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho.
        /// </summary>
        /// <!--if (obj == null)-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(NullObjectException))]
        public void Retrieve_SearchWithNullObject_Exception()
        {
            //Arrange
            _linkedList.Add(2);
            //Act
            _linkedList.Retrieve(null);
            //Assert
            Assert.Inconclusive("An exception is expected because a null object isn't allowed!");
        }


        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Pular o while sem executar nenhuma vez.
        /// </summary>
        /// <!--while (current != null && Comparator(current.Value, obj) != 0)-->
        [TestMethod, TestCategory("LinkedList")]
        public void Retrieve_RetrieveFirstElement_Object()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            //Act
            int? result = _linkedList.Retrieve(1);
            //Assert
            Assert.IsTrue(result == 1,"The element with value one is expected!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Pular o while pelo somente uma vez.
        /// </summary>
        /// <!--while (current != null && Comparator(current.Value, obj) != 0)-->
        [TestMethod, TestCategory("LinkedList")]
        public void Retrieve_ElementInTheEndOfList_Object()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Act
            int? result = _linkedList.Retrieve(3);
            //Assert
            Assert.IsTrue(result == 3, "The element with value three is expected!");
        }

        /// <summary>
        /// Técnica: Particionamento.
        /// Objetivo: Recuperar um elemento que não existe na lista.
        /// </summary>
        [TestMethod, TestCategory("LinkedList")]
        public void Retrieve_ElementDoesNotExistInList_Object()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Act
            int? result = _linkedList.Retrieve(5);
            //Assert
            Assert.IsTrue(result == null,"The element does not exist in the list!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho do if.
        /// </summary>
        /// <!--if (Empty())-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(EmptyCollectionException))]
        public void First_EmptyList_Exception()
        {
            //Arrange
            //Act
            _linkedList.First();
            //Assert
            Assert.Inconclusive("The exception is expected because the list is empty!");
        }

        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho do if.
        /// </summary>
        /// <!--if (Empty())-->
        [TestMethod, TestCategory("LinkedList")]
        public void First_ThereAreElementsInTheList_FisrtObject()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Act
            int? result = _linkedList.First();
            //Assert
            Assert.IsTrue(result == 1, "The element with value one is expected!");
        }


        /// <summary>
        /// Técnica: Caminho.
        /// Objetivo: Executar o caminho do if.
        /// </summary>
        /// <!--if (Empty())-->
        [TestMethod, TestCategory("LinkedList"), ExpectedException(typeof(EmptyCollectionException))]
        public void Last_EmptyList_Exception()
        {
            //Arrange
            //Act
            _linkedList.Last();
            //Assert
            Assert.Inconclusive("The exception is expected because the list is empty!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço nenhuma vez.
        /// </summary>
        /// <!--while (current.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void Last_ElementInTheHead_LastObject()
        {
            //Arrange
            _linkedList.Add(1);

            //Act
            int? result = _linkedList.Last();
            //Assert
            Assert.IsTrue(result == 1, "The element with value one is expected!");
        }

        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço uma vez.
        /// </summary>
        /// <!--while (current.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void Last_ElementInTheEnd_LastObject()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            //Act
            int? result = _linkedList.Last();
            //Assert
            Assert.IsTrue(result == 2, "The element with value one is expected!");
        }


        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço nenhuma vez.
        /// </summary>
        /// <!--while (current.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void GetEnumerator_ThereAreNotElementInTheList_Object()
        {
            //Arrange
            //Act
            foreach (int? item in _linkedList)
            {
                Assert.IsTrue(false);
            }
            //Assert
            Assert.IsTrue(true);
        }


        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço uma vez.
        /// </summary>
        /// <!--while (current.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void GetEnumerator_OneElement_Object()
        {
            //Arrange
            int?[] vectorInput = new int?[1] {1};
            foreach (int? item in vectorInput)
            {
                _linkedList.Add(item);
            }

            int? []vectorResult = new int?[1];
            int count = 0;
            //Act
            foreach (int? item in _linkedList)
                vectorResult[count++] = item;

            //Assert
            bool areEquals = true;
            for(int i = 0; i < vectorInput.Length; i++)
            {
                areEquals = vectorInput[i] == vectorResult[i];
                if (!areEquals)
                    break;
            }
            Assert.IsTrue(areEquals);
        }
        
        /// <summary>
        /// Técnica: Ciclo.
        /// Objetivo: Executar o laço N vezes.
        /// </summary>
        /// <!--while (current.HasNext())-->
        [TestMethod, TestCategory("LinkedList")]
        public void GetEnumerator_ThreeElements_Object()
        {
            //Arrange
            int?[] vectorInput = new int?[3] { 1,2,3 };
            foreach (int? item in vectorInput)
            {
                _linkedList.Add(item);
            }

            int?[] vectorResult = new int?[3];
            int count = 0;
            //Act
            foreach (int? item in _linkedList)
                vectorResult[count++] = item;

            //Assert
            bool areEquals = true;
            for (int i = 0; i < vectorInput.Length; i++)
            {
                areEquals = vectorInput[i] == vectorResult[i];
                if (!areEquals)
                    break;
            }
            Assert.IsTrue(areEquals);
        }

        /// <summary>
        /// Técnica: Caminho
        /// </summary>
        [TestMethod, TestCategory("LinkedList")]
        public void Clear_FilledList_EmptyList()
        {
            //Arrange
            _linkedList.Add(1);
            _linkedList.Add(2);
            _linkedList.Add(3);
            //Act
            _linkedList.Clear();
            //Assert
            Assert.IsTrue(_linkedList.IsEmpty());
        }
    }
}
