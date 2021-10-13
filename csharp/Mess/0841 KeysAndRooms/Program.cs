using System.Collections.Generic;

public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        int roomNum = rooms.Count;
        Queue<int>queue=new Queue<int>();
        queue.Enqueue(0);
        bool[]visited=new bool[roomNum];
        visited[0] = true;
        int visitedCount = 0;

        while (queue.Count!=0)
        {
            visitedCount++;
            var cur = queue.Dequeue();
            for (int i = 0; i < rooms[cur].Count; i++)
            {
                int neibRoomNum = rooms[cur][i];
                if (!visited[neibRoomNum])
                {
                    queue.Enqueue(neibRoomNum);
                    visited[neibRoomNum] = true;
                }
            }
        }

        return visitedCount==roomNum;
    }
}