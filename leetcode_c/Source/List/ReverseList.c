#include "LeetCode.h"

#define ListNode SinglyLinkedNode
struct ListNode* reverseList(struct ListNode* head);

int main()
{
    int a[]={2,3,4,51,2};
    SinglyList*list= CreateSinglyList(a,sizeof(a)/sizeof(int));
    PrintList(list);
    printf("---------\n");
    reverseList(list->head->next);
    printf("---------\n");
    PrintList(list);
    DestroySinglyList(list);

    return 0;
}


typedef struct ListNode ListNode;


struct ListNode* reverseList(struct ListNode* head)
{
    if(head==NULL)
    {
        return NULL;
    }

    ListNode vHead;

    vHead.next=head;
    ListNode* pivot = head;
    while (pivot->next!=NULL)
    {
        ListNode* pivotOldR= pivot->next;
        pivot->next=pivotOldR->next;
        pivotOldR->next=vHead.next;
        vHead.next=pivotOldR;
    }
    return vHead.next;
}