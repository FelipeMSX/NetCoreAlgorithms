using Algorithms.Exceptions;
using Algorithms.Searchs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsTests.search
{
    [TestClass]
	public class SearchTests
	{
        private Search<int?> search;

        [TestInitialize]
        public void SetUp()
        {
            search = new Search<int?>(((x, y)
                => {
                    if (x > y)
                        return 1;
                    else
                    if (x < y)
                        return -1;
                    else
                        return 0;
                }));
        }
        #region WhiteboxTests

        /// <summary>
        /// Técnica: Caminho de Decisão.
        /// </summary>
        [TestMethod, TestCategory("Search"), ExpectedException(typeof(ComparerNotSetException))]
        public void BinarySearch_ComparerIsNull_Exception()
        {
            //Arrange
            List<int?> list = new List<int?>();
            search.Comparator = null;
            //Act
            search.BinarySearch(list, 1);
            //Assert
            Assert.Inconclusive("An exception was expected!");
        }

        /// <summary>
        /// Técnica: Caminho de Decisão. 
        /// </summary>
        [TestMethod, TestCategory("Search"), ExpectedException(typeof(NullObjectException))]
        public void BinarySearch_ListIsNull_Exception()
        {
            //Arrange
            List<int?> list = new List<int?>();
            //Act
            search.BinarySearch(null, 0);
            //Assert
            Assert.Inconclusive("An exception was expected because the list is a null value!");
        }

        /// <summary>
        /// Técnica: Caminho de Decisão. 
        /// </summary>
        [TestMethod, TestCategory("Search"), ExpectedException(typeof(NullObjectException))]
        public void BinarySearch_ItemIsNull_Exception()
        {
            //Arrange
            List<int?> list = new List<int?>();
            //Act
            search.BinarySearch(list, null);
            //Assert
            Assert.Inconclusive("An exception was expected because the item is a null value!");
        }

        /// <summary>
        /// Técnica: Caminho de Decisão e de limite.
        /// Objetivo: Executar o if.
        ///</summary>
        /// <!--(comparator(orderedArray[mid], item) >= 1)->
        [TestMethod, TestCategory("Search")]
        public void BinarySearch_RetrieveFirstPositionItem_Object()
        {
            //Arrange
            int?[] vector = new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            //Act
            int? result = search.BinarySearch(vector, 1);
            //Assert
            Assert.IsTrue(result == 1, "The object with the value 1 was expected!");
        }

        /// <summary>
        /// Técnica: Caminho de Decisão e de limite
        /// Objetivo: Executar o if.
        ///</summary>
        /// <!--(comparator(orderedArray[mid], item) <= -1)->
        [TestMethod, TestCategory("Search")]
        public void BinarySearch_RetrieveLastPositionItem_Object()
        {
            //Arrange
            int?[] vector = new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Act
            int? result = search.BinarySearch(vector, 10);
            //Assert
            Assert.IsTrue(result == 10, "The object with the value 1 was expected!");
        }


        /// <summary>
        /// Técnica: Teste de Ciclo.
        /// Objetivo: Pular o loop sem executá-lo nenhuma vez
        /// </summary>
        /// <!--while (left <= right)-->
        [TestMethod, TestCategory("Search")]
        public void BinarySearch_EmptyList_DefaultValue()
        {
            //Arrange
            List<int?> list = new List<int?>();
            //Act
            int? result = search.BinarySearch(list, 10);
            //Assert
            Assert.IsNull(result, "A null object was expected!");
        }

        /// <summary>
        /// Técnica: Teste de Ciclo.
        /// Objetivo: Executar o loop uma vez.
        /// </summary>
        /// <!--while (left <= right)-->
        [TestMethod, TestCategory("Search")]
        public void BinarySearch_ListHasOneItem_RetrieveObject()
        {
            //Arrange
            List<int?> list = new List<int?>{1};
            //Act
            int? result = search.BinarySearch(list, 1);
            //Assert
            Assert.IsTrue(result == 1, "The object with the name Beltrano was expected!");
        }

        #endregion

    }
}
