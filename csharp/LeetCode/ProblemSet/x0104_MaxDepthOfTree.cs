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

namespace x0104_MaxDepthOfTree
{
    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> q1=new Queue<TreeNode>();
            Queue<TreeNode>q2=new Queue<TreeNode>();
            int c = 0;
            q1.Enqueue(root);
            while (q1.Count!=0)
            {
                c++;
                while (q1.Count!=0)
                {
                    var node = q1.Dequeue();
                    if (node != null)
                    {
                        if (node.left != null)
                        {
                            q2.Enqueue(node.left);
                        }

                        if (node.right != null)
                        {
                            q2.Enqueue(node.right);
                        }
                    }
                }

                (q1, q2) = (q2, q1);
            }

            return c;
        }
    }

}