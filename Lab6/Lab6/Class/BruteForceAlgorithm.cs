using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class BruteForceAlgorithm : IStringSearchingAlgorithm
    {
        public List<int> StringSearching(string needle, string haystack)
        {
            List<int> IndexOf = new List<int>();

            for (int i = 0; i < haystack.Length - needle.Length; i++)
            {
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        goto outbreek;
                    }
                }
                //Console.WriteLine(i);
                IndexOf.Add(i);
                outbreek:;

            }

            return IndexOf;
        }
    }
}
