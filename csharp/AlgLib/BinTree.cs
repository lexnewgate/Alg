using System;
using System.Collections.Generic;

namespace AlgLib
{
    public static class BinTree
    {
        public static bool IsSymmetricUsingRecursive(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return true;
            }

            return IsSymmetricUsingRecursiveInternal(treeNode.left, treeNode.right);
        }

        private static bool IsSymmetricUsingRecursiveInternal(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            if (node1 != null && node2 != null && node1.val == node2.val)
            {
                return IsSymmetricUsingRecursiveInternal(node1.left, node2.right) &&
                       IsSymmetricUsingRecursiveInternal(node1.right, node2.left);
            }

            return false;
        }

        public static bool IsSymmetricUsingIterative(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return true;
            }

            return IsSymmetricUsingIterativeInternal(treeNode.left, treeNode.right);
        }

        private static bool IsSymmetricUsingIterativeInternal(TreeNode node1, TreeNode node2)
        {
            Stack<TreeNode> stack=new Stack<TreeNode>();
            stack.Push(node1);
            stack.Push(node2);
            while (stack.Count!=0)
            {
                node1 = stack.Pop();
                node2 = stack.Pop();
                if (node1 == null && node2 == null)
                {
                    continue;
                }

                if (node1 != null && node2 != null && node1.val == node2.val)
                {
                    stack.Push(node1.left);
                    stack.Push(node2.right);
                    stack.Push(node1.right);
                    stack.Push(node2.left);
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
