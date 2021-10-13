
struct ListNode
{
    int val;
    struct ListNode *next;
};

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

typedef struct ListNode ListNode;

bool hasCycle(struct ListNode *head)
{
    if(head==NULL)
    {
        return false;
    }
    ListNode *fast =head;
    ListNode *slow =head;

    int fastStep=2;
    int slowStep=1;
    int fastCount=0;
    int slowCount=0;
    do
    {
        while (fastCount!=fastStep)
        {
            fastCount++;
            fast=fast->next;
            if(fast==NULL)
            {
                return false;
            }
        }
        fastCount=0;

        while (slowCount!=slowStep)
        {
            slowCount++;
            slow=slow->next;
            if(slow==NULL)
            {
                return false;
            }
        }
        slowCount=0;

        if(slow==fast)
        {
            return true;
        }

    } while (true);
}

int main()
{
    return 0;
}