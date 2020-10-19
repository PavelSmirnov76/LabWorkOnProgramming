using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("WarAndWorld.txt");
            Console.WriteLine("Введите подстроку");

            var pattern = Console.ReadLine();
            var text = sr.ReadToEnd();

            var Otvet = new List<int>();
            var br = new NaiveStringMatcher();

            Console.WriteLine("Алгоритм прямого поиска подстрок");
            var startTime = System.Diagnostics.Stopwatch.StartNew();      
            
            Otvet = br.StringSearching(pattern, text);

            startTime.Stop();
            var resultTime = startTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
            Console.WriteLine("Время{0}", elapsedTime);

            Console.WriteLine("Результат:");
            foreach (int c in Otvet)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();

            
            Console.WriteLine("Алгоритм Рабина-Карпа.");
            var Rc = new RabinCarp();

            var startnewTime = System.Diagnostics.Stopwatch.StartNew();

            Otvet = Rc.StringSearchingHash(pattern, text);
            //Otvet = Rc.StringSearching(pattern, text);
             
            startnewTime.Stop();
            var resultnewTime = startnewTime.Elapsed;          
            var elapsednewTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultnewTime.Hours,
                resultnewTime.Minutes,
                resultnewTime.Seconds,
                resultnewTime.Milliseconds);
            Console.WriteLine("Время {0}", elapsednewTime);

            Console.WriteLine("Результат:");
            foreach (int c in Otvet)
            {
                Console.Write($"{c} ");
            }
        }
    }
}
