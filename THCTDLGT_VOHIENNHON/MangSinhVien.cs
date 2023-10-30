using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSDL_SinhVien
{
    internal class MangSinhVien
    {
        // Properties Auto
        internal SinhVien[] Student { get; set; }

        // Default Contructors
        public MangSinhVien()
        {
        }

        public void Input()
        {
            Console.InputEncoding = Encoding.Unicode;

            CreateArrayStudent();// Tạo mảng sinh viên

            for (int i = 0; i < Student.Length; i++) // Duyệt và input giá trị
            {
                Console.WriteLine($"Mời nhập thông tin sinh viên thứ {i + 1}");

                Console.Write("Nhập mã sinh viên : ");
                ContainsId(Console.ReadLine(), i);

                Console.Write("Nhập Họ và Tên sinh viên : ");
                Student[i].Name = Console.ReadLine();

                Console.Write("Nhập Chuyên ngành: ");
                Student[i].Specialized = Console.ReadLine();

                Console.Write("Nhập Năm sinh : ");
                Student[i].BirthYear = int.Parse(Console.ReadLine());

                Console.Write("Nhập Điểm trung bình : ");
                Student[i].MediumScore = float.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            SortStudentsByName(); // Hàm sắp xếp

        }

        public void Output()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Thông tin mảng sinh viên :");

            for (int i = 0; i < Student.Length; i++)
                Console.WriteLine($"|{Student[i].Id,8} |{Student[i].Name,8} |{Student[i].Specialized,8} |{Student[i].BirthYear,8} |{Student[i].MediumScore,8} |{Student[i].Rank,8}");
        }

        // Hàm tạo sinh viên cho mảng. Số lượng sinh viên được nhập vào.
        void CreateArrayStudent()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Mời nhập số lượng sinh viên trong mảng: ");
            int lengthArrayStudent = int.Parse(Console.ReadLine());

            Student = new SinhVien[lengthArrayStudent];

            for (int i = 0; lengthArrayStudent > i; i++)
                Student[i] = new SinhVien();
        }

        // Hàm kiểm tra ID có trùng không
        void ContainsId(string valueId, int indexId)
        {
            for (int indexCheck = 0; indexCheck < indexId; indexCheck++)
            {
                while (Student[indexCheck].Id.CompareTo(valueId) == 0)
                {
                    Console.Write("Id sinh viên đã tồn tại mời nhập lại :");
                    valueId = Console.ReadLine();
                }
            }
            Student[indexId].Id = valueId;
        }

        // SortStudentsByName - Hàm sắp xếp sinh viên theo tên tăng dần và dung InterchangeSort để sắp xếp
        void SortStudentsByName()
        {
            // Lặp qua từng phần tử trong mảng
            for (int i = 0; i < Student.Length; i++)
                // Lặp qua các phần tử còn lại sau phần tử hiện tại
                for (int j = i + 1; j < Student.Length; j++)
                    // Nếu phần tử hiện tại lớn hơn phần tử kế tiếp
                    if (Student[i].Name.CompareTo(Student[j].Name) > 0)
                        // Hoán đổi vị trí hai phần tử
                        Swap(ref Student[i], ref Student[j]);
        }
        //Hàm hoán vị
        void Swap(ref SinhVien valueFirst, ref SinhVien valueSeconds)
        {
            SinhVien temp = valueFirst;
            valueFirst = valueSeconds;
            valueSeconds = temp;
        }

    }
}
