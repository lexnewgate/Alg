using System.Collections;
using System.Collections.Generic;

public class Solution
{
    private void Check(int cr, int cc,int r,int c, HashSet<int>visited,int[][]image,int newColor,Stack<(int r,int c)>stack,int startColor)
    {
        if ((cr >= 0) && (cr < r) && (cc >= 0) && (cc < c)&&image[cr][cc]==startColor && (!visited.Contains(cr * c + cc)))
        {
                visited.Add(cr * c + cc);
                image[cr][cc] = newColor;
                stack.Push((cr,cc));
        }
    }
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        int row = image.Length;
        int col = image[0].Length;
        Stack<(int r, int c)> stack = new Stack<(int r, int c)>();
        HashSet<int> visited = new HashSet<int>();
        stack.Push((sr, sc));
        visited.Add((sr*col+sc));
        int startColor = image[sr][sc];
        image[sr][sc] = newColor;

        int newr = 0;
        int newc = 0;
        while (stack.Count != 0)
        {
            var (r, c) = stack.Pop();
            (newr, newc) = (r + 1, c);
            Check(newr,newc,row,col,visited,image,newColor,stack,startColor);
            (newr, newc) = (r - 1, c);
            Check(newr,newc,row,col,visited,image,newColor,stack,startColor);
            (newr, newc) = (r, c + 1);
            Check(newr,newc,row,col,visited,image,newColor,stack,startColor);
            (newr, newc) = (r, c - 1);
            Check(newr,newc,row,col,visited,image,newColor,stack,startColor);
        }

        return image;
    }
}
