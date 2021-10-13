using System;
using System.Linq;
using NUnit.Framework;
using UnionFind;

namespace TestUnionFind
{
    public class TestQuickUnionPathCompression
    {
        
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void TestTinyInput()
        {
            TestUtility.Test(UFInput.InputType.Tiny,(n)=>new QuickUnionPathCompressionUF(n),2);
        }
        
        
        [Test]
        public void TestMediumInput()
        {
            TestUtility.Test(UFInput.InputType.Medium,(n)=>new QuickUnionPathCompressionUF(n),3);
        }
        
        [Test,Timeout(1000*60)]
        public void TestLargeInput()
        {
            TestUtility.Test(UFInput.InputType.Large,(n)=>new QuickUnionPathCompressionUF(n),6);
        }
    }
}