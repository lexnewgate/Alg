using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Solution
{

    public int[] FindDiagonalOrder(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0|| matrix[0].Length == 0)
        {
            return new int[0];
        }

        int m = matrix.Length;
        int n = matrix[0].Length;
        //int maxd = m > n ? m : n;
        int l = m + n - 1;
        int leftX = 0;
        int leftY = -1;
        int rightX = -1;
        int rightY = 0;

        int startx = 0;
        int starty = 0;
        int endx = 0;
        int endy = 0;
        bool left2Right = false;
        int []res=new int[m*n];
        int index = 0;
        for (int i = 0; i < l; i++)
        {
            if (rightX < n - 1)
            {
                rightX++;
            }
            else
            {
                rightY++;
            }

            if (leftY < m - 1)
            {

                leftY++;
            }
            else
            {
                leftX++;
            }

            if (i % 2 == 0)
            {
                startx = leftX;
                starty = leftY;
                endx = rightX;
                endy = rightY;
                left2Right = true;
            }
            else
            {
                left2Right = false;
                startx = rightX;
                starty = rightY;
                endx = leftX;
                endy = leftY;
            }

            int x = startx;
            int y = starty;
            if (left2Right)
            {
                while (x <= endx && y >= endy)
                {
                    //Console.Write($"{matrix[y][x]} ");
                    res[index++] = matrix[y][x];
                    x += 1;
                    y -= 1;
                }
            }
            else
            {
                while (x >= endx && y <= endy)
                {
                    //Console.Write($"{matrix[y][x]} ");
                    res[index++] = matrix[y][x];
                    x -= 1;
                    y += 1;
                }
            }
        }

        return res;
    }

    //static void Main()
    //{
    //    new Solution().FindDiagonalOrder(new int[][]
    //    {
    //        new []{1,2,3,4,},
    //        new []{5,6,7,8},
    //        //new []{9,10,11,12},
    //        //new []{13,14,15,16}
    //    });
    //}

}
