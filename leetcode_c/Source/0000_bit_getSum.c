#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
#include <stdbool.h>

int getSum(int a, int b)
{
    uint ua=a;
    uint ub=b;
    uint carry = (ua & ub) << 1;
    if (carry == 0)
        return ua | ub;
    while (carry)
    {
        ua = ua ^ ub;
        ub = carry;
        carry = ((ua & ub) << 1);
    }

    ua = ua ^ ub;
    return ua;
}

int main()
{
    int a = getSum(-1, 1);
    printf("%d", a);
    return 0;
}