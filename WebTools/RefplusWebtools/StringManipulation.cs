using System;
using System.Collections.Generic;

namespace RefplusWebtools
{
    class StringManipulation
    {
        private const string ReplacementString = "_";

        public static string FilterInvalidCharacters(string s)
        {
            Dictionary<string, int> dicValidChar = GetListOfValidCharacters();

            for (int i = 0; i < s.Length; i++)
            {
                int charval;
                if (!dicValidChar.TryGetValue(s.Substring(i, 1), out charval))
                {
                    s = s.Substring(0, i) + ReplacementString + (s.Length > i + 1 ? s.Substring(i + 1) : "");
                }
            }

            return s;
        }

        private static Dictionary<string, int> GetListOfValidCharacters()
        {
            var dicValidChars = new Dictionary<string, int>();

            //all STRING valid value from 32 to 125 in ascii table should be valid.
            for (int i = 32; i <= 125; i++)
            {
                string s = Convert.ToString((char)i);
                dicValidChars.Add(s, i);
            }

            return dicValidChars;
        }
    }
}
