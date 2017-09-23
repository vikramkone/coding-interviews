namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ShortestPath<T> : ISolution
    {
        private Graph<T> graph;

        private T start;

        private T end;

        private List<List<T>> paths = new List<List<T>>();

        private int shortestPathLength = Int32.MaxValue;

        public ShortestPath(Graph<T> graph, T start, T end)
        {
            this.graph = graph;
            this.start = start;
            this.end = end;
        }

        public void Run()
        {
            if (this.start == null || this.end == null)
            {
                Console.WriteLine("Start or end can't be null");
                return;
            }

            if (this.start.Equals(this.end))
            {
                Console.WriteLine("Path is: {0}->{1}", this.start, this.end);
                return;
            }

            this.FindShortestPath();
        }

        public void FindShortestPath()
        {
            List<T> path = new List<T>();
            HashSet<T> visited = new HashSet<T>();

            FindAllPaths(this.start, this.end, path, visited);
            Console.WriteLine("Found {0} paths", this.paths.Count);
            var shortestPath = this.paths.First(x => x.Count == this.paths.Min(y => y.Count));
            Console.WriteLine("Shorted path is {0} and length is {1}", string.Join("->", shortestPath), shortestPathLength);
        }

        private void FindAllPaths(T curr, T dest, List<T> path, HashSet<T> visited)
        {
            // Add to visited list
            visited.Add(curr);

            // Add to path
            path.Add(curr);

            // Found a path
            if (curr.Equals(dest))
            {
                this.shortestPathLength = Math.Min(path.Count, this.shortestPathLength);

                Console.WriteLine("{0}", string.Join("->", path));
                this.paths.Add(path.ToList());

                // uncomment this if you want to get only one path
                // return; 
            }

            // get neighbors only if possibility of shortest path
            if (this.graph.AdjacencyList.ContainsKey(curr) && path.Count < this.shortestPathLength)
            {
                var neighbors = this.graph.AdjacencyList[curr];

                // Recurse for each neighbor if not visited
                foreach (var node in neighbors)
                {
                    if (!visited.Contains(node))
                    {
                        this.FindAllPaths(node, dest, path, visited);
                    }
                }
            }

            // back track
            path.RemoveAt(path.Count - 1);
            visited.Remove(curr);
        }
    }
}
