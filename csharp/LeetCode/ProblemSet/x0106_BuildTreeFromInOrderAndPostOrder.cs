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
//# todo:递归逻辑写的太复杂; 
using System;
using System.Collections.Generic;

namespace x0106_BuildTreeFromInOrderAndPostOrder
{
    public class Solution
    {
        /// <summary>
        /// k: inorder value
        /// v: inorder index
        /// </summary>
        private Dictionary<int,int>m_dictInorder;
        private Dictionary<int,int>m_dictPostOrder;

        private int[] m_inOrder;
        private int[] m_postOrder;
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null || inorder.Length != postorder.Length||inorder.Length==0)
            {
                throw new ArgumentException();
            }

            this.m_inOrder = inorder;
            this.m_postOrder = postorder;
            m_dictInorder=new Dictionary<int, int>(inorder.Length);
            m_dictPostOrder = new Dictionary<int, int>(inorder.Length);
            for (int i = 0; i < inorder.Length; i++)
            {
                m_dictInorder[inorder[i]] = i;
                m_dictPostOrder[postorder[i]] = i;
            }



            TreeNode root= new TreeNode(postorder[postorder.Length-1]);
            AttachTwoChildRecursive(root,0,inorder.Length-1,0,postorder.Length-1);
            return root;
        }


        public void AttachTwoChildRecursive(TreeNode root,int inStart,int inEnd,int postStart,int postEnd)
        {
            int rootV = root.val;
            int indexInInOrder = m_dictInorder[rootV];
            int indexInPostOrder = m_dictPostOrder[rootV];
            int rightLength = 0;
            if (indexInInOrder< inEnd)
            {
                var rightIndexInPostOrder = indexInPostOrder - 1;
                int rightV = m_postOrder[rightIndexInPostOrder];
                rightLength= inEnd - indexInInOrder;
                TreeNode right=new TreeNode(rightV);
                root.right = right;
                AttachTwoChildRecursive(right,indexInInOrder+1,inEnd,
                    rightIndexInPostOrder-(rightLength - 1),rightIndexInPostOrder);
            }

            int leftIndex = -1;
            if (indexInInOrder> inStart)
            {
                var leftIndexInPostOrder = indexInPostOrder - 1 - rightLength;
                int leftV = m_postOrder[leftIndexInPostOrder];
                int leftLength = indexInInOrder - inStart;
                TreeNode left=new TreeNode(leftV);
                root.left = left;
                AttachTwoChildRecursive(left,inStart,indexInInOrder-1,postStart,leftIndexInPostOrder);
            }
        }







    }

}