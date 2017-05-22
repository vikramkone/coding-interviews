using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 6, 2, 5, 4, 5, 1, 6};
            var sol = new MaxRectangleHistogram(A);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
