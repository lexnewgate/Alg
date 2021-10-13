using System.Collections.Generic;
public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> operands = new Stack<int>();
        foreach (string token in tokens)
        {
            if (token == "+")
            {
                var sec = operands.Pop();
                var first = operands.Pop();
                operands.Push(first + sec);
            }
            else if (token == "-")
            {
                var sec = operands.Pop();
                var first = operands.Pop();
                operands.Push(first - sec);
            }
            else if (token == "*")
            {
                var sec = operands.Pop();
                var first = operands.Pop();
                operands.Push(first * sec);
            }
            else if (token == "/")
            {
                var sec = operands.Pop();
                var first = operands.Pop();
                operands.Push(first / sec);
            }
            else
            {
                operands.Push(int.Parse(token));
            }
        }
        return operands.Pop();
    }
}
