using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string DecodeString(string s)
    {
        StringBuilder ret = new StringBuilder();
        StringBuilder expendStrBuilder = new StringBuilder();
        StringBuilder tempStrBuilder=new StringBuilder();
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < s.Length;)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                int openBracket = s.IndexOf("[", i);
                var countStr = s.Substring(i, openBracket - i);
                stack.Push(countStr);
                i = openBracket + 1;
            }
            else
            {
                if (s[i] == ']')
                {
                    int count = 0;
                    var top = stack.Pop();
                    tempStrBuilder.Clear();
                    expendStrBuilder.Clear();
                    while (!int.TryParse(top,out count))
                    {
                        tempStrBuilder.Insert(0, top);
                        top = stack.Pop();
                    }
                    stack.Push(expendStrBuilder.Insert(0,tempStrBuilder.ToString(),count).ToString());

                }
                else
                {
                    stack.Push(s[i].ToString());
                }
                i++;
            }
        }

        foreach (var ele in stack)
        {
            ret.Insert(0, ele);
        }

        return ret.ToString();

    }


    static void Main()
    {
        Console.WriteLine(new Solution().DecodeString("3[a]2[bc]"));
    }
}
