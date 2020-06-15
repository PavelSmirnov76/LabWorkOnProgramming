using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab2
{
    class AVLTree<TKey, TValue> : IEnumerable<Node<TKey, TValue>> where TKey : IComparable<TKey>
    {
        public int Height { set; get; }
        private Node<TKey, TValue> Head { set; get; }


        public AVLTree()
        {
            Height = 0;
            
        }


        public void Add(TKey Key, TValue value)
        {
            if (Head == null)
            {
                Head = new Node<TKey, TValue>(Key, value);
                return;
            }
            Node<TKey, TValue> SubTree = Head;
            while (SubTree != null)
            {
                if (SubTree.Key.CompareTo(Key) == -1)
                {
                    if (SubTree.Right == null)
                    {
                        SubTree.Right = new Node<TKey, TValue>(Key, value, SubTree);
                        ChangeBalanceTreeAdd(SubTree, -1);
                        break;
                    }
                    else
                    {
                        SubTree = SubTree.Right;
                    }
                }
                else if (SubTree.Key.CompareTo(Key) == 1)
                {
                    if (SubTree.Left == null)
                    {
                        SubTree.Left = new Node<TKey, TValue>(Key, value, SubTree);
                        ChangeBalanceTreeAdd(SubTree, 1);
                        break;
                    }
                    else
                    {
                        SubTree = SubTree.Left;
                    }
                }
                else
                {
                    SubTree.Value = value;
                    break;
                }

            }

        }
        private void ChangeBalanceTreeAdd(Node<TKey, TValue> Node, int addBalance)
        {
            while (Node != null)
            {
                Node.Balance += addBalance;


                if (Node.Balance == 0)
                {
                    break;
                }
                else if (Node.Balance == 2)
                {
                    if (Node.Left.Balance == 1)
                    {
                        RotateLeftLeft(Node);
                    }
                    else
                    {
                        RotateLeftRight(Node);
                    }
                    break;
                }

                else if (Node.Balance == -2)
                {
                    if (Node.Right.Balance == -1)
                    {
                        RotateRightRight(Node);
                    }
                    else
                    {
                        RotateRightLeft(Node);
                    }
                    break;
                }

                if (Node.Parent != null)
                {
                    if (Node.Parent.Left == Node)
                    {
                        addBalance = 1;
                    }
                    else
                    {
                        addBalance = -1;
                    }
                }
                Node = Node.Parent;
            }
        }


        // ПОВОРОТЫ.......................................................................
        private void RotateLeftRight(Node<TKey, TValue> Node)
        {
            Node<TKey, TValue> Left = Node.Left;
            Node<TKey, TValue> LeftRight = null;
            if (Left != null)
                LeftRight = Left.Right;
            Node<TKey, TValue> LeftRightLeft = null;
            if (LeftRight != null)
            {
                LeftRightLeft = LeftRight.Left;
            }

            Node.Left = LeftRight;

            if (LeftRight != null)
            {
                LeftRight.Parent = Node;
                LeftRight.Left = Left;
                LeftRight.Balance++;
            }

            if (Left != null)
            {
                Left.Parent = LeftRight;
                Left.Right = LeftRightLeft;
                Left.Balance++;
            }

            if (LeftRightLeft != null)
            {
                LeftRightLeft.Parent = Left;
            }

            RotateLeftLeft(Node);
        }
        private void RotateLeftLeft(Node<TKey, TValue> Node)
        {
            Node<TKey, TValue> Left = Node.Left;
            Node<TKey, TValue> LeftRight = null;
            Node<TKey, TValue> Parent = Node.Parent;

            if (Left != null)
            {
                LeftRight = Left.Right;
                Left.Parent = Parent;
                Left.Right = Node;
                Left.Balance--;
                Node.Balance = -Left.Balance;
            }

            Node.Parent = Left;
            Node.Left = LeftRight;

            if (LeftRight != null)
            {
                LeftRight.Parent = Node;
            }

            if (Node == this.Head)
            {
                this.Head = Left;
            }
            else if (Parent.Left == Node)
            {
                Parent.Left = Left;
            }
            else
            {
                Parent.Right = Left;
            }

        }
        private void RotateRightLeft(Node<TKey, TValue> Node)
        {
            Node<TKey, TValue> Right = Node.Right;
            Node<TKey, TValue> RightLeft = null;
            Node<TKey, TValue> RightLeftRight = null;

            if (Right != null)
            {
                RightLeft = Right.Left;
            }
            if (RightLeft != null)
            {
                RightLeftRight = RightLeft.Right;
            }

            Node.Right = RightLeft;

            if (RightLeft != null)
            {
                RightLeft.Parent = Node;
                RightLeft.Right = Right;
                RightLeft.Balance--;
            }

            if (Right != null)
            {
                Right.Parent = RightLeft;
                Right.Left = RightLeftRight;
                Right.Balance--;
            }

            if (RightLeftRight != null)
            {
                RightLeftRight.Parent = Right;
            }

            RotateRightRight(Node);
        }
        private void RotateRightRight(Node<TKey, TValue> Node)
        {
            Node<TKey, TValue> Right = Node.Right;
            Node<TKey, TValue> RightLeft = null;
            Node<TKey, TValue> parent = Node.Parent;

            if (Right != null)
            {
                RightLeft = Right.Left;
                Right.Parent = parent;
                Right.Left = Node;
                Right.Balance++;
                Node.Balance = -Right.Balance;
            }

            Node.Right = RightLeft;
            Node.Parent = Right;

            if (RightLeft != null)
            {
                RightLeft.Parent = Node;
            }
            if (Node == this.Head)
            {
                this.Head = Right;
            }
            else if (parent.Right == Node)
            {
                parent.Right = Right;
            }
            else
            {
                parent.Left = Right;
            }
        }
        // Повороты кончились..........................................................


        // Удаление ....................................................................
        public void Delete(TKey key)
        {
            Node<TKey, TValue> Current = this.Head;
            while (Current != null)
            {
                if (Current.Key.CompareTo(key) == -1)
                {
                    Current = Current.Right;
                }
                else if (Current.Key.CompareTo(key) == 1)
                {
                    Current = Current.Left;
                }
                else
                {
                    if (Current.Left == null && Current.Right == null)
                    {
                        if (Current == Head)
                        {
                            Head = null;
                        }
                        else if (Current.Parent.Right == Current)
                        {
                            Current.Parent.Right = null;
                            ChangeBalanceTreeDelete(Current.Parent, 1);
                        }
                        else
                        {
                            Current.Parent.Left = null;
                            ChangeBalanceTreeDelete(Current.Parent, -1);
                        }
                    }
                    else if (Current.Left != null)
                    {
                        Node<TKey, TValue> RightMost = Current.Left;
                        while (RightMost.Right != null)
                        {
                            RightMost = RightMost.Right;
                        }

                        ReplaceNodes(Current, RightMost);
                        ChangeBalanceTreeDelete(RightMost.Parent, 1);
                    }
                    else
                    {
                        Node<TKey, TValue> leftMost = Current.Right;
                        while (leftMost.Left != null)
                        {
                            leftMost = leftMost.Left;
                        }

                        ReplaceNodes(Current, leftMost);
                        ChangeBalanceTreeDelete(leftMost.Parent, -1);
                    }
                    break;
                }
            }
        }
        private void ReplaceNodes(Node<TKey, TValue> sourceNode, Node<TKey, TValue> subtreeNode)
        {
            sourceNode.Key = subtreeNode.Key;
            sourceNode.Value = subtreeNode.Value;

            if (subtreeNode.Parent != null)
            {
                if (subtreeNode.Left != null)
                {
                    subtreeNode.Left.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.Left == subtreeNode)
                    {
                        subtreeNode.Parent.Left = subtreeNode.Left;
                    }
                    else
                    {
                        subtreeNode.Parent.Right = subtreeNode.Left;
                    }
                }
                else if (subtreeNode.Right != null)
                {
                    subtreeNode.Right.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.Left == subtreeNode)
                    {
                        subtreeNode.Parent.Left = subtreeNode.Right;
                    }
                    else
                    {
                        subtreeNode.Parent.Right = subtreeNode.Right;
                    }
                }
                else
                {
                    if (subtreeNode.Parent.Left == subtreeNode)
                    {
                        subtreeNode.Parent.Left = null;
                    }
                    else
                    {
                        subtreeNode.Parent.Right = null;
                    }
                }
            }
        }
        private void ChangeBalanceTreeDelete(Node<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                node.Balance += addBalance;
                addBalance = node.Balance;

                if (node.Balance == 2)
                {
                    if (node.Left != null && node.Left.Balance >= 0)
                    {
                        RotateLeftLeft(node);

                        if (node.Balance == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                }
                else if (node.Balance == -2)
                {
                    if (node.Right != null && node.Right.Balance <= 0)
                    {
                        RotateRightRight(node);

                        if (node.Balance == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                }
                else if (node.Balance != 0)
                {
                    return;
                }

                Node<TKey, TValue> parent = node.Parent;

                if (parent != null)
                {
                    if (parent.Left == node)
                    {
                        addBalance = -1;
                    }
                    else
                    {
                        addBalance = 1;
                    }
                }
                node = parent;
            }
        }

        // поиск ................
        public TValue GetValue(TKey key)
        {
            Node<TKey, TValue> Current = Head;
            while (Current != null)
            {
                if (Current.Key.CompareTo(key) == -1)
                {
                    Current = Current.Right;
                }
                else if (Current.Key.CompareTo(key) == 1)
                {
                    Current = Current.Left;
                }
                else
                {
                    return Current.Value;
                }
            }
            return default(TValue);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<Node<TKey, TValue>> GetEnumerator()
        {
            Queue<Node<TKey, TValue>> queue = new Queue<Node<TKey, TValue>>();
            queue.Enqueue(Head);

            Node<TKey, TValue> tmp;
            while (queue.Count > 0)
            {
                tmp = queue.Dequeue();

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
