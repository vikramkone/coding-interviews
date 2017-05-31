using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    static class BruteForce
    {
        public static int FindSubstring(string s, string substring)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == substring[0])
                {
                    int k = i;
                    int j;
                    for (j = 0; j < substring.Length; j++, k++)
                    {
                        if (substring[j] != s[k])
                        {
                            break;
                        }
                    }

                    if (j == substring.Length)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
