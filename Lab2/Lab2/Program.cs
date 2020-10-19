using System;
using System.Collections.Generic;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int, int>();

            var mas = new HashSet<int>();

            Random rnd = new Random();

            while(mas.Count < 10000)
            {               
                mas.Add(rnd.Next(0, 30000));
            }

            var M = new int[mas.Count];
            mas.CopyTo(M);

            var startTime = System.Diagnostics.Stopwatch.StartNew();

            foreach(var val in mas)
            { 
                tree.Add(val, 1);
            }

            for (int i = 5000; i < 7000; i++)
            {
                tree.Delete(M[i]);
            }

            int value = 0;
           
            for (int i = 0; i < 10000; i++)
            {
                tree.TryGetValue(M[i]);
            }
            startTime.Stop();
            var resultTime = startTime.Elapsed;
            
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);

            Console.WriteLine("Время работы моего дерева {0}", elapsedTime);



            SortedDictionary<int, int> Dict = new SortedDictionary<int, int>();

            var startDictTime = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                Dict.Add(M[i], i);

            }
            for (int i = 5000; i < 7000; i++)
            {
                Dict.Remove(M[i]);
            }
            value = 0;

            for (int i = 0; i < 10000; i++)
            {
                Dict.TryGetValue(M[i], out value);
            }

            startDictTime.Stop();
            var resultDictTime = startDictTime.Elapsed;
            string elapsedDictTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultDictTime.Hours,
                resultDictTime.Minutes,
                resultDictTime.Seconds,
                resultDictTime.Milliseconds);

            Console.WriteLine("Время работы SortedDictionary {0}", elapsedDictTime);


        }
    }
}
