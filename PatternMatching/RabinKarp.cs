using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    static class RabinKarp
    {
        private static int Prime = 3;
        private static Dictionary<char, int> dic = new Dictionary<char, int>();
        private static int LastHash = -1;
        private static char LastFirstLetter = '%';

        public static void SetupDic()
        {
            dic.Add('a', 1);
            dic.Add('b', 2);
            dic.Add('c', 3);
            dic.Add('d', 4);
            dic.Add('e', 5);
            dic.Add('f', 6);
            dic.Add('g', 7);
            dic.Add('h', 8);
            dic.Add('i', 9);
        }
        
        public static int ComputeSearchHash(string s)
        {
            int acc = 0;
            int power = 0;

            foreach (char c in s)
            {
                acc += dic[c] * (int)Math.Pow(Prime, power++);
            }

            return acc;
        }

        public static int ComputeHash(string s)
        {
            if (LastHash == -1)
            {
                LastFirstLetter = s[0];
                LastHash = ComputeSearchHash(s);
                return LastHash;
            }
            else
            {
                int subtractedPrimedHash = (LastHash - dic[LastFirstLetter]) / Prime;
                char currentLastLetter = s[s.Length - 1];
                LastHash = subtractedPrimedHash + (dic[currentLastLetter] * (int)Math.Pow(Prime, s.Length - 1));
                LastFirstLetter = s[0];
                return LastHash;
            }
        }

        public static int FindSubstring(string s, string substring)
        {
            int hashOfSubstring = ComputeSearchHash(substring);
            for(int i = 0; i < s.Length - substring.Length; i++)
            {
                string ss = s.Substring(i, substring.Length);
                if (ComputeHash(ss) == hashOfSubstring)
                {
                    if (ss == substring) return i;
                }
            }

            return -1;
        }
    }
}
