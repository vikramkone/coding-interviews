using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int,int>> edges = new List<Tuple<int,int>>()
            {
                Tuple.Create(1,2),
                Tuple.Create(2,3),
                Tuple.Create(3,4),
                Tuple.Create(1,4),
                Tuple.Create(1,5),
            };

            RedundantEdge sol = new RedundantEdge(edges);
            sol.Run();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
