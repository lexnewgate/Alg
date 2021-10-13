public class Solution
{


    public int BinSearch(int[] nums, int target)
    {
        int l = 0;
        int h = nums.Length-1;
        int mid = 0;

        while (l<=h)
        {
            mid = (l + h) / 2;

            if (target > nums[mid])
            {
                l = mid + 1;
            }

            else if(target<nums[mid])
            {
                h = mid - 1;
            }
            else
            {
                return mid;
            }

        }

        return -1;
    }
}
