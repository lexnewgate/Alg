public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public int GetListLength(ListNode node,out ListNode endNode)
    {
        int c = 0;
        endNode = null;
        while (node!=null)
        {
            c++;
            endNode= node;
            node = node.next;
        }

        return c;
    }

    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null)
        {
            return null;
        }

        ListNode endNode;
        int l = GetListLength(head,out endNode);
        int rk = k % l;
        if (rk == 0)
        {
            return head;
        }
        int endInOriginal = l - rk;
        ListNode cur = head;
        ListNode newHead = null;
        int i = 0;
        while (cur!=null)
        {
            i++;
            if (i == endInOriginal)
            {
                newHead = cur.next;
                endNode.next = head;
                cur.next = null;
            }
            cur = cur.next;
        }

        return newHead;
    }
}