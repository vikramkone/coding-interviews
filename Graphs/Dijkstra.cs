namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Dijkstra : ISolution
    {
        private GraphVertex Root;

        public class GraphVertex
        {
            public string Value;
            public List<GraphVertex> Neighbors;

            public GraphVertex(string val)
            {
                this.Value = val;
                this.Neighbors = new List<GraphVertex>();
            }

            public void AddNeighbours(params GraphVertex[] nodes)
            {
                foreach (var node in nodes)
                {
                    this.Neighbors.Add(node);
                }
            }
        }

        public Dijkstra()
        {
            GraphVertex A = new GraphVertex("A");
            GraphVertex B = new GraphVertex("B");
            GraphVertex C = new GraphVertex("C");
            GraphVertex D = new GraphVertex("D");
            GraphVertex E = new GraphVertex("E");
            GraphVertex F = new GraphVertex("F");
            GraphVertex G = new GraphVertex("G");
            GraphVertex H = new GraphVertex("H");

            A.AddNeighbours(B, C);
            B.AddNeighbours(A, D, E);
            C.AddNeighbours(A, D, F);
            D.AddNeighbours(C, B, E, F);
            E.AddNeighbours(B, D, G, H);
            F.AddNeighbours(C, D, G, H);
            G.AddNeighbours(E, F);
            H.AddNeighbours(E, F);

            this.Root = D;
        }

        public void Run()
        {
            var path = GetShortestPath("A", "H");
            path.ForEach(x => Console.WriteLine(x));
        }

        public List<string> GetShortestPath(string src, string dest)
        {
            List<string> path = new List<string>();

            // find source node
            var start = FindNode(this.Root, src);
            var end = FindNode(start, dest, path);
            path.Add(end.Value);

            return path;
        }

        public GraphVertex FindNode(GraphVertex src, string val, List<string> path = null)
        {
            GraphVertex node = null;
            Queue<GraphVertex> queue = new Queue<GraphVertex>();
            queue.Enqueue(src);

            HashSet<GraphVertex> visited = new HashSet<GraphVertex>();

            while (queue.Count != 0)
            {
                var vertex = queue.Dequeue();

                if (vertex.Value == val)
                {
                    node = vertex;
                    break;
                }

                // Add all unvisited neighbors
                vertex.Neighbors.Where(x => !visited.Contains(x)).ToList().ForEach(x => queue.Enqueue(x));

                // mark as visited
                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                }
            }

            return node;
        }
    }
}