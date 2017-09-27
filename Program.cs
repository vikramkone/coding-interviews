using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();

            Dictionary<string, int> words = new Dictionary<string, int>()
            {
                { "i love you", 5},
                { "island", 3 },
                { "ironman",  2},
                { "i love leetcode", 2}
            };

            foreach (var kv in words)
            {
                Enumerable.Range(0, kv.Value).ToList().ForEach(x => trie.AddWord(kv.Key));
            }


            foreach(var word in trie.GetWords("i ", 3))
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
