#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>

int binaryGap(int n){

    int n1;
    int n2;

    n1=n&(n-1);
    //只有一个1
    if(n1==0)
    {
        return 0;
    }

    //100..0
    int stop1= n-n1;

    n2=n1&(n1-1);
    int stop2=n1-n2;

    int maxGap=log2(stop2)-log2(stop1);
    int gap;

    while(n2)
    {
        stop1=stop2;
        n1=n2&(n2-1);
        stop2=n2-n1;
        gap=log2(stop2)-log2(stop1); 
        maxGap=maxGap<gap? gap:maxGap;
        n2=n1;
    }

    return maxGap;
}

int main()
{
    int n=1;
    int maxGap=binaryGap(n);
    printf("%d\n",maxGap);
    return 0;
}