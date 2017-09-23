using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestions
{
    public class TopologicalSort<T> : ISolution
    {
        private HashSet<T> nodes = new HashSet<T>();

        private HashSet<Tuple<T, T>> edges = new HashSet<Tuple<T, T>>();

        public TopologicalSort(IEnumerable<Tuple<T, T>> edges)
        {
            // each directed edge A -> B means A comes before B
            foreach (var edge in edges)
            {
                this.nodes.Add(edge.Item1);
                this.nodes.Add(edge.Item2);
                this.edges.Add(edge);
            }
        }

        public void Run()
        {
            HashSet<T> visited = new HashSet<T>();
            Stack<T> result = new Stack<T>();

            foreach (var node in this.nodes)
            {
                if (!visited.Contains(node))
                {
                    TopSortUtil(node, visited, result);
                }
            }

            while (result.Count > 0)
            {
                Console.WriteLine(result.Pop());
            }
        }

        private void TopSortUtil(T node, HashSet<T> visited, Stack<T> result)
        {
            visited.Add(node);

            // Get all the neighbors
            var neighbors = this.edges.Where(x => x.Item1.Equals(node)).Select(x => x.Item2);

            foreach (var neighbor in neighbors)
            {
                // if not already visited then recurse
                if (!visited.Contains(neighbor))
                {
                    TopSortUtil(neighbor, visited, result);
                }
            }

            // once all neighbors are visited, then add to the stack
            result.Push(node);
        }

        private void TopSortUsingKahns()
        {
            // Empty list that will contain the sorted elements
            var result = new List<T>();

            // Set of all nodes with no incoming edges
            var roots = new HashSet<T>(nodes.Where(n => edges.All(e => e.Item2.Equals(n) == false)));

            // while S is non-empty do
            while (roots.Any())
            {
                //  remove a node n from S
                var n = roots.First();
                roots.Remove(n);

                // add n to tail of L
                result.Add(n);

                // for each node m with an edge e from n to m do
                var outgoingEdges = edges.Where(e => e.Item1.Equals(n)).ToList();

                foreach (var e in outgoingEdges)
                {
                    var m = e.Item2;

                    // remove edge e from the graph
                    edges.Remove(e);

                    // if m has no other incoming edges then
                    if (edges.All(me => me.Item2.Equals(m) == false))
                    {
                        // insert m into S
                        roots.Add(m);
                    }
                }
            }

            // if graph has edges then
            if (edges.Any())
            {
                // return error (graph has at least one cycle)
                Console.WriteLine("Cycle detecte. Invalid DAG");
            }
            else
            {
                // return L (a topologically sorted order)
                Console.WriteLine(string.Join(",", result));
            }
        }
    }
}