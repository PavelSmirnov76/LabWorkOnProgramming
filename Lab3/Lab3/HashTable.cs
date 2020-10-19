using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TKey:IComparable<TKey>
    {
        private int _size;      

        private Node<TKey, TValue>[] _items = null;
        public HashTable()
        {
            Count = 0;
            _size = 10001;
            _items = new Node<TKey, TValue>[_size];
        }

        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            int x = GetHash1(key);
            int y = GetHash2(key);
            if (_size - Count <= 0.2*_size)
                Resize();
            for (int i = 0; i < _size; i++)
            {
                if (_items[x] == null)
                {
                    _items[x] = new Node<TKey, TValue>(key, value);
                    Count++;
                    return;
                }
                if (_items[x].Key.CompareTo(key) == 0)
                {
                    return;
                }
                x = (x + y) % _size;
            }
        }
        public void Add(Node<TKey, TValue> node)
        {
            Add(node.Key, node.Value);
        }
        public bool ContainsKey(TKey key)
        {
            return (GetIndex(key) >= 0);
        }
        public bool GetValue(TKey key, out TValue value)
        {
            int index = GetIndex(key);
            if (index >= 0)
            {
                value = _items[index].Value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }
        private int GetIndex(TKey key)
        {
            int x = GetHash1(key);
            int y = GetHash2(key);

            while (_items[x] != null)
            {
                if (_items[x].Key.CompareTo(key) == 0)
                {
                    return x;
                }
                x = (x + y) % _size;


            }
            return -1;
        }
        public void Remove(TKey Key)
        {
            int x = GetHash1(Key);
            int y = GetHash2(Key);
            for (int i = 0; i < _size; i++)
            {
                if (_items[x] != null)
                {
                    if (_items[x].Key.CompareTo(Key) == 0)
                    {
                        _items[x] = null;
                        Count--;
                    }
                }
                else
                    return;
                x = (x + y) % _size;
            }
        }
        private void Resize()
        {

            var oldItems = _items;

            _size *= 4;
            _items = new Node<TKey, TValue>[_size];

            for (int i = 0; i < oldItems.Length;i++)
            {
                if (oldItems[i] != null)
                {
                    Add(oldItems[i]);                   
                }
            } 
        }
        private int GetHash1(TKey Key)
        {

            return Math.Abs(Key.GetHashCode()) % _size;
        }
        private int GetHash2(TKey Key)
        {
            return 1 + Math.Abs(Key.GetHashCode()) % (_size - 1);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for(int i = 0; i < _items.Length; i++)
            {
                if (_items[i] != null)
                {
                    yield return new KeyValuePair<TKey, TValue>(_items[i].Key, _items[i].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public TValue this[TKey key]
        {
            get
            {
                return _items[GetIndex(key)].Value;
            }
            set
            {
                _items[GetIndex(key)].Value = value;
            }
        }
    }
}
