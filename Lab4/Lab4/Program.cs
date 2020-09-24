using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            SkipList<int, int> SkipList = new SkipList<int, int>();

            var startTime = System.Diagnostics.Stopwatch.StartNew();

            int[] Mas = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                Random rnd = new Random();
                Mas[i] = rnd.Next(0, 10000);
            }

            for (int i = 0; i < 10000; i++)
            {
                SkipList.Add(i, Mas[i]);
            }

            for (int i = 5000; i < 7000; i++)
            {
                SkipList.Delete(i);
            }

            for (int i = 0; i < 10000; i++)
            {
                SkipList.ContainsKey(i);
            }

            var resultTime = startTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);

            Console.WriteLine("Время работы моего SkipList {0}", elapsedTime);



            SortedList<int, int> Dict = new SortedList<int, int>();

            var startDictTime = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                Dict.Add(i, Mas[i]);

            }
            for (int i = 5000; i < 7000; i++)
            {
                Dict.Remove(i);
            }
            int value = 0;
            for (int i = 0; i < 10000; i++)
            {
                Dict.TryGetValue(i, out value);
            }


            var resultDictTime = startDictTime.Elapsed;
            string elapsedDictTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultDictTime.Hours,
                resultDictTime.Minutes,
                resultDictTime.Seconds,
                resultDictTime.Milliseconds);

            Console.WriteLine("Время работы SortedList {0}", elapsedDictTime);
        }
    }
}
