using System;
using OmegaCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmegaCoreTests.Iterators
{
    [TestClass]
    public class ListIteratorsTests
    {

        private IOmegaList<int?> _list;

        [TestInitialize]
        public void TearUp()
        {
        }

        [TestCleanup]
        public void TearDown()
        {
            _list = null;
        }
        [TestMethod]
        public void TestMethod1()
        {
        }


    }
}

