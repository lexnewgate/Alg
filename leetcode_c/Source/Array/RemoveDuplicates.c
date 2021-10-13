#include <stdio.h>

int removeDuplicates(int *nums, int numsSize)
{
    if(numsSize==0)
    {
        return 0;
    }

    int ret=1;
    int last=nums[0];

    for (int i = 1; i < numsSize; i++)
    {
        if(nums[i]!=last)
        {
            nums[ret++]=nums[i];
            last=nums[i];
        }
    }
    return ret;

}

int main()
{


    return 0;
}