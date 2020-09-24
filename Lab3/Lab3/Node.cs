using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Node<TKey, TValue>
    {
        public TKey Key { set; get; }
        public TValue Value { set; get; }

        public Node(TKey Key, TValue Value)
        {
            this.Key = Key;
            this.Value = Value;

        }
        public override string ToString()
        {
            return $"{Key.ToString()} - {Value.ToString()}";
        }
       
    }
}
