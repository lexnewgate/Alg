using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        int c = 0;
        int end=-1;

        Array.Sort(intervals, (v1,v2) => v1[0] - v2[0]);

        Stack<int[]>stack=new Stack<int[]>(intervals.Length);
        stack.Push(intervals[0]);
        for (int i = 1; i < intervals.Length; i++)
        {
            var first = stack.Peek();
            var sec = intervals[i];
            if (first[1]>=sec[0]) //need merge
            {
                if (sec[1] >= first[1]) //use first start and sec end
                {
                    first[1] = sec[1];
                }
                //use first start and first end ; they already in stack
            }
            else
            {
                stack.Push(sec);
            }
        }

        //todo there is no need to use stack here
        //format 
        var ret = stack.ToArray().Reverse().ToArray(); 
        return ret;
    }
}
