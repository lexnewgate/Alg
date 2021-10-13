using System;

namespace x0268_MissingNum
{
    public class Solution
    {
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            Int64 left = n * (n+1);
            for (int i = 0; i < n; i++)
            {
                left -=  (nums[i]<<1);
            }

            return (int)(left>>1);
        }

     }
}
