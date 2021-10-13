public class Solution
{
    public bool LessThanMid(int target,int mid)
    {
        //target>=0 如果mid为0,则target>=mid
        if (mid == 0) return false;

        return target /mid<mid;
    }

    public bool MoreThanMid(int target,int mid)
    {
        //target>=0 如果mid为0,则target>=mid. 
        //只要不相等则一定大于
        if (mid == 0) return target !=0;
        return target / (mid+1) >= (mid+1);
    }

    /// <summary>
    ///  虚拟数组0,1,2,...,target
    /// </summary>
    public int BinarySearch(int target)
    {

        int l = 0;
        int h = target;
        int mid;

        while (l <= h)
        {
            mid = l+((h-l)>>1); //prevent overflow

            if (MoreThanMid(target,mid))
            {
                l = mid + 1;
            }

            else if (LessThanMid(target,mid))
            {
                h = mid - 1;
            }
            else //不大也不小,代表找到
            {
                return mid;
            }

        }

        return -1;
    }
    public int MySqrt(int x)
    {
        return BinarySearch(x);
    }

}
