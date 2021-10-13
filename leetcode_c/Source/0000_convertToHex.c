#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>
#include <stdbool.h>

static char res[9];
char * toHex(int num)
{
    if(num==0)
    {
        return "0";
    }

    res[8]='\0';
    unsigned int unum=num;
    int i=7;
    while (unum!=0)
    {
        // printf("%d\n",unum);
        int last4=unum&0xf;
        unum=unum>>4;
        if(last4<10)
        {
            res[i--]=last4+'0';
            continue;
        }
        else
        {
            int offset=last4-10;
            res[i--]='a'+offset;
        }

    }

    return &res[i+1]; 

}

int main()
{
    // toHex(26);
    printf("%d",26>>4);
    return 0;
}