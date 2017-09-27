using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new LRUCache<int, string>(3);
            cache.Set(1, "A");
            cache.Set(2, "B");
            cache.Set(3, "C");
            cache.Set(4, "D");
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
