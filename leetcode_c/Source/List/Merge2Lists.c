#include "LeetCode.h"

#define ListNode SinglyLinkedNode

typedef struct ListNode ListNode;

struct ListNode *mergeTwoLists(struct ListNode *l1, struct ListNode *l2)
{
    ListNode vHead;
    vHead.next=NULL;
    ListNode * cur=&vHead;
    while (l1!=NULL||l2!=NULL)
    {
        if(l1==NULL)
        {
           cur->next=l2; 
           return vHead.next;
        }
        if(l2==NULL)
        {
            cur->next=l1;
            return vHead.next;
        }

        if(l1->val<l2->val)
        {
            cur->next=l1;
            cur=cur->next;
            l1=l1->next;
        }
        else
        {
            cur->next=l2;
            cur=cur->next;
            l2=l2->next;
        }
    }
    return vHead.next;
    
}