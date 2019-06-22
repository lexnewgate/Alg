using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var a=new int[1000];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = i; 
            }

            Console.WriteLine(BinarySearch(a,0));
            Console.WriteLine(BinarySearch(a,999));
            Console.WriteLine(BinarySearch(a,1000));
            Console.WriteLine(BinarySearch(a,-1));

        }

        static (bool find,int index) BinarySearch(int []a,int b)
        {
            int start = 0;
            int end = a.Length-1;
            do
            {
                int selectIndex = (start + end) / 2;
                if (a[selectIndex] == b)
                {
                    return (true,selectIndex);
                }

                if (a[selectIndex] > b)
                {
                    end = selectIndex-1;
                }
                else
                {
                    start = selectIndex+1;
                }
            } while (start<=end);

            return (false, 0);
        }
    }
}
