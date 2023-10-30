using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntStack
{
    internal class Node
    {
        public int Data { get; set; }
        internal Node? Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
}
