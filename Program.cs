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
            input = new List<string>() { "baa", "abcd", "abca", "cab", "cad" };
            input = new List<string>() { "z", "x", "xa" };
            var edges = new AlientDictionary(input).CreateEdges();
            edges = new List<Tuple<char, char>>()
            {
                Tuple.Create('b','d'),
                Tuple.Create('b','a'),
                Tuple.Create('a','c'),
                Tuple.Create('f','d'),
                Tuple.Create('d','a')
            };

            var sol = new TopologicalSort<char>(edges);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
