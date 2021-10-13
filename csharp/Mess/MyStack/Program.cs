using System.Collections.Generic;

public class MyStack
{
    private Queue<int> queue;
    private Queue<int> queue1;

    /** Initialize your data structure here. */
    public MyStack()
    {
       queue=new Queue<int>(); 
       queue1=new Queue<int>(); 
    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
       queue.Enqueue(x); 
    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        while (queue.Count>1)
        {
            queue1.Enqueue(queue.Dequeue());
        }

        (queue1, queue) = (queue, queue1);
        return queue1.Dequeue();
    }

    /** Get the top element. */
    public int Top()
    {
        var top = Pop();
        Push(top);
        return top;
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return queue.Count == 0;
    }
}

