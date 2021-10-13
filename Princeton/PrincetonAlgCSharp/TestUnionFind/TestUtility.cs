using System;
using NUnit.Framework;
using UnionFind;

namespace TestUnionFind
{
    internal static class TestUtility
    {
        public static void Test<T>(UFInput.InputType inputType,Func<int,T>creator,int ans) where T: IUnionFind
        {
            var pqList= UFInput.GetPairs(inputType);
            var unionFd = creator(pqList.nodeCount);
            foreach (var (p,q) in pqList.connectedPairs)
            {
                if (unionFd.find(p) == unionFd.find(q))
                {
                    continue;
                }
                unionFd.union(p,q);
                Console.WriteLine(p+" "+q);
            }
            Console.WriteLine(unionFd.count()+" components");
            Assert.True(ans==unionFd.count());
        }
    }
}