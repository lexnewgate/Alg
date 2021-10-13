#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>

//插入排序太慢 直接挂掉了...

/** 
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* sortArray(int* nums, int numsSize, int* returnSize){
    //  int *sorted=malloc(numsSize*sizeof(int));
     *returnSize=numsSize;
    //  sorted[0]=nums[0];
     for(int i=1;i<numsSize;i++)
     {
         int key=nums[i];
         int j;

        //  printf("i:%d key:%d\n",i,key);
         
         for(j=i-1;j>=0;j--)
         {
            //  printf("numsj:%d\n",nums[j]);
             if(nums[j]>key)
             {
                 nums[j+1]=nums[j];
             }
             else
             {
                 break;
             }
         }
         nums[j+1]=key;
     }

     return nums;
}

int main()
{
    int array[]={0,0,1,1,2,5};
    int retSize;
    int *sortedArray=sortArray(array,sizeof(array)/sizeof(int),&retSize);
    for(int i=0;i<retSize;i++)
    {
        printf("%d ",sortedArray[i]);
    }

    return 0;
}