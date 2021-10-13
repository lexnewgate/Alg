using System.Collections.Generic;

//#tag:Dict
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        //key为数组元素的值,val为数组元素的index
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int subT = target - nums[i];
            if (dict.ContainsKey(subT))
            {
                return new[] {dict[subT], i};
            }

            dict[nums[i]] = i;
        }
        return null;
    }
}
