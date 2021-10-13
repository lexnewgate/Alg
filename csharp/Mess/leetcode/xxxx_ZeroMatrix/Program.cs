using System.Collections.Generic;

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return;
        }

        int rowLength = matrix.Length;
        int colLength = matrix[0].Length;

        HashSet<int> zeroRows = new HashSet<int>();
        HashSet<int> zeroCols = new HashSet<int>();

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                if (matrix[i][j] == 0)
                {
                    zeroRows.Add(i);
                    zeroCols.Add(j);
                }
            }
        }

        foreach (var zeroCol in zeroCols)
        {
            //zero col
            for (int j = 0; j < rowLength; j++)
            {
                matrix[j][zeroCol] = 0;
            }
        }

        foreach (var zeroRow in zeroRows)
        {
            //zero row
            for (int k = 0; k < colLength; k++)
            {
                matrix[zeroRow][k] = 0;
            }
        }
    }
}