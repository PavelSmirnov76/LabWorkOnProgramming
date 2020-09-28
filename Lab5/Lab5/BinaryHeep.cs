using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab5
{
    class BinaryHeep<T> where T : IComparable
    {
        private List<T> _list = new List<T>();

        public int Count { get; private set; }

        public BinaryHeep()
        {
            Count = 0;
        }
        public void Repair(int index)
        {
            int LeftIndex;
            int ReightIndex;
            int LargestIndex;

            for (; ; )
            {
                LeftIndex = 2 * index + 1;
                ReightIndex = 2 * index + 2;
                LargestIndex = index;

                if (LeftIndex < Count && _list[LeftIndex].CompareTo(_list[LargestIndex]) > 0)
                {
                    LargestIndex = LeftIndex;
                }

                if (ReightIndex < Count && _list[ReightIndex].CompareTo(_list[LargestIndex]) > 0)
                {
                    LargestIndex = ReightIndex;
                }

                if (LargestIndex == index)
                {
                    break;
                }

                T Temp = _list[index];
                _list[index] = _list[LargestIndex];
                _list[LargestIndex] = Temp;
                index = LargestIndex;
            }
        }

        public void Add(T Value)
        {
            Count++;
            _list.Add(Value);
            int Iterator = Count - 1;
            int ParentIterator = (Iterator - 1) / 2;

            while (Iterator > 0 && _list[ParentIterator].CompareTo(_list[Iterator]) < 0)
            {
                T Temp = _list[Iterator];
                _list[Iterator] = _list[ParentIterator];
                _list[ParentIterator] = Temp;

                Iterator = ParentIterator;
                ParentIterator = (Iterator - 1) / 2;
            }
        }


        public T Pop()
        {            
            if (IsEmpty())
                return default(T);
            T result = _list[0];
            _list[0] = _list[Count - 1];
            _list.RemoveAt(Count - 1);
            Count--;
            Repair(0);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            return _list[0];
        }
        private bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
