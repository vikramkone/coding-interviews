namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DepthFirstTraversal<T> : ISolution
    {
        private Graph<T> graph;

        private T root;

        public DepthFirstTraversal(Graph<T> graph, T start)
        {
            this.graph = graph;
            this.root = start;
        }

        public void Run()
        {
            HashSet<T> visited = new HashSet<T>();

            if (this.graph.AdjacencyList.ContainsKey(this.root))
            {
                Stack<T> stack = new Stack<T>();
                stack.Push(this.root);

                while (stack.Count > 0)
                {
                    T vertex = stack.Pop();

                    if (!visited.Contains(vertex))
                    {
                        visited.Add(vertex);

                        foreach (T node in this.graph.AdjacencyList[vertex])
                        {
                            if (!visited.Contains(node))
                            {
                                stack.Push(node);
                            }
                        }
                    }
                }
            }

            foreach (var T in visited)
            {
                Console.WriteLine(T);
            }
        }
    }
}