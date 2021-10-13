#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>
#include <stdbool.h>

extern bool isBadVersion(int version);


int firstBadVersion(int n)
{
    if(isBadVersion(1))
    {
        return 1;
    }
    int h=n;    
    int l=1;
    while (l<=h)
    {
        int mid=((h-l)>>2)+l;
        if(isBadVersion(mid))
        {
            if(!isBadVersion(mid-1))
            {
                return mid;
            }
            else
            {
                h=mid-1;
            }
        }
        else
        {
            l=mid+1;
        }
    }

    return -1;
}

int main()
{
    return 0;
}