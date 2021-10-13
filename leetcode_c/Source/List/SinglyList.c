#include "SinglyList.h"
#include <stdlib.h>
#include <stdio.h>

SinglyList * CreateSinglyList(int *a, int count)
{
    SinglyList* list= CreateEmptySinglyList();
    SinglyLinkedNode * last= list->head;

    for (int i = 0; i < count; i++)
    {
        last->next= CreateNode(a[i]);
        last=last->next;
    }

    return list;
}

SinglyList * CreateEmptySinglyList()
{
    SinglyList* list= calloc(1,sizeof(SinglyList));   
    list->head=CreateNode(0);
    return list;
}

void DestroySinglyList(SinglyList* list)
{
    SinglyLinkedNode *cur= list->head;
    while (cur!=NULL)
    {
        SinglyLinkedNode*temp=cur->next;
        free(cur);
        cur=temp;
    }

    free(list);
}

void PrintList(SinglyList*list)
{
    SinglyLinkedNode * node = list->head->next;
    while (node!=NULL)
    {
        printf("%d=>",node->val);
        node=node->next;
    }
    
    printf("NULL\n");
}

void PrintNodeList(SinglyLinkedNode*node)
{
    while (node!=NULL)
    {
        printf("%d=>",node->val);
        node=node->next;
    }
    
    printf("NULL\n");
}

SinglyList * Reverse(SinglyList*list)
{

}

SinglyLinkedNode * CreateNode(int val)
{
    SinglyLinkedNode* node= calloc(1,sizeof(SinglyLinkedNode));
    node->val=val;
}


