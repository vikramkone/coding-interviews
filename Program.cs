using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new NQueens(4);
            sol.Run();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
