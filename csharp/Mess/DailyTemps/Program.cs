using System.Collections.Generic;
public class Solution
{
    public int[] DailyTemperatures(int[] T)
    {
        int[] ret = new int[T.Length];
        Stack<(int index,int value)> stack = new Stack<(int,int)>(); 
        for(int i=0;i<T.Length;i++)
        {
            while(stack.Count!=0)
            {
                var top = stack.Peek();
                if(top.value<T[i])
                {
                    ret[top.index] = i - top.index;
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }
            stack.Push((i, T[i]));
        }

        while(stack.Count!=0)
        {
            var top = stack.Pop();
            ret[top.index] = 0;
        }
        return ret;

    }
}
