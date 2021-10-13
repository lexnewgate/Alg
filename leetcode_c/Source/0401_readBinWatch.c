#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>

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


char* time2Str(int hour,int min)
{
    // printf("hour:%d min:%d\n",hour,min);
    char* ret;
    int hc=0;
    if(hour>9)
    {
        ret=malloc(sizeof(char)*6);
        ret[0]='1';
        ret[1]= hour-10+'0';
        ret[2]=':';
        hc=3;
        ret[5]='\0';
    }
    else
    {
        ret=malloc(sizeof(char)*5);
        ret[0]=hour+'0';
        ret[1]=':';
        hc=2;
        ret[4]='\0';
    }

    if(min>9)
    {
        ret[hc]=min/10+'0';
        hc++;
        ret[hc]=min%10+'0';
    }
    else
    {
        ret[hc]='0';
        hc++;
        ret[hc]=min+'0';
    }
    // printf("ret:%s\n",ret);
    return ret;
}

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
char ** readBinaryWatch(int turnedOn, int* returnSize)
{
    char** ret=malloc(sizeof(char*)*1024);
    int c=0;
    for (size_t i = 0; i < 1024; i++)
    {
        if(hammingWeight(i)==turnedOn)
        {
            int hour= ((i&0b1000000000)?8:0)+
                      ((i&0b0100000000)?4:0)+
                      ((i&0b0010000000)?2:0)+
                      ((i&0b0001000000)?1:0);
            if(hour>11)
            {
                continue;
            }

            int min=  ((i&0b0000100000)?32:0)+
                      ((i&0b0000010000)?16:0)+
                      ((i&0b0000001000)?8:0)+
                      ((i&0b0000000100)?4:0)+
                      ((i&0b0000000010)?2:0)+
                      ((i&0b0000000001));

            if(min>59)
            {
                continue;
            }

            ret[c++]=time2Str(hour,min);
        }
    }

    *returnSize=c;

    return ret;
}


int main()
{


    int n;
    char**ret=readBinaryWatch(9,&n);
    printf("%d\n",n);
    for(int i=0;i<n;i++)
    {
        printf("%s\n",*ret++);
    }

    return 0;
}