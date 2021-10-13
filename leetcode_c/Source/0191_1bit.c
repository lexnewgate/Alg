#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>

int hammingWeight(uint32_t n)
{
    int r=0;
    while (n)
    {
        n=n&(n-1);
        r++;
    }
    
    return r;
}

int main()
{
    uint32_t n=0b00000000010000000000000000001011;


    printf("%d\n",n);
    printf("%d\n",hammingWeight(n));

    return 0;
}