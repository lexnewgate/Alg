using System.Collections.Generic;
using System;
public class MinStack
{
    private List<(int,int)> data;
    private int min;
    public MinStack()
    {
        data = new List<(int, int)>();        
    }

    public void Push(int x)
    {
        if(data.Count==0)
        {
            data.Add((x, x));
        }
        else
        {
            var (lastV, lastMin) = data[data.Count - 1];
            if(x<lastMin)
            {
                data.Add((x, x));
            }
            else
            {
                data.Add((x, lastMin));
            }
        }
    }

    public void Pop()
    {
        if(data.Count>0)
        {
            data.RemoveAt(data.Count - 1);
        }
    }

    public int Top()
    {
        return data[data.Count - 1].Item1;
    }

    public int GetMin()
    {
        return data[data.Count - 1].Item2;
    }

    static void Main()
    {
        var minStack=new MinStack();
        minStack.Push(123);
        Console.WriteLine(minStack.GetMin());
    }
}