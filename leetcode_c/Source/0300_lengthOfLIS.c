#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>

int max(int*maxn,int index,int cur,int *nums)
{
    int ret=0;
    for(int i=0;i<=index;i++)
    {
        if(cur>nums[i])
        {
            ret=maxn[i]>ret?maxn[i]:ret;
        }
    }
    return ret;
}

int lengthOfLIS(int* nums, int numsSize)
{
    int * maxn= malloc(numsSize*sizeof(int));
    maxn[0]=1;
    int ret=1;
    for (size_t i = 1; i < numsSize; i++)
    {
        maxn[i]= max(maxn,i-1,nums[i],nums)+1;
        ret=maxn[i]>ret? maxn[i]:ret;
    }
    free(maxn);

    return ret;
}

int main()
{
    return 0;
}