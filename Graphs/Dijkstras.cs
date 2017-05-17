using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestions
{
    class Edge
    {
        public Edge(Vertex vertex, int weight)
        {
            this.Vertex = vertex;
            this.Weight = weight;
        }

        public Vertex Vertex;
        public int Weight;
    }
    class Vertex
    {
        public Vertex(string name)
        {
            this.Name = name;
            this.CurrentWeight = int.MaxValue;
        }

        public string Name { get; }
        public List<Edge> neighbors = new List<Edge>();
        public Vertex BestVertextToSource;
        public bool Visited;
        public int CurrentWeight;
    }

    class Dijkstras : ISolution
    {
        public void Run()
        {
            Vertex vA = new Vertex("vA");
            Vertex vB = new Vertex("vB");
            Vertex vC = new Vertex("vC");
            Vertex vD = new Vertex("vD");
            Vertex vE = new Vertex("vE");
            Vertex vF = new Vertex("vF");
            Vertex vG = new Vertex("vG");
            Vertex vH = new Vertex("vH");
            Vertex vI = new Vertex("vI");

            vA.neighbors.Add(new Edge(vB, 3));
            vA.neighbors.Add(new Edge(vE, 7));
            vA.neighbors.Add(new Edge(vG, 5));

            vB.neighbors.Add(new Edge(vA, 3));
            vB.neighbors.Add(new Edge(vE, 1));
            vB.neighbors.Add(new Edge(vC, 7));

            vC.neighbors.Add(new Edge(vB, 7));
            vC.neighbors.Add(new Edge(vE, 2));
            vC.neighbors.Add(new Edge(vF, 2));
            vC.neighbors.Add(new Edge(vD, 1));

            vD.neighbors.Add(new Edge(vC, 1));
            vD.neighbors.Add(new Edge(vF, 3));
            vD.neighbors.Add(new Edge(vI, 5));

            vE.neighbors.Add(new Edge(vB, 1));
            vE.neighbors.Add(new Edge(vC, 2));
            vE.neighbors.Add(new Edge(vF, 1));
            vE.neighbors.Add(new Edge(vH, 3));
            vE.neighbors.Add(new Edge(vG, 3));
            vE.neighbors.Add(new Edge(vA, 7));

            vF.neighbors.Add(new Edge(vC, 2));
            vF.neighbors.Add(new Edge(vD, 2));
            vF.neighbors.Add(new Edge(vI, 2));
            vF.neighbors.Add(new Edge(vH, 3));
            vF.neighbors.Add(new Edge(vE, 1));

            vG.neighbors.Add(new Edge(vA, 5));
            vG.neighbors.Add(new Edge(vE, 3));
            vG.neighbors.Add(new Edge(vH, 2));

            vH.neighbors.Add(new Edge(vG, 2));
            vH.neighbors.Add(new Edge(vE, 3));
            vH.neighbors.Add(new Edge(vF, 3));
            vH.neighbors.Add(new Edge(vI, 4));

            vI.neighbors.Add(new Edge(vH, 4));
            vI.neighbors.Add(new Edge(vF, 2));
            vI.neighbors.Add(new Edge(vD, 5));

            List<Vertex> allVertexes = new List<Vertex>();
            allVertexes.Add(vA);
            allVertexes.Add(vB);
            allVertexes.Add(vC);
            allVertexes.Add(vD);
            allVertexes.Add(vE);
            allVertexes.Add(vF);
            allVertexes.Add(vG);
            allVertexes.Add(vH);
            allVertexes.Add(vI);

            DijkstraWithBFS(allVertexes, vA);

            var nodeToCheck = vF;
            while (nodeToCheck.BestVertextToSource != null) { Console.WriteLine(nodeToCheck.Name); nodeToCheck = nodeToCheck.BestVertextToSource; }
            Console.ReadLine();
        }

        public static void DijkstraWithBFS(List<Vertex> allVertexes, Vertex initialVertex)
        {
            Queue<Vertex> vertexQueue = new Queue<Vertex>();

            vertexQueue.Enqueue(initialVertex);

            while (vertexQueue.Count > 0)
            {
                var curr = vertexQueue.Dequeue();
                if (curr.Visited) continue;
                curr.Visited = true;
                foreach (var n in curr.neighbors)
                {
                    if (!n.Vertex.Visited)
                    {
                        if (n.Vertex.BestVertextToSource == null)
                        {
                            n.Vertex.BestVertextToSource = curr;
                        }

                        vertexQueue.Enqueue(n.Vertex);
                    }
                }
            }
        }

        public static void Dijkstra(List<Vertex> allVertexes, Vertex initialVertex)
        {
            initialVertex.CurrentWeight = 0;
            Vertex currentVertex = initialVertex;

            while (currentVertex != null)
            {
                foreach (var edge in currentVertex.neighbors.Where(x => !x.Vertex.Visited).Select(x => x).ToList<Edge>())
                {
                    var edgeWeight = currentVertex.CurrentWeight + edge.Weight;
                    if (edgeWeight < edge.Vertex.CurrentWeight)
                    {
                        edge.Vertex.BestVertextToSource = currentVertex;
                        edge.Vertex.CurrentWeight = edgeWeight;
                    }
                }

                currentVertex.Visited = true;
                allVertexes.Remove(currentVertex);

                if (allVertexes.Count > 0) currentVertex = allVertexes[0]; else currentVertex = null;
            }

        }
    }
}
