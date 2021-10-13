#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include<math.h>
#include <stdbool.h>

static char res[16];
char * convertToBase7(int num)
{
    res[15]='\0';
    bool negative=num<0;
    num=abs(num);

    int ri=14;
    do
    {
        // printf("%d\n",num);
        int r= num % 7;
        res[ri--]=r+'0';

    } while ((num=num/7));
    
    if(negative) 
    {
        res[ri]='-';
        return &res[ri];
    }

    return &res[ri+1];
}

int main()
{
    char*s=convertToBase7(-7);
    printf("%s\n",s);
    return 0;
}