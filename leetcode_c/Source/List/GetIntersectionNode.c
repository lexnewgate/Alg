#include <stdio.h>

struct ListNode
{
    int val;
    struct ListNode *next;
};

typedef struct ListNode ListNode;

int GetLength(ListNode* head)
{
    int ret=0;
    while (head!=NULL)
    {
        ret++;
        head=head->next;
    }
    return ret;
}

ListNode* MoveNext(ListNode*cur,int a)
{
    while (a!=0)
    {
        cur=cur->next;
        a--;
    }

    return cur;
}

struct ListNode *getIntersectionNode(struct ListNode *headA, struct ListNode *headB)
{
    int lenA= GetLength(headA);
    int lenB= GetLength(headB);
    int diffAB= lenA-lenB;
    if(diffAB>0)//move a first
    {
        headA=MoveNext(headA,diffAB);
    }
    else if(diffAB<0)//move b first
    {
        diffAB=-diffAB;
        headB=MoveNext(headB,diffAB);
    }

    while ((headA!=headB)&&(headA!=NULL)&&(headB!=NULL))
    {
        headA=headA->next;   
        headB=headB->next;
    }

    if(headA==headB)
    {
        if(headA==NULL) return NULL;
        else return headA;
    }
    return NULL;
    
}



int main()
{
    return 0;
}