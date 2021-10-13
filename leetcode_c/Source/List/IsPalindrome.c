#include "LeetCode.h"

#define ListNode SinglyLinkedNode

typedef struct ListNode ListNode;

void PushToStack(ListNode* top,ListNode*val)
{
    val->next=top->next;
    top->next=val;
}

ListNode* PopStack(ListNode*top)
{
    ListNode* ret= top->next;
    top->next=top->next->next;
    return ret;
}

bool IsStackEmpty(ListNode*top)
{
    return top->next==NULL;
}


bool isPalindrome(struct ListNode* head){

    if(head==NULL||head->next==NULL)
    {
        return true;
    }

    //init stack
    ListNode vStackH;
    vStackH.next=NULL;

    ListNode*f= head->next;
    ListNode*s= head;

    while (f!=NULL&&f->next!=NULL)
    {
        f=f->next->next;
        ListNode *temp= s;
        s=s->next;
        PushToStack(&vStackH,temp);
    }

    if(f!=NULL)
    {
        ListNode *temp= s;
        s=s->next;
        PushToStack(&vStackH,temp);
    }
    else
    {
        s=s->next;
    }


    while (s!=NULL)
    {
        ListNode* top= PopStack(&vStackH);
        if(s->val==top->val)
        {
            s=s->next;
        }
        else
        {
            return false;
        }
    }

    return vStackH.next==NULL;
}

