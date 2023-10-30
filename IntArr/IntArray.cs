using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_IntArray
{
    internal class IntArray
    {
        #region Properties

        // Properties Auto
        public int[] Arr { get; set; }

        // Properties index get set
        // Thuộc tính này cho phép truy cập hoặc thay đổi giá trị của một phần tử trong mảng bằng chỉ số
        public int this[int index]
        {
            // Phương thức get trả về giá trị của phần tử ở vị trí index trong mảng
            get => Arr[index];
            // Phương thức set gán giá trị của phần tử ở vị trí index trong mảng bằng giá trị được cung cấp
            set => Arr[index] = value;
        }

        #endregion

        #region Sets

        void SetLengthArr(ref int lengthArray)
        {
            while (!CheckLengthArray(lengthArray))
            {
                Console.WriteLine("Bạn nhập giới hạn mảng không đúng.(0 < x < 1000000)");
                Console.Write("Vui lòng nhập lại : ");
                lengthArray = int.Parse(Console.ReadLine());
            }
        }

        #endregion

        #region Contructor

        //Default
        public IntArray()
        {

        }   

        //Parameter input numberLength
        public IntArray(int lengthArray)
        {
            // Gọi hàm SetLengthArr để cập nhật giá trị độ dài mảng nằm trong phạm vi quy định
            SetLengthArr(ref lengthArray);

            // Khởi tạo mảng với độ dài đã cho
            Arr = new int[lengthArray];

            // Khởi tạo một đối tượng kiểu Random để sinh số ngẫu nhiên
            Random valueRandomArr = new Random();

            // Lặp qua từng phần tử trong mảng
            for (int i = 0; i < lengthArray; i++)
                // Gán giá trị của phần tử bằng một số ngẫu nhiên trong khoảng từ 1 đến 200
                Arr[i] = valueRandomArr.Next(1, 200);
        }

        //Parameter input array
        public IntArray(int[] arr, int indexStart = -1, int indexEnd = -1)
        {
            // Nếu tham số indexStart bằng -1, gán nó bằng 0
            if (indexStart == -1) indexStart = 0;
            // Nếu tham số indexEnd bằng -1, gán nó bằng độ dài mảng nguồn trừ 1
            if (indexEnd == -1) indexEnd = arr.Length - 1;

            // Kiểm tra xem các tham số indexStart và indexEnd có nằm trong phạm vi của mảng nguồn hay không
            // Nếu không, điều chỉnh chúng để nằm trong khoảng từ 0 đến độ dài mảng nguồn trừ 1
            indexStart = Math.Max(0, Math.Min(arr.Length - 1, indexStart));
            indexEnd = Math.Max(0, Math.Min(arr.Length - 1, indexEnd));

            // Tính độ dài của mảng đích bằng cách trừ chỉ số kết thúc cho chỉ số bắt đầu cộng 1
            int length = indexEnd - indexStart + 1;

            // Khởi tạo mảng đích với độ dài đã tính
            Arr = new int[length];


            // Sao chép các phần tử từ mảng nguồn sang mảng đích, bắt đầu từ vị trí indexStart đến vị trí indexEnd
            for(int i = 0; indexEnd > indexStart; i++, indexStart++)
                Arr[i] = arr[indexStart];

        }

        //Coppy
        public IntArray(IntArray obj)
        {
            Arr = obj.Arr;
        }

        #endregion

        #region Methods

        #region Input

        // Đây là một hàm nhập vào các giá trị cho mảng
        // Hàm có hai tham số, là độ dài mảng và kiểu nhập liệu
        public void Input(int lengthArr = 0, int styleInput = 0)
        {
            // Nếu tham số độ dài mảng bằng 0, tức là không có truyền vào
            if (lengthArr == 0)
                // Đọc độ dài mảng từ bàn phím và chuyển sang kiểu số nguyên
                // Nếu giá trị nhập vào không phải là số nguyên, in ra một chuỗi thông báo lỗi và gọi lại hàm Input()
                if (!int.TryParse(Console.ReadLine(), out lengthArr))
                {
                    Console.WriteLine("Giá trị bạn nhập không phải là số nguyên. Vui lòng nhập lại.");
                    Input();
                    return;
                }

            // Gọi hàm SetLengthArr để cập nhật giá trị độ dài mảng nằm trong phạm vi quy định
            SetLengthArr(ref lengthArr);

            // Khởi tạo mảng với độ dài đã cho
            Arr = new int[lengthArr];

            // Gọi hàm HandleStyleInput để xử lý kiểu giá trị của mảng được nhập vào
            HandleStyleInput(styleInput);

            // In ra một dòng mới cách biệt với các lệnh khác trên màn hình
            Console.WriteLine();
        }

        // Đây là một hàm xử lý kiểu giá trị được nhập vào mảng
        // Hàm có một tham số, là kiểu nhập liệu
        void HandleStyleInput(int handlesData)
        {
            // Sử dụng cấu trúc switch để xử lý các trường hợp khác nhau của kiểu nhập liệu
            switch (handlesData)
            {
                // Trường hợp 0: Nhập bình thường
                case 0:
                    // Gọi hàm xử lý nhập giá trị bình thường
                    InputNormal();
                    // Kết thúc hàm
                    return;

                // Trường hợp 1: Nhập tăng dần
                case 1:
                    // Gọi hàm xử lý nhập giá trị tăng dần
                    InputAscending();
                    // Kết thúc hàm
                    return;
                // Trường hợp mặc định: In ra một chuỗi thông báo lỗi và gọi lại hàm Input() với kiểu nhập liệu bằng 0
                default:
                    Console.WriteLine("Kiểu nhập liệu không hợp lệ. Vui lòng chọn lại.");
                    Input(Arr.Length, 0);
                    break;
            }
        }

        // Đây là một hàm xử lý kiểu nhập liệu bình thường
        public void InputNormal()
        {
            // In ra một chuỗi thông báo
            Console.WriteLine("Mời nhập giá trị cho mảng");
            // Lặp qua từng phần tử trong mảng
            for (int index = 0; index < Arr.Length; index++)
            {
                // In ra một chuỗi thông báo với chỉ số của phần tử
                Console.Write($"Giá trị thứ {index} : ");
                // Đọc giá trị từ bàn phím và chuyển sang kiểu số nguyên
                // Nếu giá trị nhập vào không phải là số nguyên, in ra một chuỗi thông báo lỗi và gọi lại hàm InputNormal()
                if (!int.TryParse(Console.ReadLine(), out Arr[index]))
                {
                    Console.WriteLine("Giá trị bạn nhập không phải là số nguyên. Vui lòng nhập lại.");
                    InputNormal();
                    return;
                }
            }
        }

        // Đây là một hàm xử lý kiểu nhập liệu tăng dần
        public void InputAscending()
        {
            // In ra một chuỗi thông báo
            Console.WriteLine("Mời nhập giá trị cho mảng");

            // Lặp qua từng phần tử trong mảng
            for (int index = 0; index < Arr.Length; index++)
            {
                // In ra một chuỗi thông báo với chỉ số của phần tử
                Console.Write($"Giá trị thứ {index} : ");
                // Đọc giá trị từ bàn phím và chuyển sang kiểu số nguyên
                // Nếu giá trị nhập vào không phải là số nguyên, in ra một chuỗi thông báo lỗi và gọi lại hàm InputAscending()
                if (!int.TryParse(Console.ReadLine(), out Arr[index]))
                {
                    Console.WriteLine("Giá trị bạn nhập không phải là số nguyên. Vui lòng nhập lại.");
                    InputAscending();
                    return;
                }
                // Nếu giá trị vừa nhập nhỏ hơn giá trị trước đó, in ra một chuỗi thông báo yêu cầu nhập lại giá trị lớn hơn
                while (index > 0 && Arr[index] < Arr[index - 1])
                {
                    Console.Write("Giá trị bạn vừa nhập nhỏ hơn giá trị trước.\nVui lòng nhập lại giá trị lớn hơn : ");
                    // Đọc lại giá trị từ bàn phím và chuyển sang kiểu số nguyên
                    // Nếu giá trị nhập vào không phải là số nguyên, in ra một chuỗi thông báo lỗi và gọi lại hàm InputAscending()
                    if (!int.TryParse(Console.ReadLine(), out Arr[index]))
                    {
                        Console.WriteLine("Giá trị bạn nhập không phải là số nguyên. Vui lòng nhập lại.");
                        InputAscending();
                        return;
                    }
                }
            }
        }

        #endregion

        #region Output

        // Đây là một hàm xuất ra các giá trị trong mảng lên màn hình
        public void Output()
        {
            // In ra một chuỗi thông báo
            Console.Write("Giá trị trong mảng là : ");
            // Lặp qua từng phần tử trong mảng
            foreach (int data in Arr)
                // In ra giá trị của phần tử, cách nhau bởi 5 khoảng trắng
                Console.Write($"{data,5} ");
            // In ra một dòng mới cách biệt với các lệnh khác trên màn hình
            Console.WriteLine();
        }

        #endregion

        #region Searchs

        // Đây là một hàm tìm kiếm một giá trị trong một mảng bằng phương pháp tìm kiếm tuyến tính
        // Hàm trả về chỉ số của phần tử có giá trị bằng giá trị cần tìm, hoặc -1 nếu không tìm thấy
        public int LinearSearch(int valueSearch)
        {
            // Lặp qua từng phần tử trong mảng
            for (int index = 0; index < Arr.Length; index++)
                // Nếu phần tử ở vị trí hiện tại có giá trị bằng giá trị cần tìm, trả về index
                if (Arr[index] == valueSearch) return index;
            // Nếu không tìm thấy phần tử có giá trị bằng giá trị cần tìm, trả về -1
            return -1;
        }

        // Đây là một hàm tìm kiếm một giá trị trong một mảng đã được sắp xếp bằng phương pháp tìm kiếm nhị phân
        // Hàm trả về vị trí của phần tử có giá trị bằng giá trị cần tìm, hoặc -1 nếu không tìm thấy
        public int BinarySearch(int valueSearch)
        {
            // Khởi tạo biến left là chỉ số đầu tiên của mảng
            int left = 0;
            // Khởi tạo biến right là chỉ số cuối cùng của mảng
            int right = Arr.Length - 1;

            // Lặp cho đến khi left lớn hơn right, tức là không còn phần tử nào để tìm kiếm
            while (left <= right)
            {
                // Tính chỉ số giữa của mảng
                int mid = (right + left) / 2;

                // Nếu phần tử ở vị trí giữa có giá trị bằng giá trị cần tìm, trả về mid
                if (Arr[mid] == valueSearch)
                    return mid;

                // Nếu phần tử ở vị trí giữa có giá trị nhỏ hơn giá trị cần tìm, gán left bằng mid + 1 để tìm kiếm ở nửa phải của mảng
                if (Arr[mid] < valueSearch)
                    left = mid + 1;
                // Ngược lại, nếu phần tử ở vị trí giữa có giá trị lớn hơn giá trị cần tìm, gán right bằng mid - 1 để tìm kiếm ở nửa trái của mảng
                else
                    right = mid - 1;
            }

            // Nếu không tìm thấy phần tử có giá trị bằng giá trị cần tìm, trả về -1
            return -1;
        }

        #endregion

        #region Checks

        Func<int, bool> CheckLengthArray = lengthArr => (lengthArr > 0 && lengthArr < 1000000);

        #endregion

        #region Sort : Sắp xếp tăng dần

        // Hàm sắp xếp một mảng bằng phương pháp đổi chỗ trực tiếp
        public void InterchangeSort()
        {
            // Lặp qua từng phần tử trong mảng
            for (int i = 0; i < Arr.Length; i++)
                // Lặp qua các phần tử còn lại sau phần tử hiện tại
                for (int j = i + 1; j < Arr.Length; j++)
                    // Nếu phần tử hiện tại lớn hơn phần tử kế tiếp
                    if (Arr[i].CompareTo(Arr[j]) > 0)
                        // Hoán đổi vị trí hai phần tử
                        Swap(ref Arr[i], ref Arr[j]);
        }

        // Hàm sắp xếp một mảng bằng phương pháp nổi bọt
        public void BubbleSort()
        {
            // Khởi tạo biến cờ để kiểm tra xem có hoán đổi hay không
            bool swapped;
            // Lặp qua từng phần tử trong mảng, bỏ qua phần tử cuối cùng
            for (int i = 1; i < Arr.Length; i++)
            {
                // Đặt biến cờ thành false
                swapped = false;
                // Lặp qua các phần tử từ đầu đến phần tử trước phần tử cuối cùng
                for (int j = 0; j < Arr.Length - i; j++)
                {
                    // Nếu phần tử hiện tại lớn hơn phần tử kế tiếp
                    if (Arr[j].CompareTo(Arr[j + 1]) > 0)
                    {
                        // Hoán đổi vị trí hai phần tử
                        Swap(ref Arr[j], ref Arr[j + 1]);
                        // Đặt biến cờ thành true
                        swapped = true;
                    }
                }
                // Nếu không có hoán đổi nào xảy ra, thoát khỏi vòng lặp
                if (!swapped) break;
            }
        }

        // Hàm sắp xếp một mảng bằng phương pháp chọn
        public void SelectionSort()
        {
            // Lặp qua từng phần tử trong mảng
            for (int i = 0; i < Arr.Length; i++)
            {
                // Khởi tạo biến indexMinValue là chỉ số của phần tử nhỏ nhất trong mảng từ vị trí i trở đi
                int indexMinValue = i;

                // Lặp qua các phần tử còn lại sau phần tử hiện tại
                for (int j = i + 1; j < Arr.Length; j++)
                    // Nếu phần tử có chỉ số indexMinValue lớn hơn phần tử kế tiếp
                    if (Arr[indexMinValue].CompareTo(Arr[j]) > 0)
                        // Cập nhật biến indexMinValue bằng chỉ số của phần tử kế tiếp
                        indexMinValue = j;

                // Hoán đổi vị trí của phần tử hiện tại với phần tử nhỏ nhất
                Swap(ref Arr[i], ref Arr[indexMinValue]);
            }
        }

        // Hàm sắp xếp một mảng bằng phương pháp chèn
        public void InsertionSort()
        {
            // Lặp qua từng phần tử trong mảng, bỏ qua phần tử đầu tiên
            for (int i = 1; i < Arr.Length; i++)
            {
                // Khởi tạo biến key là giá trị của phần tử hiện tại
                int key = Arr[i];
                // Khởi tạo biến j là chỉ số của phần tử hiện tại
                int j = i;

                // Lặp cho đến khi j nhỏ hơn 1 hoặc phần tử trước j nhỏ hơn hoặc bằng key
                while (j > 1 && Arr[j - 1].CompareTo(key) > 0)
                {
                    // Hoán đổi vị trí của phần tử trước j với phần tử hiện tại
                    Swap(ref Arr[j], ref Arr[j - 1]);
                    // Giảm biến j đi 1
                    j--;
                }

                // Gán giá trị của key cho phần tử ở vị trí j
                Arr[j] = key;
            }
        }

        // Hàm sắp xếp một mảng bằng phương pháp sắp xếp nhanh
        // Hàm có hai tham số, là chỉ số trái và chỉ số phải của mảng
        public void QuickSort(int left, int right)
        {
            // Khởi tạo biến indexLeft là chỉ số trái của mảng
            int indexLeft = left;
            // Khởi tạo biến indexRight là chỉ số phải của mảng
            int indexRight = right;
            // Khởi tạo biến pivot là giá trị của phần tử ở giữa mảng
            int pivot = Arr[(left + right) / 2];


            // Lặp cho đến khi indexLeft lớn hơn hoặc bằng indexRight
            while (indexLeft < indexRight)
            {
                // Tìm phần tử ở bên trái có giá trị lớn hơn hoặc bằng pivot
                while (Arr[indexLeft].CompareTo(pivot) < 0) indexLeft++;
                // Tìm phần tử ở bên phải có giá trị nhỏ hơn hoặc bằng pivot
                while (Arr[indexRight].CompareTo(pivot) > 0) indexRight--;

                // Nếu indexLeft nhỏ hơn hoặc bằng indexRight
                if (indexLeft <= indexRight)
                {
                    // Hoán đổi vị trí hai phần tử ở vị trí indexLeft và indexRight
                    Swap(ref Arr[indexLeft], ref Arr[indexRight]);
                    // Tăng biến indexLeft lên 1
                    indexLeft++;
                    // Giảm biến indexRight đi 1
                    indexRight--;
                }
            }

            // Nếu indexLeft nhỏ hơn right, gọi đệ quy hàm QuickSort với tham số là indexLeft và right
            if (indexLeft < right) QuickSort(indexLeft, right);
            // Nếu indexRight lớn hơn left, gọi đệ quy hàm QuickSort với tham số là left và indexRight
            if (indexRight > left) QuickSort(left, indexRight);
        }

        // Hàm sắp xếp một mảng bằng phương pháp sắp xếp Shell
        // Hàm này là một phiên bản nâng cấp của phương pháp sắp xếp chèn
        public void ShellSort()
        {
            // Khởi tạo biến gap là khoảng cách giữa các phần tử được so sánh
            // Ban đầu gán gap bằng một nửa độ dài mảng
            int gap = Arr.Length / 2;

            // Lặp cho đến khi gap bằng 0
            while (gap > 0)
            {
                // Lặp qua từng phần tử trong mảng, bắt đầu từ vị trí gap
                for (int i = gap; i < Arr.Length; i++)
                {
                    // Khởi tạo biến j là chỉ số của phần tử hiện tại
                    int j = i;

                    // Lặp cho đến khi j nhỏ hơn gap hoặc phần tử trước j nhỏ hơn hoặc bằng phần tử hiện tại
                    while (j >= gap && Arr[j - gap] > Arr[j])
                    {
                        // Hoán đổi vị trí hai phần tử ở vị trí j và j - gap
                        Swap(ref Arr[j], ref Arr[j - gap]);
                        // Giảm biến j đi gap đơn vị
                        j -= gap;
                    }
                }
                // Chia đôi biến gap
                gap /= 2;
            }
        }

        // Hàm sắp xếp một mảng bằng phương pháp lắc cải tiến của BubbleSort
        public void ShakerSort()
        {
            // Lặp qua từng phần tử trong mảng
            for (int i = 0; i < Arr.Length / 2; i++)
            {
                // Khởi tạo biến cờ để kiểm tra xem có hoán đổi hay không
                bool swapped = false;

                // Duyệt từ phải sang trái
                // Mục đích của vòng for này là đẩy phần tử lớn nhất về cuối mảng
                // j bằng i để bỏ qua những phần tử đã được sắp xếp ở đầu mảng.
                // j nhỏ hơn Arr.Length - i - 1 để tránh truy cập ra ngoài mảng
                for (int j = i; j < Arr.Length - i - 1; j++)
                {
                    // Nếu phần tử hiện tại lớn hơn phần tử kế tiếp
                    if (Arr[j].CompareTo(Arr[j + 1]) > 0)
                    {
                        // Hoán đổi vị trí hai phần tử
                        Swap(ref Arr[j], ref Arr[j + 1]);

                        // Đặt biến cờ thành true
                        swapped = true;
                    }
                }

                // Duyệt từ trái sang phải
                // Mục đích của vòng for này là đẩy phần tử nhỏ nhất về đầu mảng
                // j bằng Arr.Length - 2 - i để bỏ qua những phần tử đã được sắp xếp ở cuối mảng
                // j lớn hơn i để tránh truy cập ra ngoài mảng
                for (int j = Arr.Length - 2 - i; j > i; j--)
                {
                    // Nếu phần tử trước nhỏ hơn phần tử hiện tại
                    if (Arr[j - 1].CompareTo(Arr[j]) > 0)
                    {
                        // Hoán đổi vị trí hai phần tử
                        Swap(ref Arr[j - 1], ref Arr[j]);

                        // Đặt biến cờ thành true
                        swapped = true;
                    }
                }

                // Nếu không có hoán đổi nào xảy ra, thoát khỏi vòng lặp
                if (!swapped) break;
            }
        }

        // Hàm sắp xếp một mảng bằng phương pháp trộn 
        public void MergeSort()
        {
            int i, j, k; // các biến duyệt vòng lặp
            int size; // Kích thước các nửa mảng được chia ra
            int indexStarArrFirst; // vị trí bắt đầu nữa đầu tiên
            int indexStarArrLast; // vị trí kết thúc nữa đầu tiên
            int indexEndArrFirst; // vị trí bắt đầu nữa sau
            int indexEndArrLast; // vị trí kết thúc nữa sau

            size = 1; // Khởi tạo giá trị size bằng 1, tức là mỗi nửa mảng chỉ có 1 phần tử

            int[] ArrTemp = new int[Arr.Length]; // khởi tạo giá trị mảng phụ lưu kết quả 

            // Khi size < Arr.Length, tức là chưa duyệt hết toàn bộ mảng sắp xếp
            while (size < Arr.Length)
            {
                indexStarArrFirst = 0; // Gán vị trí bắt đầu nữa đầu tiên bằng 0
                k = 0; // Gán biến duyệt mảng phụ bằng 0

                int isDivideValue = indexStarArrFirst + size; // Tính giá trị để kiểm tra xem có thể chia được nữa mảng hay không

                // Khi isDivideValue < Arr.Length, tức là còn phần tử để chia thành nửa mảng
                while (isDivideValue < Arr.Length)
                {
                    indexStarArrLast = isDivideValue; // Gán vị trí bắt đầu nữa sau bằng isDivideValue

                    indexEndArrFirst = indexStarArrLast - 1; // Gán vị trí kết thúc nữa đầu tiên bằng indexStarArrLast - 1

                    int temp = indexStarArrLast + size - 1; // Tính giá trị để kiểm tra xem có thể lấy được nửa mảng sau hay không

                    indexEndArrLast = (temp < Arr.Length) ? (temp - 1) : (Arr.Length - 1); // Nếu temp < Arr.Length, tức là có thể lấy được nửa mảng sau, gán vị trí kết thúc nữa sau bằng temp - 1. Nếu không, gán vị trí kết thúc nữa sau bằng Arr.Length - 1

                    // Sử dụng vòng lặp for để duyệt qua các phần tử của hai nửa mảng và so sánh chúng
                    // Biến i duyệt từ vị trí bắt đầu đến vị trí kết thúc của nữa đầu tiên
                    // Biến j duyệt từ vị trí bắt đầu đến vị trí kết thúc của nữa sau
                    for (i = indexStarArrFirst, j = indexStarArrLast; i <= indexEndArrFirst && j <= indexEndArrLast; k++)
                    {
                       // Nếu phần tử của nữa đầu tiên nhỏ hơn hoặc bằng phần tử của nữa sau, gán phần tử đó cho mảng phụ và tăng i lên 1
                        if (Arr[i] <= Arr[j])   ArrTemp[k] = Arr[i++];
                        // Nếu không, gán phần tử của nữa sau cho mảng phụ và tăng j lên 1
                        else ArrTemp[k] = Arr[j++]; 
                    }

                    // Nếu còn phần tử chưa duyệt hết của nữa đầu tiên, gán chúng cho mảng phụ
                    while (i <= indexEndArrFirst) ArrTemp[k++] = Arr[i++];
                    
                    // Nếu còn phần tử chưa duyệt hết của nữa sau, gán chúng cho mảng phụ
                    while (j <= indexEndArrLast) ArrTemp[k++] = Arr[j++];

                    // Gán vị trí bắt đầu nữa đầu tiên bằng vị trí kết thúc nữa sau cộng 1
                    indexStarArrFirst = indexEndArrLast + 1;

                    isDivideValue = indexStarArrFirst + size; // Cập nhật giá trị kiểm tra chia m
                }

                // Nếu còn phần tử chưa duyệt hết của mảng ban đầu, gán chúng cho mảng phụ
                for (i = indexStarArrFirst; k < Arr.Length; i++)    ArrTemp[k++] = Arr[i];

                // Gán lại các giá trị của mảng phụ cho mảng ban đầu
                for (i = 0; i < Arr.Length; i++)    Arr[i] = ArrTemp[i];

                // Tăng size lên gấp đôi để chia các nửa mảng lớn hơn
                size *= 2;

            }
        }

        #endregion

        #region Functions Single : Các hàm chứ năng đơn lẻ không thuộc về một methods nào ở trên

        void Swap(ref int valueFirst, ref int valueSeconds)
        {
            int temp = valueFirst;
            valueFirst = valueSeconds;
            valueSeconds = temp;
        }

        // Hàm sắp xếp nhanh, khử đệ quy bằng phương pháp stack
        public void QuickSortStack(int left, int right)
        {
            StackDoan stackDoan = new StackDoan();
            stackDoan.Push(left, right);
            while(!stackDoan.IsEmpty)
            {
                int valueLeft, valueRight;
                stackDoan.Pop(out  valueLeft, out valueRight);
                int indexLeft = valueLeft, indexRight = valueRight, pivot = Arr[(valueLeft + valueRight) /2];

                while (indexLeft < indexRight)
                {
                    while (Arr[indexLeft].CompareTo(pivot) < 0) indexLeft++;

                    while (Arr[indexRight].CompareTo(pivot) > 0) indexRight--;

                    if (indexLeft <= indexRight)
                    {
                        Swap(ref Arr[indexLeft], ref Arr[indexRight]);
                        indexLeft++; indexRight--;
                    }
                }

                if (indexLeft < right) stackDoan.Push(indexLeft, right);

                if (indexRight > left) stackDoan.Push(left, indexRight);
            }
        }

        #endregion

        #endregion
    }
}
