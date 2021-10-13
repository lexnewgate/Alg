#include <stdio.h>
int pivotIndex(int *nums, int numsSize)
{
    if(numsSize==0)
    {
        return -1;
    }

    int sum=0;
    for (int i = 0; i < numsSize; i++)
    {
        sum+=nums[i];
    }

    int left=0,right=sum-nums[0];
    for (int i = 0; i < numsSize; i++)
    {
       if(left==right)
       {
           return i;
       } 
       else if(i+1<numsSize) 
       {
           left+=nums[i];
           right-=nums[i+1];
       }
    }

    if(left==0) return numsSize-1;
    else return -1;
}

int main()
{
    return 0;
}