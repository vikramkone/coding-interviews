using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 2, 1, 3, 4, 1, 2, 1, 0, 4 };
            var sol = new MaxRectangleHistogram(A);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
