#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>

static int gmax=0;
static int gmaxc=1;

int f(int *nums,int n)
{
    if(n==0)
    {
        return 1;
    }

    int ret=1;
    int max=0;
    for(int i=0;i<n;i++)
    {
        if(nums[i]<nums[n])
        {
            int fi=f(nums,i);
            max=max>=fi?max:fi;
            // printf("max:%d\n",max);
            if(gmax==max)
            {
                // printf("max:%d gmax:%d\n",max,gmax);
                printf("a");
                gmaxc++;
            }
            else if(gmax<max)
            {
                // printf("gmax:%d max:%d\n",gmax,max);
                printf("\n");
                gmax=max;   
                gmaxc=1;
            }
        }
        else if(nums[i]==nums[n]&&gmax==max)
        {
            gmaxc++;
        }
    }

    return max+1; 
}

int findLIS(int*nums,int numsSize)
{
   int max=0;
   for(int i=0;i<numsSize;i++)
   {
       int fn=f(nums,i);
       max=max>fn?max:fn;
   } 
   return max;
}

int findNumberOfLIS(int* nums, int numsSize){
    gmax=0;
    gmaxc=1;
    // printf("numSize:%d\n",numsSize);
   int max= findLIS(nums,numsSize);

     printf("longest:%d\n",max);
    return gmaxc;
}

int main()
{
    int a[]={2,2,2,2,2};
    printf("ret:%d\n",findNumberOfLIS(a,sizeof(a)/sizeof(int)));
    return 0;
}