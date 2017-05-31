using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    static class Program
    {
        static void Main(string[] args)
        {
            RabinKarp.SetupDic();

            //Console.WriteLine("BruteForce: " + BruteForce.FindSubstring("abcdefg", "ab"));
            //Console.WriteLine("RabinKarp: " + RabinKarp.FindSubstring("abcdefg", "ab"));
            //Console.WriteLine("KMP: "); KMP.FindSubstring("AAACAA", "AA").ForEach(x => Console.WriteLine("Z: " + x));
            //Console.WriteLine("Z: "); Z.Search("aabcaab", "aab");
            //Console.WriteLine("Z: "); Z.FindSubstring("aaaaa", "aa").ForEach(x => Console.WriteLine("Z: " + x));
            //Console.WriteLine("Boyer Moore: "); BoyerMoore.FindSubstring("vikramgustavovikram", "vikram").ForEach(x => Console.WriteLine("Z: " + x));
            Console.WriteLine("Finite Automata: " + FiniteStateAutomata.FindSubstring("AAACACAGAB", "ACACAGA"));
            Console.Read();
        }
    }
}
