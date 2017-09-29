using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(4);
            pq.Peek();
            pq.Enqueue(5);
            pq.Peek();
            pq.Enqueue(1);
            pq.Peek();
            pq.Dequeue();
            pq.Peek();
            pq.Enqueue(2);
            pq.Peek();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
