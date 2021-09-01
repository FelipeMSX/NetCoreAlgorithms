using Algorithms.DesignPatterns.CreationalPatterns.Factory;
using Algorithms.Exceptions;
using Algorithms.Searchs;
using Algorithms_Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsTests.DesignPatterns.CreationalPatterns.Factory
{
    [TestClass]
	public class AbilityFactoryTests
	{

        private AbilityFactory _abilityFactory;

        [TestInitialize]
        public void SetUp()
        {
            _abilityFactory = new AbilityFactory();
        }
        #region WhiteboxTests

        /// <summary>
        /// Técnica: Caminho de Decisão.
        /// </summary>
        [TestMethod, TestCategory("DesignPattenrs"), Timeout(Shared.DEFAULT_TIMEOUT)]
        public void Count_CheckCurrentSize_Exception()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsTrue(_abilityFactory.Count == 4,"An exception was expected!");
        }

        #endregion

    }
}
