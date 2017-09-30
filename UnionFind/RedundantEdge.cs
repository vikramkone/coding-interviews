
namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RedundantEdge : ISolution
    {
        private List<Tuple<int, int>> edges;

        public RedundantEdge(List<Tuple<int, int>> edges)
        {
            this.edges = edges;
        }

        public void Run()
        {
            DisjointSetUnion dsu = new DisjointSetUnion(2000);

            foreach (var edge in edges)
            {
                if(dsu.Find(edge.Item1) == dsu.Find(edge.Item2))
                {
                    Console.WriteLine("Redundant edge is {0}-{1}", edge.Item1, edge.Item2);
                    break;
                }
                else
                {
                    dsu.Union(edge.Item1, edge.Item2);
                }

                //if (!dsu.UnionRank(edge.Item1, edge.Item2))
                //{
                  //  Console.WriteLine("Redundant edge is {0}-{1}", edge.Item1, edge.Item2);
                    //break;
                //}
            }
        }
    }
}
