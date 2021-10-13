using System.Collections.Generic;

public class MyQueue
{
    private Stack<int> pushStack;
    private Stack<int> popStack;

    /** Initialize your data structure here. */
    public MyQueue()
    {
        pushStack=new Stack<int>();
        popStack=new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        pushStack.Push(x);
    }

    private void Transfer()
    {
        while (pushStack.Count>0)
        {
            popStack.Push(pushStack.Pop());
        }
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        if (popStack.Count > 0)
        {
            return popStack.Pop();
        }

       Transfer(); 

        return popStack.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        if (popStack.Count > 0)
        {
            return popStack.Peek();
        }

        Transfer();
        return popStack.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return pushStack.Count == 0 && popStack.Count == 0;
    }
}
