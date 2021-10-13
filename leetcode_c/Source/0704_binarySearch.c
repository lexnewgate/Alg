#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>

int search(int* nums, int numsSize, int target)
{
    if(target<nums[0]||target>nums[numsSize-1])
    {
        return -1;
    }
    int l=0;
    int h=numsSize-1;
    int mid=0;
    int v=0;
    while (l<=h)
    {
        mid=((h-l)>>2)+l; 
        v=nums[mid];
        if(v==target)
        {
            return mid;
        }
        else if(v>target)
        {
            h=mid-1;
        }
        else
        {
            l=mid+1;
        }
    }
    return -1;
}


int main()
{
    return 0;
}