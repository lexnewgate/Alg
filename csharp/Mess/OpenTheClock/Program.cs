using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
         HashSet<string>deadSet=new HashSet<string>();
         for (int i = 0; i < deadends.Length; i++)
         {
             deadSet.Add(deadends[i]);
         }

         string start = "0000";
         if (deadSet.Contains(start))
         {
             return -1;
         }

         HashSet<string>visited=new HashSet<string>();
         visited.Add(start);
         Queue<string> queue=new Queue<string>();
         Queue<string> queue1=new Queue<string>();
         queue.Enqueue(start);
         int step = 0;
         StringBuilder stringBuilder=new StringBuilder(4);

         while (queue.Count!=0)
         {
             while (queue.Count!=0)
             {
                 var code = queue.Dequeue();
                 if (code==target)
                 {
                     return step;
                 }


                 for (int i = 0; i < 4; i++)
                 {
                     for (int j = 0; j < 2; j++)
                     {
                         stringBuilder.Clear();
                         stringBuilder.Append(code);
                         char tc = code[i];
                         int newtc= (tc + ((j == 0) ? -1 : 1));
                         newtc = (newtc =='0'-1) ? '9' : (newtc == '9'+1) ? '0' : newtc;
                         tc = (char)newtc;
                         stringBuilder[i] = tc;
                         var newCode = stringBuilder.ToString();
                         if (!deadSet.Contains(newCode) &&
                             !visited.Contains(newCode))
                         {
                             visited.Add(newCode);
                             queue1.Enqueue(newCode);

                         }

                     } 
                 }
             }

             var tempQ = queue;
             queue = queue1;
             queue1 = tempQ;
             step++;
         }

         return -1;

    }

    static void Main(string[] args)
    {
        //deadends = ["8888"], target = "0009"

        Console.WriteLine(new Solution().OpenLock(new []{"8888"},"0009"));

        int a = 1, b = 2;

        new List<(int,int)>().Add((a,b));

    }
}
