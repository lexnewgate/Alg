#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>
#include <stdbool.h>
//移位或者运算时,需要记得如果思维模式是以uint来思考,一定要注意是否在用int
int rangeBitwiseAnd(int left, int right)
{
    uint uileft=left;
    uint uiright=right;
    if(uileft==0) return 0;
    int res=0;
    uint nleft;
    while (uileft!=0)
    {
        //del last 1
        nleft=uileft&(uileft-1);
        //only last 1
        uint v=uileft-nleft;
        uint test=nleft+(v<<1);
        if(test>uiright)
        {
            res|=v;
        }
        uileft=nleft;
    }

    // printf("%d\n",res);
    return res;
}

int main()
{
    rangeBitwiseAnd(2147483646,2147483647);
    return 0;
}