using CSDL_IntStack;

void InputArr(ArrayStack obj)
{
    int valueInput;
    Console.WriteLine();
    Console.WriteLine("-------- Nhập giá trị cho mảng Stack --------");
    Console.WriteLine();
    while (!obj.IsFull)
    {
        Console.Write("Nhập giá trị (nhập -1 dừng) : ");
        while(!int.TryParse(Console.ReadLine(), out valueInput))
            Console.Write("Bạn nhập giá trị sai mời nhập lại : ");
        if (valueInput == -1) break;
        obj.Push(valueInput);
    }
    Console.WriteLine() ;
    if (obj.IsFull)
    {
        Console.WriteLine("Mảng đã đầy không thêm được nữa");
        Console.WriteLine();
    }
    Console.WriteLine("-------- Kết thúc việc nhập giá trị --------");
}

void InputList(ListStack obj)
{
    int valueInput;
    Console.WriteLine();
    Console.WriteLine("-------- Nhập giá trị cho danh sách Stack --------");
    Console.WriteLine();
    while (true)
    {
        Console.Write("Nhập giá trị (nhập -1 dừng) : ");
        while (!int.TryParse(Console.ReadLine(), out valueInput))
            Console.Write("Bạn nhập giá trị sai mời nhập lại : ");
        if (valueInput == -1) break;
        obj.Push(valueInput);
    }
    Console.WriteLine();

    Console.WriteLine("-------- Kết thúc việc nhập giá trị --------");
}

void OutputArr(ArrayStack obj)
{
    int outputValue;
    Console.WriteLine("-------- In giá trị trong mảng Stack --------");
    Console.WriteLine();
    if (obj.IsEmpty)
    {
        Console.WriteLine("Mảng trống không có giá trị");
        Console.WriteLine("-------- Kết thúc in giá trị --------");
        return;
    }
    Console.Write("Giá trị trong mảng :");
    for (int i = 0; i < obj.StackTop;i++)
        Console.Write($"{obj.StackArray[i],4}");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-------- Kết thúc in giá trị --------");
}

void OutputList(ListStack obj)
{
    int outputValue;// Khai báo giá trị xuất ra màn hình
    Console.WriteLine("-------- In giá trị trong danh sách Stack --------");
    Console.WriteLine();

    if (obj.IsEmpty)// Kiểm tra xem mảng có rỗng không, nếu có thông báo dừng chương trình
    {
        Console.WriteLine("Mảng trống không có giá trị");
        Console.WriteLine("-------- Kết thúc in giá trị --------");
        return;
    }

    ListStack listTemp = new ListStack();// mảng tạm lưu trữ giá trị xuất ra màn hình

    Console.Write("Giá trị trong mảng :");

    while(!obj.IsEmpty) // Xuất giá trị ra màn hình
    {
        obj.Pop(out outputValue);
        listTemp.Push(outputValue);
        Console.Write($"{outputValue,5}");
    }

    while (!listTemp.IsEmpty) // Coppy lại giá trị đã xuất
    {
        listTemp.Pop(out outputValue);
        obj.Push(outputValue);
    }
    
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-------- Kết thúc in giá trị --------");
}

void Menu()
{
    int choice;
    ArrayStack arrayStack = new ArrayStack(10000);
    ListStack listStack = new ListStack();

    while (true)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("------- Menu -------");
        Console.WriteLine();
        Console.WriteLine("0. Thoát");
        Console.WriteLine("1. Nhập giá trị vào mảng");
        Console.WriteLine("2. Xuât giá trị trong mảng");
        Console.WriteLine("3. Nhập giá trị vào danh sách");
        Console.WriteLine("4. Xuất giá trị trong danh sách");
        Console.WriteLine();

        Console.WriteLine();

        Console.Write("Nhập hành động menu : ");
        if (!int.TryParse(Console.ReadLine(), out choice))
            choice = -1;

        switch (choice)
        {
            case 0:
                Console.WriteLine("Thoát chương trình");
                break;
            case 1:
                InputArr(arrayStack);
                break;
            case 2:
                OutputArr(arrayStack);
                break;
            case 3:
                InputList(listStack);
                break;
            case 4:
                OutputList(listStack);
                break;
            default:
                Console.WriteLine("Giá trị bạn nhập không đúng, thoát hành động menu");
                break;
        }
        Console.ReadKey();
        if (choice == 0) break;
    }
}


Console.OutputEncoding = System.Text.Encoding.UTF8;

Menu();