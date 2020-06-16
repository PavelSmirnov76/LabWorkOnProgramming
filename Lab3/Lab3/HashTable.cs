using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class HashTable<TKey, TValue>
    {
        public int Length { set; get; }
        private int _size { set; get; }

        private Node<TKey, TValue>[] _items = null;

        private bool[] _deleted = null;
        public HashTable()
        {
            Length = 0;
            _size = 32;
            _items = new Node<TKey, TValue>[_size];
            _deleted = new bool[_size];
        }

        public void Add(TKey Key, TValue Value)
        {
            int x = GetHash1(Key);
            int y = GetHash2(Key);
            if (Length == _size)
                Resize();
            for (int i = 0; i < _size; i++)
            {
                if (_items[x] == null || _deleted[x])
                {
                    _deleted[x] = false;
                    _items[x] = new Node<TKey, TValue>(Key, Value);
                    return;
                }
                x = (x + y) % _size;
            }
        }
        public TValue Search(TKey Key)
        {
            int x = GetHash1(Key);
            int y = GetHash2(Key);
            for (int i = 0; i < _size; i++)
            {
                if (_items[x] != null)
                    if (_items[x].Key.ToString() == Key.ToString() && !_deleted[x])
                    {
                        return _items[x].Value;
                    }
                    else
                        return default(TValue);
                x = (x + y) % _size;

            }
            return default(TValue);
        }
        public void Remove(TKey Key)
        {
            int x = GetHash1(Key);
            int y = GetHash2(Key);
            for (int i = 0; i < _size; i++)
            {
                if (_items[x] != null)
                    if (_items[x].Key.ToString() == Key.ToString())
                        _deleted[x] = true;
                    else;
                else
                    return;
                x = (x + y) % _size;
            }
        }

        private void Resize()
        {
            this._size = _size * 2;
            Array.Resize(ref _items, _size);
            Array.Resize(ref _deleted, _size);
        }
        private int GetHash1(TKey Key)
        {
            int Hash = Convert.ToInt32(Key);

            return Hash % _size;
        }
        private int GetHash2(TKey Key)
        {
            int Hash = Convert.ToInt32(Key);
            return 1 + Hash % (_size - 2);
        }
    }
}
