using System;
using System.Collections.Generic;

public class Solution
{
    public int NumIslands(char[][] grid)
    {

        if (grid == null || grid.Length==0|| grid[0] == null)
        {
            return 0;
        }

        //init
        bool[][] visited = new bool[grid.Length][];
        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        for (int i = 0; i < rowCount; i++)
        {
            visited[i] = new bool[colCount];
        }

        int ret = 0;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                if (!visited[i][j] && grid[i][j] == '1')
                {
                    ret++;
                    BFS(i, j, grid, visited);
                    Print(visited);
                }
            }
        }
        return ret;
    }

    void Print(bool[][] visited)
    {
        for (int i = 0; i < visited.Length; i++)
        {
            for (int j = 0; j < visited[0].Length; j++)
            {
                int rep = visited[i][j] ? 1 : 0;
                Console.Write($"{rep} ");
            } 
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    void BFS(int i, int j, char[][] grid, bool[][] visited)
    {
        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        Queue<int> queue = new Queue<int>();
        visited[i][j] = true;
        queue.Enqueue(i * colCount + j);
        Func<int, int, bool> ValidIndexFunc =
            (r, c) =>
                (r >= 0 && r < rowCount) &&
                (c >= 0 && c < colCount) &&
                visited[r][c] != true &&
                grid[r][c] == '1';

        while (queue.Count != 0)
        {
            //mark 
            int index = queue.Dequeue();
            int col = index % colCount;
            int row = (index - col) / colCount;

            //enqueue neib 
            int neiRow = 0;
            int neiCol = 0;

            neiRow = row + 1;
            neiCol = col;
            if (ValidIndexFunc(neiRow, neiCol))
            {
                visited[neiRow][neiCol] = true;
                queue.Enqueue(neiRow * colCount + neiCol);
            }

            neiRow = row - 1;
            neiCol = col;
            if (ValidIndexFunc(neiRow, neiCol))
            {
                visited[neiRow][neiCol] = true;
                queue.Enqueue(neiRow * colCount + neiCol);
            }

            neiRow = row;
            neiCol = col + 1;
            if (ValidIndexFunc(neiRow, neiCol))
            {
                visited[neiRow][neiCol] = true;
                queue.Enqueue(neiRow * colCount + neiCol);
            }
            neiRow = row;
            neiCol = col - 1;
            if (ValidIndexFunc(neiRow, neiCol))
            {
                visited[neiRow][neiCol] = true;
                queue.Enqueue(neiRow * colCount + neiCol);
            }
        }
    }

    static void Main(string[] args)
    {
        char[][] grid =
        {

            new char[]{'1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','0','1','0','1','1'},
            new char[]{'0','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','0'},
            new char[]{'1','0','1','1','1','0','0','1','1','0','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','0','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','0','1','1','1','1','1','1','0','1','1','1','0','1','1','1','0','1','1','1'},
            new char[]{'0','1','1','1','1','1','1','1','1','1','1','1','0','1','1','0','1','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'0','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','1','0','1','1','1','1','1','1','1','0','1','1','1','1','1','1'},
            new char[]{'1','0','1','1','1','1','1','0','1','1','1','0','1','1','1','1','0','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','0'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','0'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
            new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'}
        };

        Console.WriteLine( new Solution().NumIslands(grid));
    }
}
