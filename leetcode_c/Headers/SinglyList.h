#ifndef SINGLY_LIST
#define SINGLY_LIST

typedef struct SinglyLinkedNode
{
    int val;
    struct SinglyLinkedNode *next;
} SinglyLinkedNode;

typedef struct SinglyList
{
    SinglyLinkedNode *head;
    int count;
} SinglyList;

SinglyList * CreateEmptySinglyList();
SinglyList * CreateSinglyList(int *a, int count);
void DestroySinglyList(SinglyList* list);
void PrintList(SinglyList*list);
SinglyList * Reverse(SinglyList*list);
SinglyLinkedNode * CreateNode(int val);
void PrintNodeList(SinglyLinkedNode*node);
#endif