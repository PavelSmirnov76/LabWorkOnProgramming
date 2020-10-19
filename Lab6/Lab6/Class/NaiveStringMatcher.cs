using System.Collections.Generic;

namespace Lab6
{
    public class NaiveStringMatcher : IStringSearchingAlgorithm
    {
        public List<int> StringSearching(string pattern, string text)
        {
            List<int> IndexOf = new List<int>();

            for (int i = 0; i <= text.Length - pattern.Length; i++)
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

            return IndexOf;
        }
    }
}
