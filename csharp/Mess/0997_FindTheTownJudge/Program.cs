using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution
{

    class DiGraph
    {
        private List<int>[] vertice;

        public DiGraph(int V)
        {
            vertice=new List<int>[V];
        }

        public int Count()
        {
            return vertice.Length;
        }

        public void AddEdge(int from, int to)
        {
            if (vertice[from] == null)
            {
                vertice[from]=new List<int>(); 
            }

            vertice[from].Add(to);
        }

        public IEnumerable<int> Adj(int v)
        {
            if (vertice[v] == null)
            {
                vertice[v]=new List<int>();
            }
            return vertice[v];
        }

        public int OutDeg(int v)
        {
            if (vertice[v] != null)
            {
                return vertice[v].Count;
            }
            else
            {
                return 0;
            }
        }

    }


    public int FindJudge(int N, int[][] trust)
    {
        DiGraph di=new DiGraph(N);

        for (int i = 0; i < trust.Length; i++)
        {
            di.AddEdge(trust[i][0]-1,trust[i][1]-1);
        }

        int ansCandidate = -1;

        for (int i = 0; i < di.Count(); i++)
        {
            if (di.OutDeg(i) == 0)
            {
                if (ansCandidate == -1)
                {
                    ansCandidate = i;
                }
                else
                {
                    return -1;
                }
            }
        }

        if (ansCandidate == -1)
        {
            return -1;
        }

        for (int i = 0; i < di.Count(); i++)
        {
            bool isTrust = false;
            if (i != ansCandidate)
            {
                foreach (var j in di.Adj(i))
                {
                    if (j == ansCandidate)
                    {
                        isTrust = true;
                        break;
                    }
                }

                if(!isTrust)
                {
                    return -1;
                }
            }
        }

        return ansCandidate+1;
    }
     static void Main()
    {
        int n = 2;
        int [][]trust={
            new[]{1,2} ,
        };

        Console.WriteLine(new Solution().FindJudge(n,trust));
    }
}
