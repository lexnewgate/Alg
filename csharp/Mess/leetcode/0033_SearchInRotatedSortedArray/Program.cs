//#tag:BinarySearch,reduce
public class Solution
{

    public int Compare(int leftMost, int rightMost, int cur, int target)
    {
        if (cur >= leftMost)//左区间
        {
            if (cur > target)
            {
                if (target >= leftMost)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (cur < target)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else//右区间
        {
            if (cur > target)
            {
                return -1;
            }
            else if (cur < target)
            {
                if (target <= rightMost)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }

        }
    }

    public int BinarySearch(int[] nums, int target)
    {

        int l = 0;
        int h = nums.Length - 1;
        int leftMost = nums[0];
        int rightMost = nums[h];
        int mid;

        while (l <= h)
        {
            mid = l + ((h - l) >> 1); //prevent overflow

            if (Compare(leftMost, rightMost, nums[mid], target) > 0)
            {
                l = mid + 1; //向右缩进
            }

            else if (Compare(leftMost, rightMost, nums[mid], target) < 0)
            {
                h = mid - 1;//向左缩进
            }
            else //不大也不小,代表找到
            {
                return mid;
            }

        }

        return -1;
    }


    public int Search(int[] nums, int target)
    {
        return BinarySearch(nums, target);

    }

}