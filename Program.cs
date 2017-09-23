using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            var edges = new List<Tuple<char, char>>()
            {
                Tuple.Create('A','H'),
                Tuple.Create('A','G'),
                Tuple.Create('H','G'),
                Tuple.Create('A','B'),
                Tuple.Create('G','C'),
                Tuple.Create('A','B'),
                Tuple.Create('B','C'),
                Tuple.Create('C','E'),
                Tuple.Create('D','E'),
                Tuple.Create('E','F'),
                Tuple.Create('H','E'),
                Tuple.Create('B','D'),
            };

            var sol = new ShortestPath<char>(new Graph<char>(edges), 'A', 'E');
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
