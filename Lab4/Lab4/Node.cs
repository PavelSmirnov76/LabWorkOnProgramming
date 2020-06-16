using System;

namespace Lab4
{
    public class Node<TKey, TValue>
    {
        public TKey Key { set; get; }
        public TValue Value { set; get; }

        public Node<TKey, TValue> Next { set; get; }
        public Node<TKey, TValue> Up { set; get; }
        public Node<TKey, TValue> Down { set; get; }
        public Node(TKey Key,TValue Value)
        {
            this.Key = Key;
            this.Value = Value;
            
            this.Next = null;
            this.Up = null;
            this.Down = null;

        }
        public Node(TKey Key, TValue Value , Node<TKey, TValue> Next)
        {
            this.Key = Key;
            this.Value = Value;

            this.Next = Next;
            this.Up = null;
            this.Down = null;

        }
        public Node(){ }
    }
}
