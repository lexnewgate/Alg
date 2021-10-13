namespace x0101_SymmetricTree_Recursive
{
    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root.left, root.right);
        }

        public bool IsSymmetric(TreeNode left, TreeNode right)
        {
            int bitLeft = (left == null) ? 0 : 1;
            int bitRight = (right == null) ? 0 : 1;
            if ((bitLeft ^ bitRight) == 1)
            {
                return false;
            }

            if (left == null && right == null)
            {
                return true;
            }

            if (left.val != right.val)
            {
                return false;
            }

            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }
    }

}