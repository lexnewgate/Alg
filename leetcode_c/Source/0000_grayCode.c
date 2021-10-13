#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
#include <stdbool.h>

int *grayCode(int n, int *returnSize)
{
    *returnSize = pow(2, n);
    int *ret = malloc(*returnSize * sizeof(int));
    ret[0]=0;
    if(n==0)
    {
        return ret;
    }

    ret[1]=1;
    int i=2;
    int h=1;
    while (i<*returnSize)
    {
        int ii=i-1;
        while (ii>=0)
        {
            ret[i]=(1<<h)+ret[ii];
            ii--;
            i++;
        }
        h++;
    }

    return ret;
}

int main()
{
    int n = 0;
    int retSize;
    grayCode(n, &retSize);
    printf("ret size:%d\n", retSize);

    return 0;
}