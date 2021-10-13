using System.IO;
using System.Text;

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0|| strs[0]==null || strs[0].Length==0)
        {
            return "";
        }

        StringBuilder sb=new StringBuilder();

        int len = 0;
        string first = strs[0];
        for (int i = 0; i < first.Length; i++)
        {
            char c = first[i];
            int j = 1;
            for (; j < strs.Length; j++)
            {
                if (strs[j].Length<=i||strs[j][i]!=c)
                {
                    goto END;
                }
            }

            if (j == strs.Length)
            {
                sb.Append(c);
            }
        }

       END: 

        return sb.ToString();

    }
}
