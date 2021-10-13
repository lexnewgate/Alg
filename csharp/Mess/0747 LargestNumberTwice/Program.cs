public class Solution
{
    public int DominantIndex(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return -1;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }


        int max = 0;
        int maxi = 0;
        int secToMax = 0;

        if (nums[0] > nums[1])
        {
            max = nums[0];
            maxi = 0;
            secToMax = nums[1];
        }
        else
        {
            max = nums[1];
            maxi = 1;
            secToMax = nums[0];
        }

        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                secToMax = max;
                max = nums[i];
                maxi = i;
            }
            else
            {
                
            }
        }





    }
}
