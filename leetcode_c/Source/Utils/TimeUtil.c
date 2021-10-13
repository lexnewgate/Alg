#include <stdio.h>
#include <time.h>

clock_t start, end;
double time_used;

void StartTimer()
{
    start = clock();
}

void EndTimer()
{
    end=clock();
}

void PrintTimeUsed()
{
    time_used = ((double)(end - start)) / CLOCKS_PER_SEC;
}

int main()
{



    return 0;
}