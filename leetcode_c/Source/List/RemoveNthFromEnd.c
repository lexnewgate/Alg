struct ListNode
{
    int val;
    struct ListNode *next;
};

#include <stdbool.h>
#include <stdio.h>
typedef struct ListNode ListNode;

struct ListNode *removeNthFromEnd(struct ListNode *head, int n)
{
    ListNode *cur = head;
    int count = 0;
    while (cur != NULL)
    {
        cur = cur->next;
        count++;
    }

    int index = count - n;
    cur = head;
    ListNode *last = head;
    while (index != 0)
    {
        last = cur;
        cur = cur->next;
        index--;
    }

    if (last == cur)
    {
        head = head->next;
        last->next = NULL;
    }
    else
    {
        last->next = cur->next;
        cur->next = NULL;
    }

    return head;
}