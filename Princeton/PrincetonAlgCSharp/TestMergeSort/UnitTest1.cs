using System;
using NUnit.Framework;
using Sort;

namespace TestMergeSort
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            int[] arr = new[] {5, 4, 1, 8,20, 7, 2, 6, 3};

            int[] sortedArr = MergeSort.Sort(arr);

            for (int i = 0; i < sortedArr.Length; i++)
            {
                Console.WriteLine(sortedArr[i]);
            }
        }
    }
}