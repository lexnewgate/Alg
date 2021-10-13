#include <stdio.h>
#include <stdlib.h>
//做题时需要关注各个影响的变量，尤其是在对链表进行操作时可能会影响head或者tail指向的位置
//todo: check this //gcc -O -g -fsanitize=address LinkedList.c
//ds
typedef struct Node Node;
typedef Node *NodePtr;

typedef struct Node
{
    NodePtr prev;
    NodePtr next;
    int v;

} Node;

typedef struct DoublyLinkedList
{
    NodePtr head;
    NodePtr tail;
    int count;

} DoublyLinkedList;

//forward declare funcs
NodePtr CreateNode(int v);
NodePtr GetNode(DoublyLinkedList *dl, int index);

//interfaces
DoublyLinkedList *CreateDL()
{
    DoublyLinkedList *dlPtr = calloc(1, sizeof(DoublyLinkedList));
    return dlPtr;
}

void AddHead(DoublyLinkedList *dl, int v)
{
    NodePtr newHead = CreateNode(v);

    if (dl->count == 0) //刚创建dl
    {
        dl->count++;
        dl->head = dl->tail = newHead;
        return;
    }

    dl->count++;
    NodePtr oldHead = dl->head;
    dl->head = newHead;

    newHead->next = oldHead;
    oldHead->prev = newHead;
}

void AddTail(DoublyLinkedList *dl, int v)
{
    NodePtr newTail = CreateNode(v);

    if (dl->count == 0) //刚创建dl
    {
        dl->count++;
        dl->head = dl->tail = newTail;
        return;
    }

    dl->count++;
    NodePtr oldTail = dl->tail;
    dl->tail = newTail;

    oldTail->next = newTail;
    newTail->prev = oldTail;
}

int GetVal(DoublyLinkedList *dl, int index)
{
    NodePtr nodePtr = GetNode(dl, index);
    return nodePtr->v;
}

void InsertBefore(DoublyLinkedList *dl, int index, int v)
{
    NodePtr nodePtr = GetNode(dl, index);
    if (nodePtr == NULL)
    {
        return;
    }

    NodePtr first = nodePtr->prev;
    NodePtr third = nodePtr;

    //connect
    NodePtr sec = CreateNode(v);
    sec->prev = first;
    sec->next = third;

    if (first != NULL)
    {
        first->next = sec;
    }
    third->prev = sec;


    if(dl->count==0)
    {
        dl->head=dl->tail=sec;
    }
    else if(index==0)
    {
        dl->head=sec;   
    }

    dl->count++;


}

void InsertAfter(DoublyLinkedList *dl, int index, int v)
{
    NodePtr nodePtr = GetNode(dl, index);
    if (nodePtr == NULL)
    {
        return;
    }

    NodePtr first = nodePtr;
    NodePtr third = nodePtr->next;

    //connect
    NodePtr sec = CreateNode(v);
    sec->prev = first;
    sec->next = third;

    if (third != NULL)
    {
        third->prev = sec;
    }
    first->next = sec;
    dl->count++;
}

void RemoveNode(DoublyLinkedList *dl, int index)
{
    NodePtr target = GetNode(dl, index);
    if (target == NULL)
    {
        return;
    }

    if (target->prev != NULL)
    {
        target->prev->next = target->next;
    }
    if (target->next != NULL)
    {
        target->next->prev = target->prev;
    }

    if(dl->count==1)
    {
        dl->head=dl->tail=NULL;   
    }
    else if(dl->head==target)
    {
        dl->head=target->next;
    }
    else if(dl->tail==target)
    {
        dl->tail=target->prev;
    }

    dl->count--;
    free(target);
}

void RemoveHead(DoublyLinkedList *dl)
{
    RemoveNode(dl, 0);
}

void RemoveTail(DoublyLinkedList *dl)
{
    RemoveNode(dl, dl->count - 1);
}

