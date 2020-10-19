using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class RabinCarp: IStringSearchingAlgorithm
    {
        private int Hash(string x)
        {
            int q = 31;
            int rez = 0;
            for (int i = 0; i < x.Length; i++)
            {
                rez += x[i] * (int)Math.Pow(20, x.Length - i - 1);
            }
            return rez % q;
        }
        public List<int> StringSearchingHash(string sub, string s)
        {
            List<int> IndexOf = new List<int>();

            var hsub = Hash(sub);
            var hs = Hash(s.Substring(0, sub.Length));

            for (int i = 0; i <= s.Length - sub.Length; i++)
            {
                if (hsub == hs)
                {
                    for (int j = 0; j < sub.Length; j++)
                    {
                        if (s[i + j] != sub[j])
                        {
                            goto outbreek;
                        }
                    }
                    IndexOf.Add(i);
                outbreek:;
                }
                else
                {
                    hs = Hash(s.Substring(i, sub.Length));
                }
            }

            return IndexOf;
        }

        public List<int> StringSearching(string pattern, string text) // по книге
        {

            var d = 256;
            var q = 331;

            List<int> IndexOf = new List<int>();
            var n = text.Length;
            var m = pattern.Length;
            if (pattern.Length > text.Length) return IndexOf;

            var h = Math.Pow(d, m - 1) % q;
            double p = 0;
            double t = 0;

            for (int i = 0; i < m; i ++)
            {
                p += (d + (int)pattern[i]) % q;
                t += (d + (int)text[i]) % q;
            }
            for (int i = 0; i <= n - m ; i++)
            {
                if (p == t)
                {
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if (text[i + j] != pattern[j])
                        {
                            goto outbreek;
                        }
                    }
                    IndexOf.Add(i);
                outbreek:;
                }
                else
                {
                    t = (d * (t - (int)text[i] * h) + (int)text[i + m - 1]) % q;
                }
            }

            return IndexOf;
        }


    }
}
