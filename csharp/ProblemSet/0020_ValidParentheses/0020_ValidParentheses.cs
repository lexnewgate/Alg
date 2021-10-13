using System;
using System.Collections.Generic;

/// <summary>
/// 这道题不能使用简单的双指针去做,比如(){}就会破坏原有组合.
/// #tag: stack
/// #ltd
/// </summary>
public class Solution {
    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0)
        {
            return false;
        }
        
        Dictionary<char, char> forwardPairDict = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };
        
        Dictionary<char, char> backPairDict = new Dictionary<char, char>()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };


        Stack<char> stack = new Stack<char>();
        
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (backPairDict.ContainsKey(c))
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char cpair = stack.Pop();
                if (cpair != backPairDict[c])
                {
                    return false;
                }
            }
            else if(forwardPairDict.ContainsKey(c))
            {
                stack.Push(c);
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().IsValid("{}"));
        Console.WriteLine(new Solution().IsValid("{ssss}"));
        Console.WriteLine(new Solution().IsValid("(ssss}"));
        Console.WriteLine(new Solution().IsValid(""));
        Console.WriteLine(new Solution().IsValid("({ss}a)"));
        Console.WriteLine(new Solution().IsValid("({s)s}a)"));
        Console.WriteLine(new Solution().IsValid("{}()[]{}"));
    }
}