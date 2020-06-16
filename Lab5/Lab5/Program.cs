using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Random rd = new Random();
            BinaryHeep<int> BH = new BinaryHeep<int>();
            for (int i = 0; i < n; i++)
            {
                int r = rd.Next(1, 30);
                BH.Add(r);
                Console.WriteLine(r);
            }
            BH.Peek();
            BH.Pop();
            Console.WriteLine("Ответ");
            Console.WriteLine(BH.Peek());
        }
    }
}
