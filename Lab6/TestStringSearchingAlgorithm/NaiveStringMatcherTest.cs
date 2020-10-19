using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;
using System.Collections.Generic;


namespace TestStringSearchingAlgorithm
{
    [TestClass]
    public class NaiveStringMatcherTest
    {
        [TestMethod]
        public void TestMethodBruteForce()
        {
            var br = new NaiveStringMatcher();

            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4}, br.StringSearching("aa", "aaaaaa"));
        }
    }
}
