
using CSDL_IntArray;
using System.ComponentModel.Design;

Console.OutputEncoding =  System.Text.Encoding.UTF8;

#region TestCase A : tham số truyền vào là độ dài mảng

void TestCaseA(out int lengthArr, out IntArray obj)
{
    Console.Write("Mời nhập giá trị giới hạn của mảng : ");

    lengthArr = int.Parse(Console.ReadLine());

    obj = new IntArray(lengthArr);

    obj.Output();
}

#endregion

#region TestCase B : Không tham số truyền vào

void TestCaseB(int lengthArr, out IntArray obj)
{
    obj = new IntArray();

    obj.Input(lengthArr, 1);

    obj.Output();
}

#endregion

#region Search : Hàm TestCase tìm kiếm

void TestFindLinear(IntArray obj)
{
    Console.Write("Mời nhập giá trị cần tìm trong mảng : ");

    int valueSearch = int.Parse(Console.ReadLine());

    int resultSearch = obj.LinearSearch(valueSearch);

    if (resultSearch == -1)
        Console.WriteLine("Không tìm thấy");
    else
        Console.WriteLine($"Kết quả vị trí giá trị cần tìm bằng phương pháp tuần tự là {resultSearch}");

    Console.WriteLine();
}

void TestFindBinary(IntArray obj)
{
    Console.Write("Mời nhập giá trị cần tìm trong mảng B: ");

    int valueSearch = int.Parse(Console.ReadLine());

    int resultSearch = obj.BinarySearch(valueSearch);

    if (resultSearch == -1)
        Console.WriteLine("Không tìm thấy");
    else
        Console.WriteLine($"Kết quả vị trí giá trị cần tìm bằng phương pháp nhị phân là {resultSearch}");
}

#endregion

#region Sort : Các Hàm test thuật toán sắp xếp

//Test InterchangeSort
void InterchangeSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- InterchangeSort ----");
    Console.WriteLine();
    objTest.InterchangeSort();
    objTest.Output();
}

//Test BubbleSort
void BubbleSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- BubbleSort ----");
    Console.WriteLine();
    objTest.BubbleSort();
    objTest.Output();
}

//Test SelectionSort
void SelectionSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- SelectionSort ----");
    Console.WriteLine();
    objTest.SelectionSort();
    objTest.Output();
}

//Test InsertionSort
void InsertionSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- InsertionSort ----");
    Console.WriteLine();
    objTest.InsertionSort();
    objTest.Output();
}

//Test InsertionSort
void QuickSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- QuickSort ----");
    Console.WriteLine();
    objTest.QuickSort(0,obj.Arr.Length - 1);
    objTest.Output();
}

//Test ShellSort
void ShellSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- ShellSort ----");
    Console.WriteLine();
    objTest.ShellSort();
    objTest.Output();
}

//Test ShakerSort
void ShakerSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- ShakerSort ----");
    Console.WriteLine();
    objTest.ShakerSort();
    objTest.Output();
}

//Test MergeSort
void MergeSort(IntArray obj)
{
    IntArray objTest = new IntArray(obj);
    Console.WriteLine("---- MergeSort ----");
    Console.WriteLine();
    objTest.MergeSort();
    objTest.Output();
}

#endregion

#region Bài 2. TestCase

void TestCaseBT2()
{
    int lengthArr;

    #region Test IntArr có tham số truyền vào là độ dài mảng

    //Khởi tạo và xuất kết quả
    IntArray objA;
    TestCaseA(out lengthArr,out objA);

    //Test tìm giá trị bằng phương pháp tuần tự
    TestFindLinear(objA);

    #endregion

    #region Test IntArr không có tham số truyền vào

    // Khởi tạo và xuất kết quả
    IntArray objB;
    TestCaseB(lengthArr, out objB);

    //Tìm giá trị bằng phương pháp nhị phân
    TestFindBinary(objB);
    

    #endregion

}

#endregion

#region Bài 3 : Sắp xếp . TestCase

void TestCaseBT3()
{
    int lengthArr;
    IntArray obj;
    Console.WriteLine("----Trước khi sắp xếp ----");

    TestCaseA(out lengthArr,out obj);

    obj = new IntArray(obj);

    Console.WriteLine();

    InterchangeSort(obj);

    Console.WriteLine();

    BubbleSort(obj);

    Console.WriteLine();

    SelectionSort(obj);

    Console.WriteLine();

    InsertionSort(obj);

    Console.WriteLine();

    QuickSort(obj);

    Console.WriteLine();

    ShellSort(obj);

    Console.WriteLine();

    ShakerSort(obj);

    Console.WriteLine();

    MergeSort(obj);

    Console.WriteLine();

    Console.WriteLine("----Kết thúc ----");

}

#endregion

TestCaseBT3();