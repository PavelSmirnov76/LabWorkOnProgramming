using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    class Program
    {
        static List<string> CheckWorkMyCollection(string[] MasWord)
        {

            var HT = new HashTable<string, int>();

            for(int i = 0; i < MasWord.Length;i++)
            {
                if (!HT.ContainsKey(MasWord[i]))
                {
                    HT.Add(MasWord[i], 1);
                }
                else
                {
                    HT[MasWord[i]]++;
                }
               
            }
            List<string> word = new List<string>();
            foreach (var c in HT)
            {
                if (c.Key.Length == 7)
                {
                    word.Add(c.Key);
                    HT.Remove(c.Key);
                }
            }
            return word;
        }
        static List<string> CheckWorkDictionary(string[] MasWord)
        {

            Dictionary<string, int> HT = new Dictionary<string, int>();

            for (int i = 0; i < MasWord.Length; i++)
            {
                if (!HT.ContainsKey(MasWord[i]))
                {
                    HT.Add(MasWord[i], 1);
                }
                HT[MasWord[i]]++;

            }
            List<string> word = new List<string>();
            foreach (var c in HT)
            {
                if (c.Key.Length == 7)
                {
                    word.Add(c.Key);
                    HT.Remove(c.Key);
                }
            }
            return word;
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("WarAndWorld.txt");
            string[] MasWord = sr.ReadToEnd().Split(' ');
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            List<string> word = CheckWorkMyCollection(MasWord);
            var resultTime = startTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);

            Console.WriteLine("Время работы моей хеш таблицы {0}", elapsedTime);




            startTime = System.Diagnostics.Stopwatch.StartNew();
            word = CheckWorkDictionary(MasWord);
            resultTime = startTime.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);

            Console.WriteLine("Время работы Dictionary {0}", elapsedTime);



        }
    }
}
