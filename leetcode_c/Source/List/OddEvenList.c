#include "LeetCode.h"

#define ListNode SinglyLinkedNode

typedef struct ListNode ListNode;

struct ListNode* oddEvenList(struct ListNode* head)
{
    if(head==NULL)
    {
        return head;
    }
    ListNode* oh= head;
    ListNode* eh= head->next;

    if(eh==NULL)
    {
        return head;
    }

    ListNode*oc= oh;
    ListNode*ec= eh;
    ListNode*cur=ec->next;
    oc->next=NULL;
    ec->next=NULL;
    bool isOdd=true;
    while (cur!=NULL)
    {
        ListNode*temp=cur;
        cur=cur->next;
        temp->next=NULL;
        if(isOdd)
        {
            oc->next=temp;
            oc=temp;
        }
        else
        {
            ec->next=temp;
            ec=temp;
        }
        isOdd=!isOdd;
    }
    oc->next=eh;
    return oh;
}

