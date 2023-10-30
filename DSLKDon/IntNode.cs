using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_DSLKDon
{
    internal class IntNode
    {
        // Properties
        public int Data { get; set; }
        internal IntNode? Next { get; set; }

        #region Contructor

        public IntNode(int data)
        {
            Data = data;
            Next = null;
        }

        public IntNode()
        {
            Data = 0;
            Next = null;
        }

        public IntNode(int data, IntNode next)
        {
            Data = data;
            Next = next;
        }

        #endregion
    }
}
