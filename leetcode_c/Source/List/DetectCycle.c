#include <stdio.h>

struct ListNode
{
    int val;
    struct ListNode *next;
};

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

typedef struct ListNode ListNode;
struct ListNode *detectCycle(struct ListNode *head)
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
                return NULL;
            }
        }
        fastCount=0;

        while (slowCount!=slowStep)
        {
            slowCount++;
            slow=slow->next;
            if(slow==NULL)
            {
                return NULL;
            }
        }
        slowCount=0;

        if(slow==fast)
        {
            ListNode *ret=head;
            while (ret!=slow)
            {
                ret=ret->next;
                slow=slow->next;
            }
            return ret;
            
        }

    } while (true);
}

int main()
{
    return 0;
}