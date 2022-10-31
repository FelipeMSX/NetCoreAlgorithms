using System;
using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Iterators
{
    [TestClass]
    public class OmegaLINQTests
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

