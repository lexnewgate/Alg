using System;
using System.Collections.Generic;

public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int>ret=new List<int>();
        if (root == null)
        {
            return ret;
        }

        Stack<TreeNode>stack=new Stack<TreeNode>();
        HashSet<TreeNode>retSet=new HashSet<TreeNode>();
        retSet.Add(null);
        stack.Push(root);
        while (stack.Count!=0)
        {
            var top = stack.Peek();
            if (retSet.Contains(top.left) && retSet.Contains(top.right))
            {
                Console.Write(top.val);
                ret.Add(top.val);
                retSet.Add(top);
                stack.Pop();
            }
            else
            {
                if (!retSet.Contains(top.right))
                {
                    stack.Push(top.right);
                }

                if (!retSet.Contains(top.left))
                {
                    stack.Push(top.left);
                }
            }

        }




        Console.WriteLine();


        return ret;
    }

    //static void Main()
    //{
    //    TreeNode root=new TreeNode(1);
    //    root.left = new TreeNode(4);
    //    root.right=new TreeNode(2);
    //    root.right.left=new TreeNode(3);
    //    new Solution().PostorderTraversal(root);

    //}
}
