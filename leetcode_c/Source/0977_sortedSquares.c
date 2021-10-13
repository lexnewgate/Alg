#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>
#include <stdbool.h>


int* sortedSquares(int* nums, int numsSize, int* returnSize)
{
    *returnSize=numsSize;
    int *ret=malloc(sizeof(int)*numsSize);
    int j=0;
    int k=numsSize-1;
    for(int i=numsSize-1;i>=0;i--)
    {
        int a=(nums[j]*nums[j]);
        int b=(nums[k]*nums[k]);
        if(a>b)
        {
            ret[i]=a;
            j++;
        }
        else
        {
            ret[i]=b;
            k--;
        }
    }
    return ret;
}

int main()
{
    return 0;
}