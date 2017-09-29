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

            Dictionary<T, T> previous;
            bool pathFound = this.FindShortestPathBFS(out previous);

            if (pathFound)
            {
                List<T> path = new List<T>();

                T currNode = this.end;

                while (!currNode.Equals(this.start))
                {
                    path.Add(currNode);
                    currNode = previous[currNode];
                }

                path.Add(this.start);
                path.Reverse();

                Console.WriteLine("Path is {0}", string.Join("->", path));
            }
        }

        public bool FindShortestPathBFS(out Dictionary<T, T> previous)
        {
            var queue = new Queue<T>();
            previous = new Dictionary<T, T>();

            queue.Enqueue(this.start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (this.graph.AdjacencyList.ContainsKey(node))
                {
                    var neighbors = this.graph.AdjacencyList[node];

                    foreach (var neighbor in neighbors)
                    {
                        if (!previous.ContainsKey(neighbor))
                        {
                            previous[neighbor] = node;

                            if (neighbor.Equals(this.end))
                            {
                                return true;
                            }

                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return false;
        }
    }
}
