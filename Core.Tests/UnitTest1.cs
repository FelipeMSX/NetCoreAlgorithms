using Core.Iterators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestForEach teste = new TestForEach();
            teste.teste();
        }
    }
}