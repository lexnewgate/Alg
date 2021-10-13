/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */


using System;

public class VersionControl
{
   protected bool IsBadVersion(int version)
    {
        throw new NotImplementedException();
    }
}


public class Solution : VersionControl
{

    /// <summary>
    ///  虚拟数组0,1,2,...,target
    /// </summary>
    public int BinarySearch(int l,int h)
    {
        int mid;

        while (l < h)
        {
            mid = l + ((h - l) >> 1); //prevent overflow

            if (!IsBadVersion(mid))
            {
                l = mid + 1;
            }

            else if (IsBadVersion(mid))
            {
                h = mid ;
            }
            else //不大也不小,代表找到
            {
                return mid;
            }

        }

        return l;

    }


    public int FirstBadVersion(int n)
    {
        return  BinarySearch(1,n);
    }
}