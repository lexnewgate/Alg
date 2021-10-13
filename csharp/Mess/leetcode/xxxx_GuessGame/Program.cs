/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */

using System;

public class GuessGame
{
    protected int guess(int num)
    {
        return 0;
    }
}

public class Solution : GuessGame
{

    public int BinarySearch(int lo,int hi, Func<int,int>compare)
    {

        int mid;

        while (lo <= hi)
        {
            mid = lo + ((hi - lo) >> 1); //prevent overflow

            if (compare(mid)==1)
            {
                lo = mid + 1;
            }

            else if (compare(mid)==-1)
            {
                hi = mid - 1;
            }
            else //不大也不小,代表找到
            {
                return mid;
            }

        }

        return -1;
    }

    public int GuessNumber(int n)
    {
        
        return BinarySearch(1,n,guess);
    }
}