using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>()
            {
                "A,START,0",
                "A,END,2",
                "B,START,5",
                "C,START,10",
                "C,END,14",
                "B,END,20"
            };
            // A = 2
            // B = 11
            // C = 4

            var sol = new ExclusiveTimePerFunction(input);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
