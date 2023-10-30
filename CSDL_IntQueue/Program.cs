using CSDL_IntQueue;

static void InputArr(ArrayQueue obj)
{
    int valueInput;
    Console.WriteLine();
    Console.WriteLine("-------- Nhập giá trị cho mảng Queue --------");
    Console.WriteLine();
    while (!obj.IsFull)
    {
        Console.Write("Nhập giá trị (nhập -1 dừng) : ");
        while (!int.TryParse(Console.ReadLine(), out valueInput))
            Console.Write("Bạn nhập giá trị sai mời nhập lại : ");
        if (valueInput == -1) break;
        obj.EnQueue(valueInput);
    }
    Console.WriteLine();
    if (obj.IsFull)
    {
        Console.WriteLine("Mảng đã đầy không thêm được nữa");
        Console.WriteLine();
    }
    Console.WriteLine("-------- Kết thúc việc nhập giá trị --------");
}

static void InputList(ListQueue obj)
{
    int valueInput;
    Console.WriteLine();
    Console.WriteLine("-------- Nhập giá trị cho danh sách Queue --------");
    Console.WriteLine();
    while (true)
    {
        Console.Write("Nhập giá trị (nhập -1 dừng) : ");
        while (!int.TryParse(Console.ReadLine(), out valueInput))
            Console.Write("Bạn nhập giá trị sai mời nhập lại : ");
        if (valueInput == -1) break;
        obj.EnQueue(valueInput);
    }
    Console.WriteLine();

    Console.WriteLine("-------- Kết thúc việc nhập giá trị --------");
}

static void OutputArr(ArrayQueue obj)
{
    int outputValue;
    Console.WriteLine("-------- In giá trị trong mảng Queue --------");
    Console.WriteLine();
    if (obj.IsEmpty)
    {
        Console.WriteLine("Mảng trống không có giá trị");
        Console.WriteLine("-------- Kết thúc in giá trị --------");
        return;
    }
    Console.Write("Giá trị trong mảng :");
    for (int i = 0; i < obj.Cout; i++)
        Console.Write($"{obj.Queue[i],4}");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-------- Kết thúc in giá trị --------");
}

static void OutputList(ListQueue obj)
{
    int outputValue;// Khai báo giá trị xuất ra màn hình
    Console.WriteLine("-------- In giá trị trong danh sách Queue --------");
    Console.WriteLine();

    if (obj.IsEmpty)// Kiểm tra xem mảng có rỗng không, nếu có thông báo dừng chương trình
    {
        Console.WriteLine("Mảng trống không có giá trị");
        Console.WriteLine("-------- Kết thúc in giá trị --------");
        return;
    }

    ListQueue listTemp = new ListQueue();// mảng tạm lưu trữ giá trị xuất ra màn hình

    Console.Write("Giá trị trong mảng :");

    while (!obj.IsEmpty) // Xuất giá trị ra màn hình
    {
        obj.DeQueue(out outputValue);
        listTemp.EnQueue(outputValue);
        Console.Write($"{outputValue,5}");
    }

    while (!listTemp.IsEmpty) // Coppy lại giá trị đã xuất
    {
        listTemp.DeQueue(out outputValue);
        obj.EnQueue(outputValue);
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-------- Kết thúc in giá trị --------");
}

static void Menu()
{
    int choice;
    ArrayQueue arrayStack = new ArrayQueue(10);
    ListQueue listStack = new ListQueue();

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("------- Menu --------");
        Console.WriteLine();
        Console.WriteLine("0. Thoát");
        Console.WriteLine("1. Nhập giá trị vào mảng");
        Console.WriteLine("2. Xuât giá trị trong mảng");
        Console.WriteLine("3. Nhập giá trị vào danh sách");
        Console.WriteLine("4. Xuất giá trị trong danh sách");
        Console.WriteLine("5. Xuất giá trị đầu mảng");
        Console.WriteLine("6. Xuất giá trị đầu danh sách");
        Console.WriteLine("7. Xuất giá trị đầu mảng");
        Console.WriteLine("8. Xuất giá trị đầu danh sách");
        Console.WriteLine();
        Console.WriteLine("------ Kết thúc menu --------");

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
            case 5:
                Console.WriteLine();
                if (arrayStack.IsEmpty)
                {
                    Console.WriteLine("Mảng không có giá trị");
                    break;
                }
                Console.WriteLine($"Gía trị đầu mảng : {arrayStack.Queue[arrayStack.Font]}");
                Console.WriteLine();
                break;
            case 6:
                Console.WriteLine();
                if (listStack.IsEmpty)
                {
                    Console.WriteLine("Mảng không có giá trị");
                    break;
                }
                Console.WriteLine($"Gía trị đầu danh sách : {listStack.Font.Data}");
                Console.WriteLine();
                break;
            case 7:
                Console.WriteLine();
                if (arrayStack.IsEmpty)
                {
                    Console.WriteLine("Mảng không có giá trị");
                    break;
                }
                Console.WriteLine($"Gía trị cuối mảng : {arrayStack.Queue[arrayStack.Rear]}");
                Console.WriteLine();
                break;
            case 8:
                Console.WriteLine();
                if (listStack.IsEmpty)
                {
                    Console.WriteLine("Mảng không có giá trị");
                    break;
                }
                Console.WriteLine($"Gía trị cuối danh sách : {listStack.Rear.Data}");
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Giá trị bạn nhập không đúng, thoát hành động menu");
                break;
        }
        if (choice == 0) break;
    }
}


Console.OutputEncoding = System.Text.Encoding.UTF8;
Menu();