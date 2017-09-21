using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string>() {
                "wrt",
                "wrf",
                "er",
                "ett",
                "rftt"
            };
            //input = new List<string>() { "baa", "abcd", "abca", "cab", "cad" };
            //input = new List<string>() { "z", "x", "z" };
            //input = new List<string>(){"caa", "aaa", "aab"};
            var edges = new AlienDictionary(input).CreateEdges();
            /* 
            edges = new List<Tuple<char, char>>()
            {
                Tuple.Create('b','d'),
                Tuple.Create('b','a'),
                Tuple.Create('a','c'),
                Tuple.Create('d','a')
            };
            */
            var sol = new DetectCycle<char>(edges);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
