using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntArray
{
    internal class Node
    {
        public int Left { get; set; }
        public int Right { get; set; }
        internal Node? Next { get; set; }

        public Node(int left, int right)
        {
            Next = null;
            Right = right;
            Left = left;
        }
    }
}
