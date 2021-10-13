public class Solution
{
    public bool HasPathSum(TreeNode root, int sum)
    {
        if (root == null)
        {
            return false;
        }

        if (root.left == null && root.right== null)
        {
            return root.val == sum;
        }
        else
        {
            if (root.left != null)
            {
                if (HasPathSum(root.left, sum - root.val))
                {
                    return true;
                }
            }

            if (root.right != null)
            {
                if (HasPathSum(root.right, sum - root.val))
                {
                    return true;
                }
            }

            return false;
        }
    }
}