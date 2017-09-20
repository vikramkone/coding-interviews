namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BreadthFirstTraversal<T> : ISolution
    {
        private Graph<T> graph;

        private T root;

        public BreadthFirstTraversal(Graph<T> graph, T start)
        {
            this.graph = graph;
            this.root = start;
        }

        public void Run()
        {
            HashSet<T> visited = new HashSet<T>();

            if (this.graph.AdjacencyList.ContainsKey(this.root))
            {
                Queue<T> queue = new Queue<T>();
                queue.Enqueue(this.root);

                while (queue.Count > 0)
                {
                    T vertex = queue.Dequeue();

                    if (!visited.Contains(vertex))
                    {
                        visited.Add(vertex);

                        foreach (T node in this.graph.AdjacencyList[vertex])
                        {
                            if (!visited.Contains(node))
                            {
                                queue.Enqueue(node);
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