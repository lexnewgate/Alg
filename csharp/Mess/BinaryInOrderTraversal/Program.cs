//tag: BinaryTree,Stack
using System.Collections.Generic;
public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> ret = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        var cur = root;

        while (cur!=null||stack.Count != 0)
        {
            while (cur!=null)
            {
                stack.Push(cur);
                cur = cur.left;
            }

            cur = stack.Pop();
            ret.Add(cur.val);
            cur = cur.right;
        }
        return ret;
    }
}
