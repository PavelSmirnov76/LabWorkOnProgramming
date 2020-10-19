using Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinaryTree.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void CreateBinaryTree_CountZero()
        {
            var tree = new BinaryTree<int, int>();

            Assert.AreEqual(0, tree.Count);
        }
        [TestMethod]
        public void BinaryTreeAdd_Value1()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(7, 1);

            Assert.AreEqual(1, tree.TryGetValue(7));
        }
        [TestMethod]
        public void BinaryTreeAdd_Count1()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(7, 1);

            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void BinaryTreeTryGetValue_Value6()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(7, 1);
            tree.Add(4, 11);
            tree.Add(3, 6);
            tree.Add(8, 3);

            Assert.AreEqual(6, tree.TryGetValue(3));
        }
        [TestMethod]
        public void BinaryTreeTryGetValue_throwInvalidOperationException_KeyNotFound()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(7, 1);
            tree.Add(4, 11);
            tree.Add(3, 6);
            tree.Add(8, 3);

            Assert.ThrowsException<InvalidOperationException>(() => tree.TryGetValue(11));
        }

        //                                               8                    
        //                                              / \                                           
        //                                             3   10                                                      
        //                                            / \    \                                                             
        //                                           1   6    14                
        //                                              / \   /                           
        //                                             4   7  13     
        //                                             \                                               
        //                                              5
          
        [TestMethod]                                     
        public void BinaryTreeDelete_Key3_NotFound()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(8, 1);
            tree.Add(3, 11);
            tree.Add(10, 6);
            tree.Add(1, 5);
            tree.Add(6, 12);
            tree.Add(14, 35);
            tree.Add(4, 41);
            tree.Add(5, 41);
            tree.Add(7, 254);
            tree.Add(13, 67);

            tree.Delete(3);

            Assert.ThrowsException<InvalidOperationException>(() => tree.TryGetValue(3));
        }

        [TestMethod]
        public void BinaryTreeDelete_Key6_NotFound()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(8, 1);
            tree.Add(3, 11);
            tree.Add(10, 6);
            tree.Add(1, 5);
            tree.Add(6, 12);
            tree.Add(14, 35);
            tree.Add(4, 41);
            tree.Add(5, 41);
            tree.Add(7, 254);
            tree.Add(13, 67);

            tree.Delete(6);

            Assert.ThrowsException<InvalidOperationException>(() => tree.TryGetValue(6));
        }
        [TestMethod]
        public void BinaryTreeDelete_Key3_CheckDependencies()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(8, 1);
            tree.Add(3, 11);
            tree.Add(10, 6);
            tree.Add(1, 5);
            tree.Add(6, 12);
            tree.Add(14, 35);
            tree.Add(4, 41);
            tree.Add(5, 41);
            tree.Add(7, 254);
            tree.Add(13, 67);

            tree.Delete(3);

            var path = "";

            foreach (var node in tree.Search())
            {
                path += node.Key;
            }

            Assert.AreEqual("841657101413", path);
        }
        [TestMethod]
        public void BinaryTreeDelete_Count3()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(7, 1);
            tree.Add(4, 11);
            tree.Add(3, 6);
            tree.Add(8, 3);

            tree.Delete(3);

            Assert.AreEqual(3, tree.Count);
        }
        [TestMethod]
        public void BinaryTreeSearch_Path3247658()
        {
            var tree = new BinaryTree<int, int>();

            tree.Add(3, 5);
            tree.Add(4, 7);
            tree.Add(2, 10);

            tree.Add(7, 10);

            tree.Add(8, 10);

            tree.Add(6, 10);

            tree.Add(5, 10);

            var path = "";

            foreach (var node in tree.Search())
            {
                path += node.Key;
            }

            Assert.AreEqual("3247658", path);
        }
    }
}
