#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
#include <stdbool.h>

void rotate(int *nums, int numsSize, int k)
{
    int handled = 0;
    k=k%numsSize;
    for (size_t i = 0; i < k; i++)
    {
        if (handled & (1<<i))
        {
            continue;
        }
        else
        {
            handled|=(1<<i);
        }

        int start = i; 
        int temp = nums[start];
        int nextIndex = ((start + k) % numsSize);
        while(nextIndex!=start)
        {
            if(nextIndex>=0&&nextIndex<k)
            {
                handled|=1<<nextIndex;
            }
            int temp1 = nums[nextIndex];
            nums[nextIndex] = temp;
            temp = temp1;
            nextIndex=(nextIndex+k)%numsSize;
        }

        nums[start] = temp;
    }

    // for (size_t i = 0; i < numsSize; i++)
    // {
    //     printf("%d ",nums[i]);
    // }
    // printf("\n");
    
}

int main()
{
    int a[]={1,2};
    rotate(a,sizeof(a)/sizeof(int),3);
    return 0;
}