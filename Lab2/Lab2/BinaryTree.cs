using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class BinaryTreeNode<TKey, TValue>
    {
        public BinaryTreeNode() { }
        public BinaryTreeNode(TKey key, TValue value) 
        {
            this.Key = key;
            this.Value = value;
            this.Parent = null;
            this.Left = null;
            this.Right = null;
        }
        public BinaryTreeNode(TKey key, TValue value, BinaryTreeNode<TKey, TValue> parent)
        : this(key, value)
        {
            this.Parent = parent;
        }
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public BinaryTreeNode<TKey, TValue> Parent { get; set; }
        public BinaryTreeNode<TKey, TValue> Left { get; set; }
        public BinaryTreeNode<TKey, TValue> Right { get; set; }
    }
    public class BinaryTree<TKey,TValue> : IEnumerable<BinaryTreeNode<TKey, TValue>> where TKey : IComparable<TKey>
    {

        public int Count { get; set; }
        private BinaryTreeNode<TKey, TValue> Head { get; set; }

        public void Add(TKey key, TValue value)
        {
            if(Head == null)
            {
                Head = new BinaryTreeNode<TKey, TValue>(key, value);
                Count++;
                return;
            }
            var node = Head;

            while (node != null)
            {
                if (node.Key.CompareTo(key) == 1)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTreeNode<TKey, TValue>(key, value, node);
                        Count++;
                        return;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<TKey, TValue>(key, value, node);
                        Count++;
                        return;
                    }
                    node = node.Right;
                }
            }           
        }
        public void Delete(TKey key)
        {
            var node = Head;
            var route = 0;

            while (!node.Key.Equals(key))
            {
                if (node.Key.CompareTo(key) == 1)
                {
                    node = node.Left;
                    route = -1;
                }
                else
                {
                    node = node.Right;
                    route = 1;
                }
            }

            if (node.Left != null && node.Right == null)
            {
                node.Left.Parent = node.Parent;
                if (route == -1)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }
                Count--;
                return;
            }
            if (node.Right != null && node.Left == null)
            {
                node.Right.Parent = node.Parent;
                if (route == -1)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                Count--;
                return;
            }
            if (node.Right != null && node.Left != null)
            {
                var curNode = node.Right;
                while (curNode.Left != null)
                {
                    curNode = curNode.Left; 
                }

                if (curNode.Right != null)
                {
                    curNode.Right.Parent = curNode.Parent; 

                }
                curNode.Parent.Left = curNode.Right;

                node.Left.Parent = curNode;
                node.Right.Parent = curNode;

                if (route == -1)
                {
                    node.Parent.Left = curNode;
                }
                else
                {
                    node.Parent.Right = curNode;
                }
                curNode.Left = node.Left;
                curNode.Right = node.Right;
                curNode.Parent = node.Parent;
                Count--;
               
                return;
            }

            if (node.Right == null && node.Left == null)
            {
                if (route == -1)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                Count--;
                return;
            }

        }

        public TValue TryGetValue(TKey key)
        {
            var node = Head;

            while (!node.Key.Equals(key))
            {              
                if (node.Key.CompareTo(key) == 1)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
                if (node == null)
                {
                    throw new InvalidOperationException("key not found");
                }
            }
            
            return node.Value;
        }

        public List<BinaryTreeNode<TKey, TValue>> Search()
        {
            var way = new List<BinaryTreeNode<TKey, TValue>>();
            RecCLR(Head, way);
            return way;
        }

        private void RecCLR(BinaryTreeNode<TKey, TValue> node, List<BinaryTreeNode<TKey, TValue>> way)
        {
            if (node != null)
            {
                way.Add(node);
                RecCLR(node.Left, way);
                RecCLR(node.Right, way); 
            }
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<BinaryTreeNode<TKey, TValue>> IEnumerable<BinaryTreeNode<TKey, TValue>>.GetEnumerator()
        {
            var queue = new Queue<BinaryTreeNode<TKey, TValue>>();
            queue.Enqueue(Head);

            while (queue.Count > 0)
            {
                var tmp = queue.Dequeue();

                if (tmp.Left != null)
                {
                    queue.Enqueue(tmp.Left);
                }
                if (tmp.Right != null)
                {
                    queue.Enqueue(tmp.Right);
                }

                yield return tmp;
            }
        }
    }
}
