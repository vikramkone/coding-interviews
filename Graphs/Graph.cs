namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList = new Dictionary<T, HashSet<T>>();

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            // Add vertices
            foreach (T vertex in vertices)
            {
                if (!AdjacencyList.ContainsKey(vertex))
                {
                    AdjacencyList.Add(vertex, new HashSet<T>());
                }
            }

            // Add edges
            foreach (var edge in edges)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }
    }
}
