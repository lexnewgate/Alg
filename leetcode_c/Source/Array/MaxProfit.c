#include<stdio.h>

int maxProfit(int* prices, int pricesSize)
{
    int pre=prices[0];
    int buy=-1;
    int profit=0;
    for (int i = 1; i <pricesSize ; i++)
    {
        int cur=prices[i];
        if(cur>pre&&buy==-1)//buy pre 
        {
            buy=pre;
            // printf("buy :%d ",buy);
        }
        else if(cur<pre&&buy!=-1)//sell pre 
        {
            profit+=pre-buy;
            buy=-1;
            // printf("sell:%d ",pre);
        }
        
        if((i==pricesSize-1)&&buy!=-1&&cur>=pre) //sell cur
        {
            profit+=(cur-buy);   
            // printf("sell:%d ",cur);
        }
        pre=cur;
        // printf("cur:%d\n",cur);
    }

    return profit;
    
}

int main()
{
    int prices[]={1,9,6,9,1,7,1,1,5,9,9,9};
    int profit= maxProfit(prices,sizeof(prices)/sizeof(int));
    printf("%d\n",profit);

    return 0;
}