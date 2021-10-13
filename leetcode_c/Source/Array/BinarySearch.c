#include<stdio.h>
//nums should be already sorted
int BinarySearch(int*nums,int numSize,int target)
{
    if(nums==NULL||numSize==0)
    {
        return -1;
    }

    int low=0,high=numSize-1;

    while (low<=high)
    {
        int mid=(low+high)/2;        
        if(target>nums[mid])
        {
            low=mid+1;
        }
        else if(target<nums[mid])
        {
            high=mid-1;
        }
        else
        {
            return mid;
        }
    }

    return -1;
}
