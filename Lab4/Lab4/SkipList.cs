using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Lab4
{
    class SkipList<TKey, TValue> :
            IEnumerable<KeyValuePair<TKey, TValue>>
            where TKey : IComparable<TKey>
    {
        public int Count { get; private set; }

        private Node<TKey, TValue>[] _head;
        private int _listLvl;

        private const int _maxLvl = 10;
        private const double _probability = 0.5;
        //private Random random = new Random();
        //private int listLevel;
        //private int count;
        //private long version = 0;
        //private ResourceManager resManager;

        public SkipList()
        {
            this._head = new Node<TKey, TValue>[_maxLvl];
            for (int i = 0; i < _maxLvl; i++)
            {
                _head[i] = new Node<TKey, TValue>();
                if (i == 0) continue;
                _head[i - 1].Up = _head[i];
                _head[i].Down = _head[i - 1];
            }
        }

        public bool CoinFlip()
        {
            Random rd = new Random();
            double Flip = rd.NextDouble();
            return (Flip < _probability);
        }
        
        public void Add(TKey Key, TValue Value)
        {
            Node<TKey, TValue>[] Prev = new Node<TKey, TValue>[_maxLvl];
            Node<TKey, TValue> cur = _head[_listLvl];
            for (int i = _listLvl; i > -1; i--)
            {
                while (cur.Next != null && cur.Next.Key.CompareTo(Key) < 0)
                {
                    cur = cur.Next;
                }
                Prev[i] = cur;
                if (cur.Down == null)
                    break;
                cur = cur.Down;
            }
            int lvl = 0;
            while(CoinFlip() && lvl < _maxLvl - 1)
            {
                lvl++;

            }
            while(_listLvl < lvl)
            {
                _listLvl++;
                Prev[_listLvl] = _head[_listLvl];

            }
            Node<TKey, TValue> Node = new Node<TKey, TValue>(Key, Value, Prev[0].Next);
            Prev[0].Next = Node;
            for (int i = 1; i <= lvl; i++)//sssssssssssssssssssssssssssssssssssssssss
            {
                Node = new Node<TKey, TValue>(Key, Value, Prev[i].Next);
                Prev[i].Next = Node;
                Node.Down = Prev[i - 1].Next;
                Prev[i - 1].Next.Up = Node;
            }
            Count++;
        }
       
        private TValue Search(TKey Key, bool Delete)
        {
            int Lvl = _listLvl;
            Node<TKey, TValue> Cur = _head[_listLvl];

            while (Lvl >= 0)
            {
                while (Cur.Next != null && Cur.Next.Key.CompareTo(Key) < 0)
                {
                    Cur = Cur.Next;
                }

                if (Cur.Next != null && Cur.Next.Key.Equals(Key))
                {
                    if (Delete)
                    {
                        Cur.Next = Cur.Next.Next;
                        Count--;
                    }
                    else
                        return Cur.Next.Value;

                }

                if (Cur.Down != null)
                {
                    Cur = Cur.Down;
                }
                Lvl--;
            }
            return default(TValue);
        }
        public TValue GetValue(TKey Key)
        {
            return Search(Key, false);
        }
        public void Delete(TKey Key)
        {
            Search(Key, true);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (var node = _head[0].Next; node.Next != null; node = node.Next)
            {
                yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var node = _head[0].Next; node.Next != null; node = node.Next)
            {
                yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
            }
        }


    }
}
