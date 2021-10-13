#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>
#include <stdbool.h>

int searchInsert(int* nums, int numsSize, int target)
{
    int l=0;
    int h=numsSize-1;
    while (l<=h)
    {
        int mid=((h-l)>>2)+l;
        if(nums[mid]==target)
        {
            return mid;
        }
    }
    
}
int main()
{
    return 0;
}