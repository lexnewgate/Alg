
// Definition for a Node.

using System;
using System.Collections.Generic;
using System.Security.Principal;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution
{

    Node GetNode(List<Node> table, int index)
    {
        //fill table
        for (int i = table.Count; i <= index; i++)
        {
           table.Add(new Node(0)); 
        }

        return table[index];
    }

    public Node CopyRandomList(Node head)
    {
        Node vNode=new Node(0);

        //randomTo,index
        Dictionary<Node,Node>fromToDict=new Dictionary<Node, Node>();

        Node toLast = vNode;
        Node from = head;
        while (from!=null)
        {
            //copy node
            Node toTarget=null;
            if (!fromToDict.TryGetValue(from, out toTarget))
            {
                toTarget=new Node(from.val);
                fromToDict[from] = toTarget;
            }

            toLast.next = toTarget;

            //copy random
            if (from.random != null)
            {
                if (!fromToDict.TryGetValue(from.random, out toTarget))
                {
                    toTarget=new Node(from.random.val);
                    fromToDict[from.random] = toTarget;
                }

                toLast.next.random = toTarget;
            }

           from = from.next;
           toLast = toLast.next;
        }

        return vNode.next;
    }
}