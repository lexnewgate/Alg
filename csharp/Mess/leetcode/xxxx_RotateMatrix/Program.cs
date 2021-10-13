using System;

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        int halfn = n / 2;


        for (int k = 0; k <=halfn ; k++)
        {
            int step = n-2*k - 1;

            //Console.WriteLine("first round");
            //Print(matrix);

            for (int j = 0; j < step; j++)
            {
                int x = j+k;
                int y = k;
                int write = matrix[y][x];
                int temp;
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        x += step;
                        if (x > step+k)
                        {
                            y += (x - step-k);
                            x = step+k;
                        }
                    }
                    else if (i == 1)
                    {
                        y += step;
                        if (y > step+k)
                        {
                            x -= (y - step-k);
                            y = step+k;
                        }
                    }
                    else if (i == 2)
                    {
                        x -= step;
                        if (x < k)
                        {
                            y -= (k-x);
                            x = k;
                        }
                    }
                    else
                    {
                        y -= step;
                        if (y < k)
                        {
                            x += (k-y);
                            y = k;
                        }
                    }

                    temp = matrix[y][x];
                    matrix[y][x] = write;
                    write = temp;
                }
            }
        }
    }

    //[[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]

    //static void Main()
    //{
    //    int[][] input = new int[][]
    //    {
    //        new []{1,2,3,4,5},
    //        new []{6,7,8,9,10},
    //        new []{11,12,13,14,15},
    //        new []{16,17,18,19,20},
    //        new []{21,22,23,24,25},
    //    };

    //    new Solution().Rotate(input);


    //}

    //static void Print(int[][] input)
    //{
    //    for (int i = 0; i < input.Length; i++)
    //    {
    //        for (int j = 0; j < input[i].Length; j++)
    //        {
    //            Console.Write(string.Format("{0,3}", input[i][j]));
    //        }
    //        Console.WriteLine();
    //    }
    //}
}
