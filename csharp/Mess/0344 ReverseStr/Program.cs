public class Solution
{
    public void ReverseString(char[] s)
    {
        ReverseStr(s,0,s.Length-1);
    }

    private void ReverseStr(char[] s,int start,int end)
    {
        if (start >= end)
        {
            return;
        }

        char temp = s[start];
        s[start] = s[end];
        s[end] = temp;

        ReverseStr(s,start+1,end-1);

    }
}
