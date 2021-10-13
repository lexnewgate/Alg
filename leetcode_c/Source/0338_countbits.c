#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* countBits(int n, int* returnSize)
{
    *returnSize=n+1;
    int*ret= malloc(sizeof(int)*(n+1));

    ret[0]=0;
    if(n==0)
    {
        return ret;
    }

    ret[1]=1;
    if(n==1)
    {
        return ret;
    }

    int k=2; 
    int kbase=0;
    for(int i=2;i<=n;i++)
    {
        if(i>=k)
        {
            kbase=k;
            k<<=1;
        }
        ret[i]=ret[i-kbase]+1;
    }

    return ret;
}

void Print(int n,int *arr)
{
    for (size_t i = 0; i < n; i++)
    {
        printf("%d ",arr[i]);
    }

    printf("\n");
    
}

int main()
{
    int n;
    n=5;
    int a;
    Print(n+1, countBits(n,&a));
}