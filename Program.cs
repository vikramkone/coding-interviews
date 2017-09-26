using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new RandomSampling(new int[] { 1, 4, 6, 7, 9, 3, 5, 6, 7, 0, 6 }, 4);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
