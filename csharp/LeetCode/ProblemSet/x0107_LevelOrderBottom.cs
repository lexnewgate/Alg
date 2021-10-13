using System.Collections.Generic;
using System.Linq;

namespace x0107_LevelOrderBottom
{
    public class Solution
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>>ret=new List<IList<int>>();
            Queue<TreeNode>queue=new Queue<TreeNode>();
            Queue<TreeNode>  tempQueue=new Queue<TreeNode>();
            if(root!=null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count!=0)
            {
                IList<int>innerList=new List<int>();
                while (queue.Count!=0)
                {
                    var node = queue.Dequeue();
                    innerList.Add(node.val);
                    if (node.left != null)
                    {
                        tempQueue.Enqueue(node.left);
                    }
                    if(node.right!=null)
                    {
                        tempQueue.Enqueue(node.right);
                    }
                }
                ret.Add(innerList);
                (tempQueue, queue) = (queue, tempQueue);
            }

            return ret.Reverse().ToList();
        }
    }
}
