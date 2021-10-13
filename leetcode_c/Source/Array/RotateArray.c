#include<stdio.h>


void printArray(int* nums, int numsSize)
{
    for (int i = 0; i < numsSize; i++)
    {
        printf("%d ",nums[i]);
    }

    printf("\n");
}

void rotate(int* nums, int numsSize, int k)
{
    int targetV=-1;
    int sourceV=nums[0];
    int j=0;
    int start=0;
    for (int i = 0; i < numsSize; i++)
    {
        int targetIndex=(j+k)%numsSize;
        targetV=nums[targetIndex];
        // printf("move v:%d to v:%d",sourceV,targetV);
        nums[targetIndex]=sourceV;
        // printf("\ttarget Index:%d sourceV:%d",targetIndex,sourceV);
        sourceV=targetV;
        j=targetIndex;
        // printf(" j loop end:%d\n",j);
        if(j==start)
        {
            // printf("break\n");
            j++;
            start++;
            sourceV=nums[(j)%numsSize];
        }

    }

    // printf("\n");

}



int main()
{
    int nums[]={0,1,2,3};
    rotate(nums,(sizeof nums)/(sizeof (int)),2);
    printArray(nums,(sizeof nums)/(sizeof (int)));

    return 0;
}