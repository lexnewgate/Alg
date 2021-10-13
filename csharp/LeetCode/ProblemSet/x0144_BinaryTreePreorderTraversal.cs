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

namespace x0144_BinaryTreePreorderTraversal
{
    using System.Collections.Generic;
    //todo:1)stack optimize; 2) Morris iterate
    public class Solution
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> ret = new List<int>();
            if (root == null)
            {
                return ret;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                ret.Add(node.val);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }

            return ret;
        }
    }

}