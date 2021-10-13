#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
#include <stdbool.h>

int singleNumber(int *nums, int numsSize)
{
    int ret=0;
    for (size_t i = 0; i < numsSize; i++)
    {
        ret^=nums[i];
    }

    return ret; 
}

int main()
{
    return 0;
}