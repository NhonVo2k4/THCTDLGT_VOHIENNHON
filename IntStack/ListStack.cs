using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntStack
{
    internal class ListStack
    {
        internal Node? Top { get; set; }

        public ListStack()
        {
            Top = null;
        }

        public bool IsEmpty => Top == null;

        public void Push(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = Top;
            Top = newNode;
        }

        public bool Pop(out int outValue)
        {
            if (GetTop(out outValue) == false) return false;
            Top = Top.Next;
            return true;
        }

        public bool GetTop(out int outValue)
        {
            outValue = -1;
            if (IsEmpty) return false;
            outValue = Top.Data;
            return true;
        }

    }
}
