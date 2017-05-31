using System;
using System.Collections.Generic;

namespace Substring
{
    static class FiniteStateAutomata
    {
        public static int FindSubstring(string s, string pattern)
        {
            var kmp = KMP.BuildLPSArray(pattern);
            var automata = BuildAutomata(kmp, pattern);
            var currentState = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (currentState == pattern.Length) return i - pattern.Length;
                var t = new Tuple<char, int>(s[i], currentState);
                currentState = automata.ContainsKey(t) ? automata[t] : 0;
            }

            return -1;
        }

        public static Dictionary<Tuple<char, int>, int> BuildAutomata(int[] kmp, string pattern)
        {
            var automata = new Dictionary<Tuple<char, int>, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                automata.Add(new Tuple<char, int>(pattern[i], i), i + 1);

                if (i != 0)
                {
                    automata.Add(new Tuple<char, int>(pattern[i - 1], i), kmp[i]);
                }
            }

            return automata;
        }
    }
}
