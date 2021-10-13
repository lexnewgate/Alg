using System.Collections.Generic;

namespace x0101_SymmetricTree_Iterative
{
    /// <summary>
    /// note: 递归=>迭代时需要注意返回值的问题.
    /// </summary>
    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            Stack<TreeNode> stack=new Stack<TreeNode>();
            stack.Push(root.left);
            stack.Push(root.right);

            while (stack.Count!=0)
            {
                var left = stack.Pop();
                var right = stack.Pop();
                int bitLeft = (left == null) ? 0 : 1;
                int bitRight = (right == null) ? 0 : 1;
                if ((bitLeft ^ bitRight) == 1)
                {
                    return false;
                }

                if (left == null && right == null)
                {
                    continue;
                }

                if (left.val != right.val)
                {
                    return false;
                }
                stack.Push(left.left);
                stack.Push(right.right);
                stack.Push(left.right);
                stack.Push(right.left);
            }

            return true;
        }

    }

}
