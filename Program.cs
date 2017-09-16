using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 22, 9, 33, 21, 50, 41, 60 };
            var sol = new LongestIncreasingSequence(arr);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
