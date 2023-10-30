using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_SinhVien
{
    internal class SinhVien
    {

        #region Fileds

        string id;
        string name;
        string specialized;
        int birthYear;
        float mediumScore;
        string rank;

        #endregion 

        #region Properties

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        public string Specialized 
        { 
            get => specialized; 
            set => specialized = value; 
        }

        public int BirthYear 
        {
            get => birthYear;
            set => birthYear = SetBirthYear(value); 
        }

        public float MediumScore 
        { 
            get => mediumScore; 
            set => mediumScore = SetMediumScore(value); 
        }

        public string Rank
        {
            get => rank; 
        }

        #endregion  

        #region Sets

        //Hàm trả về xếp loại học sinh trên điểm trung bình.
        private void SetRank()
        {
            if(MediumScore < 5)
            {
                rank = "Kém";
                return;
            }    
            else if(MediumScore < 7)
            {
                rank = "Trung Bình";
                return;
            }
            else if(MediumScore < 8)
            {
                rank = "Khá";
                return;
            }
            rank = "Giỏi";
        }

        public int SetBirthYear(int valueBirthYear)
        {
            while (!IsValidBirthYear(valueBirthYear))
            {
                Console.WriteLine("Năm sinh sinh viên không hợp lệ.(17 -> 70)");
                Console.Write("Mời nhập lại tuổi sinh viên : ");
                valueBirthYear = int.Parse(Console.ReadLine());
            }   
            return valueBirthYear;
        }

        public float SetMediumScore(float valueMediumScore)
        {
            while (!IsValidMediumScore(valueMediumScore))
            {
                Console.WriteLine("Điểm số trung bình không hợp lệ.(0 -> 10)");
                Console.Write("Mời nhập lại điểm trung bình : ");
                valueMediumScore = float.Parse(Console.ReadLine());
            }
            SetRank();
            return valueMediumScore;
        }

        #endregion

        #region Constructors

        // Default
        public SinhVien()
        {

        }

        // Parameter
        public SinhVien(string id, string name, string specialized, int birthyear, float mediumScore)
        {
            Id = id;
            Name = name;
            Specialized = specialized;
            BirthYear = birthyear;
            MediumScore = mediumScore;
            SetRank();
        }

        // Coppy 
        public SinhVien(SinhVien student)
        {
            Id = student.Id;
            Name = student.Name;
            Specialized = student.Specialized;
            BirthYear = student.BirthYear;
            MediumScore = student.MediumScore;
        }

        #endregion

        #region Methods

        #region Checks

        //Kiểm tra Năm sinh. Điều kiện tuổi của năm sinh từ 17 đến 70
        bool IsValidBirthYear(int birthYear)
        {
            int age = DateTime.Now.Year - birthYear;
            return (age >= 17 && age <= 70) ? true : false;
        }

        // Kiểm tra Điểm trung bình. Điều kiện 0 đến 10.
        Func<float,bool> IsValidMediumScore = mediumScore => (mediumScore >= 0 || mediumScore <= 10);

        #endregion

        #region Output

        public void Output()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Thông tin sinh viên");
            Console.WriteLine($"Mã số sinh viên : {Id}");
            Console.WriteLine($"Họ và Tên sinh viên : {Name}");
            Console.WriteLine($"Chuyên ngành : {Specialized}");
            Console.WriteLine($"Năm sinh : {BirthYear}");
            Console.WriteLine($"Điểm trung bình : {MediumScore}");
            Console.WriteLine($"Xếp loại : {Rank}");
        }

        #endregion

        #region Input

        public void Input()
        {
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Mời nhập thông tin sinh viên");

            Console.Write("Nhập mã sinh viên : ");
            Id = Console.ReadLine();

            Console.Write("Nhập Họ và Tên sinh viên : ");
            Name = Console.ReadLine();

            Console.Write("Nhập Chuyên ngành: ");
            Specialized = Console.ReadLine();

            Console.Write("Nhập Năm sinh : ");
            BirthYear = int.Parse(Console.ReadLine());

            Console.Write("Nhập Điểm trung bình : ");
            MediumScore = float.Parse(Console.ReadLine());
        }

        #endregion

        #endregion

    }
}
