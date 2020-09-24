using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System;

namespace AVLTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAdd()
        {

            AVLTree<int, int> Tree = new AVLTree<int, int>();
            Random rd = new Random();
            int[] mas = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int eq = rd.Next(1, 30);
                mas[i] = eq;
                Tree.Add(i, eq);
            }

            bool ActualItem = Tree.ConteinsKey(3);

            bool ExpetctedItem = true;

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
        [TestMethod]
        public void TestMethodDelete()
        {

            AVLTree<int, int> Tree = new AVLTree<int, int>();
            Random rd = new Random();
            int[] mas = new int[10];


            for (int i = 0; i < 10; i++)
            {
                int eq = rd.Next(1,30);
                mas[i] = eq; 
                Tree.Add(i, eq);
            }

            for (int i = 0; i < 10; i += 2)
            {
                Tree.Delete(i);
            }

            bool ActualItem = Tree.ConteinsKey(3);

            bool ExpetctedItem = true;

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
        [TestMethod]
        public void TestParamCount()
        {

            AVLTree<int, int> Tree = new AVLTree<int, int>();
            Tree.Add(3, 1);
            Tree.Add(5, 2);

            int ActualItem = Tree.Count;

            int ExpetctedItem = 2;

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
        [TestMethod]
        public void TestmethodGetValue()
        {

            AVLTree<int, int> Tree = new AVLTree<int, int>();
            Tree.Add(3, 1);
            Tree.Add(5, 2);
            int value = 0;

            Tree.GetValue(5, out value);
            int ActualItem = value;

            int ExpetctedItem = 2;

            Assert.AreEqual(ExpetctedItem, ActualItem);
        }
    }
}
