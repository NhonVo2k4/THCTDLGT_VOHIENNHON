using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntQueue
{
    internal class ArrayQueue
    {
        public int[] Queue { get; set; }
        public int Font { get; set; }
        public int Rear { get; set; }
        public int Max { get; set; }
        public int Cout { get; set; }

        public ArrayQueue(int max = 0)
        {
            Max = max;
            Queue = new int[max];
            Cout = 0;
            Font = 0;
            Rear = -1;
        }

        public bool IsEmpty => Cout == 0;

        public bool IsFull => Cout == Max;

        public bool EnQueue(int value)
        {
            if(IsFull) return false;
            Rear++;
            if(Rear % Max == 0) Rear = 0;
            Queue[Rear] = value;
            Cout++;
            return true;
        }

        public bool DeQueue(out int outValue)
        {
            bool check = GetTop(out outValue);
            if(check) return false;
            //Xoá
            Font++;
            if(Font % Max == 0)  Font = 0;
            Cout--;
            return true;
        }

        public bool GetTop(out int topValue)
        {
            topValue = 0;
            if(IsEmpty) return false;
            topValue = Queue[Font];
            return true;
        }

    }
}
