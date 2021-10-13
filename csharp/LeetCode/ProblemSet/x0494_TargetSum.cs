using System.Collections.Generic;
using System.Linq;

//todo: dp, DFS vs BFS

namespace x0494_TargetSum
{
    public class Solution
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            List<int> list = new List<int>();
            List<int> tempList = new List<int>();
            list.Add(0);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    var v = list[j];
                    tempList.Add(v + nums[i]);
                    tempList.Add(v - nums[i]);
                }

                (tempList, list) = (list, tempList);
                tempList.Clear();
            }

            return list.Count(v => v == S);
        }
    }

}
