using System;
using System.Collections.Generic;
using System.IO;

namespace BankParser
{
    public static class IndexFinder
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                return new List<int>();
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

    }
}
