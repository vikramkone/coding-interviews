using System.Collections.Generic;
using System.Linq;

namespace Substring
{
    static class BoyerMoore
    {
        public static List<int> FindSubstring(string s, string pattern)
        {
            var badMatchTable = BuildBadMatchTable(pattern);

            List<int> result = new List<int>();
            int currentBasisPositionOnString = 0;
            int maximumIndexToCheckOnString = s.Length - pattern.Length;

            while (currentBasisPositionOnString <= maximumIndexToCheckOnString)
            {
                int jOnPattern = pattern.Length - 1;
                int jOnString = currentBasisPositionOnString + jOnPattern;
                int initialJOnString = jOnString;

                while (jOnString >= currentBasisPositionOnString
                      && jOnPattern >= 0
                      && s[jOnString] == pattern[jOnPattern])
                {
                    jOnString--;
                    jOnPattern--;
                }

                if (jOnPattern == -1)
                {
                    result.Add(currentBasisPositionOnString);
                    currentBasisPositionOnString++;
                }
                else
                {
                    int charactersToMove = badMatchTable.Keys.Contains(s[initialJOnString]) ? badMatchTable[s[initialJOnString]] : badMatchTable['*'];
                    currentBasisPositionOnString += charactersToMove;
                }
            }

            return result;
        }

        public static Dictionary<char, int> BuildBadMatchTable(string pattern)
        {
            Dictionary<char, int> badMatchTable = new Dictionary<char, int>();
            int i = 0;

            for (; i < pattern.Length; i++)
            {
                if (!badMatchTable.Keys.Contains(pattern[i]))
                {
                    badMatchTable.Add(pattern[i], -1);
                }

                badMatchTable[pattern[i]] = pattern.Length - i - 1;
            }

            // The first element always receive the length of the pattern.
            badMatchTable[pattern[i - 1]] = pattern.Length;

            // We also always add another character to
            // represent the ones that did not show up
            // assigning it to length of the pattern.
            badMatchTable['*'] = pattern.Length;

            return badMatchTable;
        }
    }
}
