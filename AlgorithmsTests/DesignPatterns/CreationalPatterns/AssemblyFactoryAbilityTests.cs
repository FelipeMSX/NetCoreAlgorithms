using Algorithms.DesignPatterns.CreationalPatterns.Factory;
using Algorithms_Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests.DesignPatterns.CreationalPatterns.Factory
{
    [TestClass]
	public class AssemblyFactoryAbilityTests
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

        /// <summary>
        /// </summary>
        [TestMethod, TestCategory("DesignPattenrs"), Timeout(Shared.DEFAULT_TIMEOUT)]
        public void CreateInstance_GettingFirstType_Success()
        {
            //Arrange
            //Act
            Ability ability = _abilityFactory.GetFactory<FireAbility>();
            //Assert
            Assert.IsTrue(ability.Name == "Fire", $"The fire instance was expected, " +
                $"but I got something different - {ability.GetType()}.");
        }

        /// <summary>
        /// </summary>
        [TestMethod, TestCategory("DesignPattenrs"), Timeout(Shared.DEFAULT_TIMEOUT)]
        public void CreateInstance_GettingAnotherType_Success()
        {
            //Arrange
            //Act
            Ability ability = _abilityFactory.GetFactory<PoisonAbility>();
            //Assert
            Assert.IsTrue(ability.Name == "Poison", "An exception was expected!");
        }

        /// <summary>
        /// </summary>
        [TestMethod, TestCategory("DesignPattenrs"), Timeout(Shared.DEFAULT_TIMEOUT)]
        public void CreateInstance_GettingNullableClass_Success()
        {
            //Arrange
            //Act
            Ability ability = _abilityFactory.GetFactory<NullableAbility>();
            //Assert
            Assert.IsTrue(ability.Name == "Nullable", $"The fire instance was expected, " +
                $"but I got something different - {ability.GetType()}.");
        }

        #endregion

    }
}
