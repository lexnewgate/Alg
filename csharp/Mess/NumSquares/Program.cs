using System;
using System.Collections.Generic;

public class Solution
{
    public int NumSquares(int n)
    {

        Queue<int> queue = new Queue<int>();
        Queue<int> queue1 = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        queue.Enqueue(n);
        visited.Add(n);
        int level = 0;

        while (queue.Count != 0)
        {
            level++;
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                var maxCostSqrt = (int)Math.Sqrt(node);
                for (int i = maxCostSqrt; i >= 1; i--)
                {
                    var nei = node - i * i;
                    if (nei == 0)
                    {
                        return level;
                    }
                    queue1.Enqueue(nei);
                }
            }
            (queue, queue1) = (queue1, queue);
        }
        return 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(new Solution().NumSquares(12));
    }
}
