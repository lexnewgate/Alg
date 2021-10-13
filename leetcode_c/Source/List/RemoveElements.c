#include "LeetCode.h"
#define ListNode SinglyLinkedNode
typedef struct ListNode ListNode;

struct ListNode* removeElements(struct ListNode* head, int val)
{
    if(head==NULL)
    {
        return head;
    }

    ListNode vHead;
    vHead.next=head;

    ListNode* cur=head;
    ListNode*last= &vHead;
    ListNode*temp;

    while (cur!=NULL)
    {
        if(cur->val==val)
        {
           temp=cur; 
           cur=cur->next;
           last->next=cur;
           free(temp);
        }
        else
        {
           last=cur; 
           cur=cur->next;
        }
    }

    return vHead.next;
}