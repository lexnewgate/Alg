/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        IList<IList<int>> listOfLists = new List<IList<int>>();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        if (root != null)
        {
            queue.Enqueue(root);
        }
        while (queue.Count != 0)
        {
            List<int> list = new List<int>(queue.Count);
            int count = queue.Count;
            do
            {
                count--;
                var node = queue.Dequeue();
                list.Add(node.val);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            } while (count != 0);
            listOfLists.Add(list);
        }

        return listOfLists;


    }
}