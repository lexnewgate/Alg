using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneGraphTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node=new Node(1);

           var cloneNode= new Solution().CloneGraph(node);
            Console.WriteLine(cloneNode.val);
            Console.WriteLine(cloneNode==node);
        }
    }
}
