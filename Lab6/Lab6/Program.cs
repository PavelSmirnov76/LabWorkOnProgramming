using System;
using System.Text;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Otvet = new List<int>();
            string str = "aaavvvaaacccxxzxcazxc";
            string strSub = "aaa";
            BruteForceAlgorithm br = new BruteForceAlgorithm();
            Otvet = br.StringSearching(strSub, str);

            foreach(int c in Otvet)
                Console.Write($"{c} ");
            Console.WriteLine();

            RabinCarp rc = new RabinCarp();
            Otvet = rc.StringSearching(strSub, str);
            foreach (int c in Otvet)
                Console.Write($"{c} ");
            Console.WriteLine();

        }
    }
}
