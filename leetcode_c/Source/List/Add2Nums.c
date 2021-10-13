#include "LeetCode.h"

#define ListNode SinglyLinkedNode

typedef struct ListNode ListNode;



ListNode * CreateNode(int v)
{
    ListNode* ret= calloc(1,sizeof(ListNode));
    ret->val=v;
    return ret;
}

struct ListNode *addTwoNumbers(struct ListNode *l1, struct ListNode *l2)
{
    ListNode vHead;
    ListNode* p1=l1;
    ListNode*p2=l2;
    ListNode * cur=&vHead;

    int carry=0;
    while (p1!=NULL||p2!=NULL)
    {

        cur->next=CreateNode(carry);
        carry=0;

        if(p1==NULL)
        {
            int sum=(p2->val)+cur->next->val;
            if(sum>=10)
            {
                carry=1;
            }

            cur->next->val=(sum%10);
            cur=cur->next;
            p2=p2->next;
            continue;
        }

        if(p2==NULL)
        {
            int sum=(p1->val)+cur->next->val;
            if(sum>=10)
            {
                carry=1;
            }
            cur->next->val=(sum%10);
            cur=cur->next;
            p1=p1->next;
            continue;
        }

        int sum=p1->val+p2->val+cur->next->val;
        cur->next->val=(sum%10);
        if(sum>=10)
        {
            carry=1;
        }
        cur=cur->next;
        p1=p1->next;
        p2=p2->next;
    }

    if(carry==1)
    {
        cur->next=CreateNode(1);
    }

    return vHead.next;
    
}