using System;
using System.Collections.Generic;

public class Solution
{
    class Graph
    {
        private byte[] vals;
        private List<short>[] v;
        public Graph(int size)
        {
            v=new List<short>[size];
            vals=new byte[size];
        }

        public void AddEdge(int f,int t)
        {
            if (v[f] == null)
            {
                v[f]=new List<short>();
            }

            if (v[t] == null)
            {
                v[t]=new List<short>();
            }

            v[f].Add((short)t);
            v[t].Add((short)f);
        }

        public IEnumerable<short> Adj(int v)
        {
            if (this.v[v] == null)
            {
                this.v[v]=new List<short>();
            }

            return this.v[v];
        }

        public byte Val(int index)
        {
            return vals[index];
        }

        public void SetVal(int index,byte val)
        {
            vals[index] = val;
        }
    }

    public int[] GardenNoAdj(int N, int[][] paths)
    {
        int[]ans=new int[N];
        Graph g=new Graph(N);
        bool[] marked = new bool[N];
        for (int i = 0; i < paths.Length; i++)
        {
            g.AddEdge(paths[i][0]-1,paths[i][1]-1);
        }

        byte[] color = new byte[4];
        for (int i = 0; i < N; i++)
        {
            if (!marked[i])
            {
                BFS(i,ans,marked,g,color);
            }
        }

        return ans;
    }

    private void ResetColors(byte[]color)
    {
        for (int i = 0; i < color.Length; i++)
        {
            color[i] = 0;
        }
    }


    bool[] markColor=new bool[5];
    private byte GetRemainingColor(byte[] color)
    {
        for (int i = 0; i < markColor.Length; i++)
        {
            markColor[i] = false;
        }

        for (int i = 0; i < color.Length; i++)
        {
            markColor[color[i]] = true;
        }

        for (int i = 0; i < markColor.Length; i++)
        {
            if (markColor[i] == false&&i!=0)
            {
                return (byte)i;
            }
        }

        return 0;
    }

    private void BFS(int cur,int[]ans,bool[]marked,Graph g,byte[]color)
    {
        Queue<int>queue=new Queue<int>();
        queue.Enqueue(cur);

        while (queue.Count!=0)
        {
           int v= queue.Dequeue();
           marked[v] = true;
           int j = 0;
           ResetColors(color);
           foreach (var i in g.Adj(v))
           {
               if (!marked[i])
               {
                   queue.Enqueue(i);
               }

               color[j++] = g.Val(i);
           }

           byte remainColor = GetRemainingColor(color);
           g.SetVal(v,remainColor);
           ans[v] = remainColor;
        }
    }

    static void Main()
    {
        int N = 3;
        int [][]paths=new int[][]
        {
            new int[]{1,2 },
            new int[]{2,3},
            new int[]{3,1}, 
        };

        Console.WriteLine(new Solution().GardenNoAdj(N,paths));

    }
}
