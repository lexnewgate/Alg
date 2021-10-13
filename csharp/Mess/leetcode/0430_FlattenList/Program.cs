
// Definition for a Node.

using System;
using System.Collections.Generic;

public class Node
{
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}


public class Solution
{
    public Node Flatten(Node head)
    {
        Node cur = head;
        Node last=null;
        Stack<Node>stack=new Stack<Node>();
        while (cur!=null||stack.Count!=0)
        {
            if (cur == null)
            {
                cur = stack.Pop();
                last.next = cur;
                cur.prev = last;
            }

            last = cur;

            if (cur.child != null)
            {
                if (cur.next != null)
                {
                    stack.Push(cur.next);
                }

                cur.next = cur.child;
                cur.child.prev = cur;
                cur = cur.child;
                cur.prev.child = null;
            }
            else
            {
                cur = cur.next;
            }

        }

        return head;

    }
}
