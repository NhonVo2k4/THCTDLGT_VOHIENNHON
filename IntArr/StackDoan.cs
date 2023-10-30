using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntArray
{
    internal class StackDoan
    {
        internal Node? Top { get; set; }

        public StackDoan()
        {
            Top = null;
        }

        public bool IsEmpty => Top == null;

        public void Push(int valueLeft,int valueRight)
        {
            Node newNode = new Node(valueLeft,valueRight);
            newNode.Next = Top;
            Top = newNode;
        }

        public bool Pop(out int outValueLeft, out int outValueRight)
        {
            if (GetTop(out outValueLeft, out outValueRight) == false) return false;
            Top = Top.Next;
            return true;
        }

        public bool GetTop(out int outValueLeft, out int outValueRight)
        {
            outValueLeft = outValueRight = -1;
            if (IsEmpty) return false;
            outValueLeft = Top.Left;
            outValueRight = Top.Right;
            return true;
        }
    }
}
