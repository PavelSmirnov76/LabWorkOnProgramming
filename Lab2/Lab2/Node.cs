using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Node<TKey,TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Node<TKey, TValue> Parent { get; set; }
        public Node<TKey, TValue> Left { get; set; }
        public Node<TKey, TValue> Right { get; set; }

        public int Balance { get; set; }

        public Node(TKey Key, TValue Value)
        {
            this.Key = Key;
            this.Value = Value;
            this.Parent = null;
            this.Left = null;
            this.Right = null;       
            this.Balance = 0;
        }
        public Node(TKey Key, TValue Value, Node<TKey, TValue> Parent)
        : this(Key, Value)
        {
            this.Parent = Parent;
        }

        public Node(Node<TKey, TValue> node)
            : this(node.Key, node.Value, node.Parent)
        {
            this.Left = node.Left;
            this.Right = node.Right;
        }
        public override string ToString()
        {
            return String.Format($"{Key} - {Value}");
        }
    }
}
