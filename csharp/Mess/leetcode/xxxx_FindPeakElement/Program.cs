using System;
using System.Data;

public class Solution
{
    public int compare(int cur,int min,int max,int []nums)
    {
        int left = cur-1;
        bool greaterOrEqThanLeft = false;
        bool greaterOrEqThanRight = false;
        if (left < min)
        {
            greaterOrEqThanLeft = true;
        }
        else
        {
            greaterOrEqThanLeft = nums[cur] >= nums[left];
        }

        int right = cur + 1;
        if (right > max)
        {
            greaterOrEqThanRight = true;
        }
        else
        {
            greaterOrEqThanRight = nums[cur] >= nums[right];
        }

        if (greaterOrEqThanLeft && greaterOrEqThanRight)
        {
            return 0;
        }

        if (greaterOrEqThanLeft)
        {
            return 1;
        }
        else
        {
            return -1;
        }
     
    }

    public int BinarySearch( int l,int h,int[] nums)
    {
        int mid;
        int min = l;
        int max = h;

        while (l <= h)
        {
            mid = l + ((h - l) >> 1); //prevent overflow

            if (compare(mid,l,max,nums)>0)
            {
                l = mid + 1;
            }

            else if (compare(mid,l,max,nums)<0)
            {
                h = mid - 1;
            }
            else //不大也不小,代表找到
            {
                return mid;
            }

        }

        return -1;
    }

    public int FindPeakElement(int[] nums)
    {
        return BinarySearch(0, nums.Length - 1, nums);
    }
}