using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntStack
{
    internal class ArrayStack
    {
        #region Properties Auto 

        public int[] StackArray { get; set; }
        public int StackMax { get; set; }
        public int StackTop { get; set; }

        #endregion

        #region Constructors 

        public ArrayStack(int stackMax = 0)
        {
            StackMax = stackMax;
            StackArray = new int[stackMax];
            StackTop = -1;
        }

        #endregion

        #region Methods

        public bool IsEmpty => StackTop == -1;
        public bool IsFull => StackTop == StackMax - 1;

        public bool Push(int value)
        {
            if (IsFull) return false;
            StackTop++;
            StackArray[StackTop] = value;
            return true;
        }

        public bool Pop(out int outValue)
        {
            if (GetTop(out outValue) == false) return false;
            StackTop--;
            return true;
        }

        public bool GetTop(out int outValue)
        {
            outValue = -1;
            if (IsEmpty) return false;
            outValue = StackArray[StackTop];
            return true;
        }

        #endregion

    }
}
