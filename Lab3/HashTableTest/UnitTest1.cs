using Lab3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HashTableTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAdd()
        {
            HashTable<int, int> HT = new HashTable<int, int>();
            Random rd = new Random();
            int[] mas = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int eq = rd.Next(1, 30);
                mas[i] = eq;
                HT.Add(i, eq);
                Assert.AreEqual(true, HT.ContainsKey(i));
            }
        }
        [TestMethod]
        public void TestMethodRemove()
        {
            HashTable<int, int> HT = new HashTable<int, int>();
            Random rd = new Random();
            int[] mas = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int eq = rd.Next(1, 30);
                mas[i] = eq;
                HT.Add(i, eq);
            }

            for(int i = 0; i < 10; i +=2)
            {
                HT.Remove(i);
            }
            for (int i = 1; i < 10; i += 2)
            {
                Assert.AreEqual(true, HT.ContainsKey(i));
            }
        }
        [TestMethod]
        public void TestMethodGetValue()
        {
            HashTable<int, int> HT = new HashTable<int, int>();
            Random rd = new Random();
            int[] mas = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int eq = rd.Next(1, 30);
                mas[i] = eq;
                HT.Add(i, eq);
            }

            int value = 0;

            HT.GetValue(3, out value);

            int ActualItem = value;

            int ExpetctedItem = mas[3];

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
        [TestMethod]
        public void TestParamLength()
        {
            HashTable<int, int> HT = new HashTable<int, int>();
            Random rd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int eq = rd.Next(1, 30);
                HT.Add(i, eq);
            }
        

            int ActualItem = HT.Length;

            int ExpetctedItem = 10;

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
        [TestMethod]
        public void TestIndexator()
        {
            HashTable<int, int> HT = new HashTable<int, int>();
            Random rd = new Random();

            for (int i = 0; i < 10; i++)
            {
                HT.Add(i, i);
            }


            int ActualItem = HT[3];

            int ExpetctedItem = 3;

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
        [TestMethod]
        public void TestCollizion()
        {
            HashTable<int, int> HT = new HashTable<int, int>();

            HT.Add(1, 1);
            HT.Add(33, 1);
            HT.Add(65, 1);

            HT.Remove(1);
            HT.Remove(33);

            bool ActualItem = true;

            bool ExpetctedItem = HT.ContainsKey(65);

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }

    }
}
