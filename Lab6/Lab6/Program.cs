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
            StreamReader sr = new StreamReader("anna.txt");
            Console.WriteLine("Введите подстроку");
            string strSub = Console.ReadLine();
            string str = sr.ReadToEnd();

            List<int> Otvet = new List<int>();
            BruteForceAlgorithm br = new BruteForceAlgorithm();
            Otvet = br.StringSearching(strSub, str);
            Console.WriteLine("Ал­го­ритм про­сто­го по­ис­ка под­строк");
            foreach(int c in Otvet)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
            Console.WriteLine("Ал­го­ритм Ра­би­на-Кар­па");
            RabinCarp Rc = new RabinCarp();
            Otvet = Rc.StringSearching(strSub, str);

            foreach (int c in Otvet)
            {
                Console.Write($"{c} ");
            }



        }
    }
}
