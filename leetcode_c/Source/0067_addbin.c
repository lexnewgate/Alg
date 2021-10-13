#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void swapstr(char **a, char **b)
{
    char *temp = *a;
    *a = *b;
    *b = temp;
}

void swapint(int *a, int *b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}

int addBin(char *a, char *b, char *r, int carry)
{
    int ia = *a - '0';
    int ib = b == 0 ? 0 : *b - '0';
    int sum = ia + ib + carry;
    *r = sum % 2 + '0';
    carry = sum / 2;

    return carry;
}

char *addBinary(char *a, char *b)
{
    int la = strlen(a);
    int lb = strlen(b);

    if (la < lb)
    {
        swapstr(&a, &b);
        swapint(&la, &lb);
    }
    //a has longest length
    char *r = malloc(sizeof(char) * (la + 2));
    char *re = r + (la + 1);
    *(re--) = '\0';
    char *ae = a + la - 1;
    char *be = b + lb - 1;

    int carry = 0;
    for (size_t i = 0; i < lb; i++)
    {
        carry = addBin(ae, be, re, carry);

        ae--;
        be--;
        re--;
    }

    for (size_t i = 0; i < la - lb; i++)
    {
        carry = addBin(ae, 0, re, carry);
        ae--;
        re--;
    }

    if (carry)
    {
        *re = '1';
    }
    else
    {
        re++;
    }

    return re;
}

int main()
{

    int ia = 3;
    int ib = 4;
    swapint(&ia, &ib);
    printf("%d\n", ia);
    printf("%d\n", ib);

    char *sa = "sa";
    char *sb = "sb";
    swapstr(&sa, &sb);
    printf("%s\n", sa);
    printf("%s\n", sb);

    printf("%s\n", addBinary("10", "1111"));

    return 0;
}