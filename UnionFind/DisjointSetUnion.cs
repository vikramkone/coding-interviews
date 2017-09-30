
namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DisjointSetUnion
    {
        int[] parent;
        int[] rank;

        public DisjointSetUnion(int size)
        {
            rank = new int[size];
            parent = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        public void Union(int x, int y)
        {
            int xset = Find(x);
            int yset = Find(y);
            parent[xset] = yset;
        }

        public bool UnionRank(int x, int y)
        {
            int xr = Find(x);
            int yr = Find(y);

            if (xr == yr)
            {
                return false;
            }
            else if (rank[xr] < rank[yr])
            {
                parent[xr] = yr;
            }
            else if (rank[xr] > rank[yr])
            {
                parent[yr] = xr;
            }
            else
            {
                parent[yr] = xr;
                rank[xr]++;
            }
            return true;
        }


    }
}