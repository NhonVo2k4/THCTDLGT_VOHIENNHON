using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_DSLKDon
{
    internal class MyList
    {
        #region Properties

        internal IntNode? First { get; set; }
        internal IntNode? Last { get; set; }
        public int Count { get; set; }

        #endregion

        #region Contructor

        public MyList()
        {
            First = Last = null;
            Count = 0;
        }

        #endregion

        #region Get : Các hàm lấy giá trị

        // Trả về vị trí giá trị lớn nhất trong danh sách
        public IntNode GetMax()
        {
            IntNode? pM = First;
            IntNode? p = First;

            while (p != null)
            {
                if (pM.Data < p.Data)
                    pM = p;
                p = p.Next;
            }
            return pM;
        }

        // Trả về vị trí giá trị nhỏ nhất trong sanh sách
        public IntNode GetMin()
        {
            IntNode? pM = First;
            IntNode? p = First;

            while (p != null)
            {
                if (pM.Data > p.Data)
                    pM = p;
                p = p.Next;
            }
            return pM;
        }
        
        // Trả về đanh sách giá trị chẳn trong danh sách
        public MyList GetEvenNumberList()
        {
            MyList list = new MyList();
            IntNode p = First;
            while (p != null)
            {
                if (p.Data % 2 == 0) list.AddLast(new IntNode(p.Data));
                p = p.Next;
            }
            return list;
        }

        // Trả về danh sách giá trị lẻ trong danh sách
        public MyList GetOddNumbersList()
        {
            MyList list = new MyList();
            IntNode? p = First;
            while (p != null) 
            {
                if (p.Data % 2 != 0) list.AddLast(new IntNode(p.Data));
                p = p.Next;
            }
            return list;
        }

        #endregion

        #region Methods 

        #region Input 

        //Nhập giá trị vào danh sách liên kết
        public void Input()
        {
            Console.InputEncoding = Encoding.UTF8; // thiết lập đầu vào nhận ngôn ngữ tiếng việt
            Console.OutputEncoding = Encoding.UTF8; // thiết lập đầu ra nhận ngôn ngữ tiếng việt

            // Lặp lại cho đến khi người dùng nhập 0
            while (true)
            {
                int x;// khoier tạo biến lưu trx giá trị lưu vào danh sách
               
                Console.Write("Mời nhập giá trị (nhấn 0 nếu muốn thoát): ");  // Hiển thị lời nhắc cho người dùng nhập giá trị
                int.TryParse(Console.ReadLine(), out x); // Chuyển đổi chuỗi nhập thành số nguyên và gán cho x, có trả giá trị true false
                
                if (x == 0) break; // Nếu x là 0, thoát khỏi vòng lặp
                
                IntNode newNode = new IntNode(x); // Tạo một nút mới với giá trị x
               
                AddFirst(newNode); // Thêm nút mới vào đầu danh sách liên kết

                Count++;
            }
        }

        #endregion

        #region OutPut 

        // Xuất toàn bộ giá trị trong danh sách liên kết
        public void Output()
        {
            Console.OutputEncoding = Encoding.UTF8;

            IntNode? p = First; // Khai báo một biến p để duyệt qua danh sách liên kết

            if (p == null) Console.WriteLine("Mảng không có giá trị"); // Kiểm tra nếu danh sách liên kết rỗng

            // Lặp lại cho đến khi hết danh sách
            while (p != null)
            {
                Console.Write($"{p.Data} "); // Xuất giá trị của nút hiện tại
                
                p = p.Next; // Chuyển sang nút kế tiếp
                Count--;
            }
        }

        #endregion

        #region Check

        bool IsEmpty => First == null;// Kiểm tra xem trong danh sách có giá trị nào chưa. Nếu chưa thì true và ngược lại

        #endregion

        #region Add 

        //Giá trị được thêm vào từ đầu danh sách
        public void AddFirst(IntNode newNode)
        {
            if (IsEmpty) First = Last = newNode;
            else
            {
                newNode.Next = First;
                First = newNode;
            }
            Count++;
        }

        //Giá trị được thêm vào cuối danh sách
        public void AddLast(IntNode newNode)
        {
            if (IsEmpty)
                First = Last = newNode;
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            Count++;
        }

        #endregion

        #region Remove : Hàm xoá

        public void RemoveNodeByIndex(int indexNode)
        {
            IntNode pDel = FindNodeByIndex(indexNode);
            if(pDel == null)
            {
                Console.WriteLine("Sai vị trí xoá thất bại");
                return;
            }
            DeleteNode(pDel);
            Console.WriteLine("Xoá thành công");
            Count--;
        }

        public void RemoveNodeByValue(int valueNode)
        {
            IntNode pDel = FindNodeByValue(valueNode);
            if (pDel == null)
            {
                Console.WriteLine("Sai vị trí xoá thất bại");
                return;
            }
            DeleteNode(pDel);
            Console.WriteLine("Xoá thành công");
            Count--;
        }

        #endregion

        #region Insert

        #region Simple

        public void InsertAfterNode(IntNode newNode, IntNode p) 
        {
            if (p == Last) AddLast(newNode);
            else
            {
                newNode.Next = p.Next;
                p.Next = newNode;
            }
        }

        public void InsertBeforeNode(IntNode newNode, IntNode p)
        {
            if (p == First) AddLast(newNode);
            else
            {
                IntNode pPre = PreNode(p);
                pPre.Next = newNode;
                newNode.Next = p;
            }
        }

        #endregion

        public void InsertValueAfterMin(int valueInsert)
        {
            IntNode valueMin = GetMin();

            IntNode newNode = new IntNode(valueInsert);

            InsertAfterNode(newNode, valueMin);
        }

        public void InsertValueBeforeMax(int valueInsert)
        {
            IntNode valueMin = GetMax();

            IntNode newNode = new IntNode(valueInsert);

            InsertBeforeNode(newNode, valueMin);
        }

        public void InsertValueAfterValue(int valueInsert, int value)
        {
            IntNode valueMin = FindNodeByValue(value);

            if (valueMin == null)
            {
                Console.WriteLine("Giá trị node sai, không thể chèn");
                return;
            }

            IntNode newNode = new IntNode(valueInsert);

            InsertAfterNode(newNode, valueMin);
        }

        public void InsertValueBeforeValue(int valueInsert, int value)
        {
            IntNode valueMin = FindNodeByValue(value);

            if (valueMin == null)
            {
                Console.WriteLine("Giá trị node sai, không thể chèn");
                return;
            }

            IntNode newNode = new IntNode(valueInsert);

            InsertBeforeNode(newNode, valueMin);
        }

        public void InsertValueByIndex(int index, int valueInsert)
        {
            IntNode pointNode = FindNodeByIndex(index);

            if(pointNode == null)
            {
                Console.WriteLine("Vị trí không chính xác, không chèn giá trị được");
                return;
            }
            
            IntNode newNode = new IntNode(valueInsert);

            InsertAfterNode(newNode, pointNode);

        }

        #endregion

        #region Sort 

        // Xắp xếp giá trị tăng dần
        public void InterchangeSort()
        {
            for (IntNode? pi = First; pi.Next != null; pi = pi.Next)
                for (IntNode? pj = pi.Next; pj != null; pj = pj.Next)
                    if (pi.Data.CompareTo(pj.Data) > 0)
                        Swap(ref pi, ref pj);
        }

        // Xắp xếp giá trị giảm dàn
        public void SelectionSort()
        {
            IntNode p = First;
            while(p != null)
            {
                IntNode? pM = GetMin();
                Swap(ref pM, ref p);
                p = p.Next;
            }
        }

        #endregion

        #region Find

        // Hàm tìm giá trị trong danh sách liên kết đơn, trả về node cần tìm
        public IntNode FindNodeByValue(int value)
        {
            IntNode? p = First;
            while (p != null)
            {
                if (p.Data == value) return p;
                p = p.Next;
            }
            return p;
        }

        public IntNode FindNodeByIndex(int indexNode)
        {
            int index = 0;
            IntNode? p = First;

            while (index < indexNode && p != null)
            {
                index++;
                p = p.Next;
            } ;

            return p;
        }

        #endregion

        #region Function

        // Trả về một nút trươc nút truyền vào
        public IntNode PreNode(IntNode p)
        {
            if (p == null) return p;
            IntNode? pPre = First;
            while (pPre.Next != p)
                pPre = pPre.Next;
            return pPre;
        }

        // Xoá Node 
        public bool DeleteNode(IntNode p) 
        {
            if (p == null) return false; 
            if (First == Last) 
                First = Last = null; 
            else if (p == Last)
            {
                IntNode pPre = PreNode(p);
                pPre.Next = null; 
                Last = pPre;
            }
            else
            {
                IntNode? pReplace = p.Next;
                p.Data = pReplace.Data;
                p.Next = pReplace.Next;
                p = pReplace; 
            }
            p = null; 
            return true;
        }

        public void RShiftRight()
        {
            int x = Last.Data;
            DeleteNode(Last);
            IntNode newNode = new IntNode(x);
            AddFirst(newNode);
        }

        void Swap(ref IntNode valueFirst, ref IntNode valueSeconds)
        {
            IntNode temp = valueFirst;
            valueFirst = valueSeconds;
            valueSeconds = temp;
        }

        #endregion

        #endregion
    }
}
