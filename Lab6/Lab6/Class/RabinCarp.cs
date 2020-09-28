using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class RabinCarp: IStringSearchingAlgorithm
    { 
        public List<int> StringSearching(int[] needle, int[] haystack) // P == needle
        {
            List<int> IndexOf = new List<int>();

            int q = 101;
            int d = 256;

            int m = needle.Length;
            int n = haystack.Length;

            int h = (int)Math.Pow(d, m - 1) % q;

            int p = 0;
            int[] t = new int[n - m];

            for (int i = 0; i < m; i++)
            {
                p = (d * p + needle[i]) % q;
                t[0] = (d * t[0] + haystack[i]) % q;
            }
            for (int s = 0; s < n - m; s++)
            {
                if (p == t[s])
                {
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (haystack[s + j] != needle[j])
                        {
                            goto outbreek;
                        }
                    }
                    Console.WriteLine(s);
                outbreek:;
                }
                if (s<n-m-1)
                {
                    t[s+1] = (d * (t[s] - haystack[s] * h) + haystack[s + m]) % q;
                }
            }

            return IndexOf;
        }

        private int Hash(string x)
        {
            int p = 31;
            int rez = 0; 
            for (int i = 0; i < x.Length; i++)
            {
                rez += (int)Math.Pow(p, x.Length - 1 - i) * (int)(x[i]);
            }
            return rez;
        }

        public List<int> StringSearching(string x, string s)
        {
            List<int> IndexOf = new List<int>();
            if (x.Length > s.Length) return IndexOf; 
            int xhash = Hash(x); 
            int shash = Hash(s.Substring(0, x.Length)); 
            bool flag;
            int j;
            for (int i = 0; i < s.Length - x.Length; i++)
            {
                if (xhash == shash)
                {
                    flag = true;
                    j = 0;
                    while ((flag == true) && (j < x.Length))
                    {
                        if (x[j] != s[i + j]) goto outbreek;
                        j++;
                    }
                    IndexOf.Add(i);
                outbreek:;
                }
                else
                    shash = (shash - (int)Math.Pow(31, x.Length - 1) * (int)(s[i])) * 31 + (int)(s[i + x.Length]);
            }

            return IndexOf;
        }
    }
}
