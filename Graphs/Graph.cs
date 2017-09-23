namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList = new Dictionary<T, HashSet<T>>();

        public HashSet<T> Vertices = new HashSet<T>();

        public Graph(IEnumerable<Tuple<T, T>> edges, bool isDirected = true)
        {
            foreach (var edge in edges)
            {
                // Add vertices
                if (!AdjacencyList.ContainsKey(edge.Item1))
                {
                    this.Vertices.Add(edge.Item1);
                    AdjacencyList.Add(edge.Item1, new HashSet<T>());
                }

                if (!AdjacencyList.ContainsKey(edge.Item2))
                {
                    this.Vertices.Add(edge.Item2);
                    AdjacencyList.Add(edge.Item2, new HashSet<T>());
                }

                // Add edges
                AdjacencyList[edge.Item1].Add(edge.Item2);

                // if undirected, add both sides
                if (!isDirected)
                {
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }
    }
}
