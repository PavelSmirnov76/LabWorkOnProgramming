using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;
using System.Collections.Generic;


namespace TestStringSearchingAlgorithm
{
    [TestClass]
    public class RabinCarpTest
    {
        [TestMethod]
        public void TestMethodRabinCarp()
        {
            var br = new RabinCarp();

            CollectionAssert.AreEqual(new List<int> { 0, 1, 2 ,3 }, br.StringSearchingHash("aaa", "aaaaaa"));
        }
    }
}
