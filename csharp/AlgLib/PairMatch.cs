using System;
using System.Collections.Generic;

namespace AlgLib
{
    /// <summary>
    /// 某种闭合是否合法(正确嵌套)
    /// </summary>
    public static class PairMatch
    {
        public static bool IsValid<T>(IList<T> stream, Dictionary<T, T> pairs, Func<T, T, bool> isMatch)
        {
            int count = stream.Count;
            if (count % 2 != 0) //不为偶数
            {
                return false;
            }

            Stack<T> stack = new Stack<T>();
            HashSet<T> closedVals = new HashSet<T>(pairs.Values);
            foreach (var v in stream)
            {
                if (pairs.ContainsKey(v)) //open 
                {
                    stack.Push(v);
                }
                else if (closedVals.Contains(v)) //close
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var top = stack.Pop();
                    if (!isMatch(top, v))
                    {
                        return false;
                    }

                }
                else //invalid val
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }

}