void DestroyDL(DoublyLinkedList *dl)
{
    NodePtr cur = dl->head;
    while (cur != NULL)
    {
        NodePtr temp = cur;
        cur = cur->next;
        free(temp);
    }

    free(dl);
}

void DumpDL(DoublyLinkedList *dlPtr)
{
    if (dlPtr == NULL)
    {
        printf("DoublyLinkedList is NULL.");
    }
    else
    {
        printf("Dump DoublyLinkedList Infos:\n");
        printf("--count:%d\n", dlPtr->count);
        NodePtr cur = dlPtr->head;
        while (cur != NULL)
        {
            printf("%d ", cur->v);
            cur = cur->next;
        }
        printf("\n\n");
    }
}

//imps
NodePtr CreateNode(int v)
{
    NodePtr p = calloc(1, sizeof(Node));
    p->v = v;
    return p;
}

NodePtr GetNode(DoublyLinkedList *dl, int index)
{
    if (index < 0 || index >= dl->count)
    {
        return NULL;
    }

    int halfCount = dl->count / 2;
    if (index > halfCount) //backwards
    {
        int bindex = dl->count - 1 - index;
        NodePtr cur = dl->tail;
        while (bindex != 0)
        {
            bindex--;
            cur = cur->prev;
        }
        return cur;
    }
    else //forwards
    {
        NodePtr cur = dl->head;
        while (index != 0)
        {
            index--;
            cur = cur->next;
        }
        return cur;
    }
}

typedef DoublyLinkedList MyLinkedList;

/** Initialize your data structure here. */

MyLinkedList *myLinkedListCreate()
{
    return CreateDL();
}

/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
int myLinkedListGet(MyLinkedList *obj, int index)
{
    NodePtr targetNode = GetNode(obj, index);
    if (targetNode == NULL)
    {
        return -1;
    }
    return targetNode->v;
}

/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
void myLinkedListAddAtHead(MyLinkedList *obj, int val)
{
    AddHead(obj, val);
}

/** Append a node of value val to the last element of the linked list. */
void myLinkedListAddAtTail(MyLinkedList *obj, int val)
{
    AddTail(obj, val);
}

/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
void myLinkedListAddAtIndex(MyLinkedList *obj, int index, int val)
{
    if (index == obj->count)
    {
        AddTail(obj, val);
        return;
    }
    if (index > obj->count)
    {
        return;
    }
    InsertBefore(obj,index,val);
}

/** Delete the index-th node in the linked list, if the index is valid. */
void myLinkedListDeleteAtIndex(MyLinkedList *obj, int index)
{
    RemoveNode(obj, index);
}

void myLinkedListFree(MyLinkedList *obj)
{
    DestroyDL(obj);
}

/**
 * Your MyLinkedList struct will be instantiated and called as such:
 * MyLinkedList* obj = myLinkedListCreate();
 * int param_1 = myLinkedListGet(obj, index);
 
 * myLinkedListAddAtHead(obj, val);
 
 * myLinkedListAddAtTail(obj, val);
 
 * myLinkedListAddAtIndex(obj, index, val);
 
 * myLinkedListDeleteAtIndex(obj, index);
 
 * myLinkedListFree(obj);
*/

//gcc -O -g -fsanitize=address LinkedList.c
int main()
{

// ["addAtIndex","deleteAtIndex","addAtHead","addAtTail","get","addAtHead","addAtIndex","addAtHead"]
// [[3,0],[2],[6],[4],[4],[4],[5,0],[6]]

    MyLinkedList *obj = myLinkedListCreate();

    myLinkedListAddAtIndex(obj,0,10);
    DumpDL(obj);

    myLinkedListAddAtIndex(obj,0,20);
    DumpDL(obj);

    DumpDL(obj);

    // myLinkedListDeleteAtIndex(obj,0);

    DestroyDL(obj);
// [null,null,null,null,null,null,null,null,4,null,null,null]
    return 0;
}