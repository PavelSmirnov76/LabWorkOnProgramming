using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    interface IStringSearchingAlgorithm
    {
        public List<int> StringSearching(string needle, string haystack);
    }
}
