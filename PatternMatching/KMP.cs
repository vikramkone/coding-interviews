using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    static class KMP
    {
        public static int[] BuildLPSArray(string substring)
        {
            int[] lps;

            lps = new int[substring.Length];
            int len = 0;
            lps[0] = 0;

            for(int i = 1; i < substring.Length;)
            {
                if (substring[i] == substring[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }

        public static List<int> FindSubstring(string txt, string pat)
        {
            int M = pat.Length;
            int N = txt.Length;
            List<int> result = new List<int>();

            int [] lps = BuildLPSArray(pat);

            int j = 0;
            int i = 0;

            while(i < N)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }

                if (j == M)
                {
                    result.Add(i - j);
                    j = lps[j - 1];
                } else if (i < N && pat[j] != txt[i])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            return result;
        }
    }
}
