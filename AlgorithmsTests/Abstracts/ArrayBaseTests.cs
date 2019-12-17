using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsTests;
using Algorithms.Abstracts;
using Algorithms.Collections;
using Algorithms.Exceptions;

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
        private ArrayBase<int?> _arrayBase;

        [TestInitialize]
        public void TearUp()
        {
            _arrayBase = new StaticStack<int?>(Shared.DefaultIntComparison);
        }

    }
}
