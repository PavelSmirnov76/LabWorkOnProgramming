using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;
using System.Collections.Generic;


namespace TestStringSearchingAlgorithm
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodBruteForce()
        {
            List<int> Otvet = new List<int>();
            string str = "aaavvvaaacccxxzxcazxc";
            string strSub = "aaa";
            BruteForceAlgorithm br = new BruteForceAlgorithm();
            Otvet = br.StringSearching(strSub, str);

            int ActualOtvet = Otvet[1];

            int ExpectedOtvet = 6;

            Assert.AreEqual(ActualOtvet, ExpectedOtvet);
        }
        [TestMethod]
        public void TestMethodRabinCarp()
        {
            List<int> Otvet = new List<int>();
            string str = "aaavvvaaacccxxzxcazxc";
            string strSub = "aaa";
            RabinCarp br = new RabinCarp();
            Otvet = br.StringSearching(strSub, str);

            int ActualOtvet = Otvet[1];

            int ExpectedOtvet = 6;

            Assert.AreEqual(ActualOtvet, ExpectedOtvet);
        }
    }
}
