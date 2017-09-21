namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DetectCycle<T> : ISolution
    {
        private IEnumerable<Tuple<T, T>> edges;

        private HashSet<T> nodes = new HashSet<T>();

        public DetectCycle(IEnumerable<Tuple<T, T>> edges)
        {
            this.edges = edges;

            foreach (var edge in edges)
            {
                nodes.Add(edge.Item1);
                nodes.Add(edge.Item2);
            }
        }

        public void Run()
        {
            Console.WriteLine("Is cycle detected ? {0}", IsCycle());
        }

        private bool IsCycle()
        {
            foreach (var node in nodes)
            {
                HashSet<T> visited = new HashSet<T>();
                visited.Add(node);

                Stack<T> stack = new Stack<T>();
                stack.Push(node);

                while (stack.Count > 0)
                {
                    var currNode = stack.Pop();
                    var neighbors = this.edges.Where(x => x.Item1.Equals(currNode)).Select(x => x.Item2);

                    foreach(var neighbor in neighbors)
                    {
                        if(visited.Contains(neighbor))
                        {
                            return true;
                        }
                        stack.Push(neighbor);
                    }
                }
            }

            return false;
        }
    }
}