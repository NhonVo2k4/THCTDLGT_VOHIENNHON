using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntQueue
{
    internal class ListQueue
    {
        internal Node? Font { get; set; }
        internal Node? Rear { get; set; }
        internal int Cout { get; set; }

        public ListQueue()
        {
            Font = Rear = null;
            Cout = 0;
        }

        public bool IsEmpty => Font == null;

        public void EnQueue(int value)
        {
            Node newNode = new Node(value);
            if(IsEmpty)
            {
                Font= Rear = newNode;
                return;
            }
            Rear.Next = newNode;
            Rear = newNode;
            Cout++;
        }

        public bool DeQueue(out int outValue)
        {
            if (!GetTop(out outValue)) return false;
            //Xoá
            Font = Font.Next;
            Cout--;
            return true;
        }

        public bool GetTop(out int topValue)
        {
            topValue = 0;
            if (IsEmpty) return false;
            topValue = Font.Data;
            return true;
        }

    }
}
