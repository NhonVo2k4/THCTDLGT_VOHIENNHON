
using CSDL_DSLKDon;
using System.Security.Cryptography;

void ListMenu()
{
    Console.WriteLine();
    Console.WriteLine("------- Menu --------");

    Console.WriteLine("0. Thoát");

    Console.WriteLine("|>>> Nhập - Xuất danh sách");

    Console.WriteLine("1. Nhập giá trị vào danh sách");
    Console.WriteLine("2. Xuất giá trị của danh sách");

    Console.WriteLine("3. Trả về danh sách giá trị chẳn");
    Console.WriteLine("4. Trả về danh sách giá trị lớn");

    Console.WriteLine("|>>> Chèn");

    Console.WriteLine("5. Chèn giá trị vào đầu danh sách");
    Console.WriteLine("6. Chèn giá trị và cuối danh sách");

    Console.WriteLine("7. Chèn giá trị trước giá trị chỉ định");
    Console.WriteLine("8. Chèn giá trị sau giá trị chỉ định");

    Console.WriteLine("9. Chèn giá trị trước giá trị lớn nhất");
    Console.WriteLine("10. Chèn giá trị sau giá trị nhỏ nhát");

    Console.WriteLine("11. Chèn giá trị tại vị trí chỉ định");

    Console.WriteLine("|>>> Trả về giá trị");

    Console.WriteLine("12. Trả về vị trị giá trị lớn nhất");
    Console.WriteLine("13. Trả về giá trị lớn nhất");

    Console.WriteLine("14. Trả về vị trí giá trị nhỏ nhất");
    Console.WriteLine("15. Trả về giá trị nhỏ nhất");

    Console.WriteLine("16. Trả về vị trí của giá trị chỉ định");
    Console.WriteLine("17. Trả về giá trị của vị trí chỉ định");

    Console.WriteLine("|>>> Xoá");

    Console.WriteLine("18. Xoá giá trị tại vị chỉ định");
    Console.WriteLine("19. Xoá giá trị được chỉ định");

    Console.WriteLine("|>>> Xắp xếp danh sách");

    Console.WriteLine("20. Xắp xếp danh sách tăng dần");
    Console.WriteLine("21. Xắp xếp danh sách giảm dần");
    Console.WriteLine("22. Dịch chuyển giá trị sang phải, giá trị cuối danh sách trả về đầu danh sách");
}

void ChoiceMenu(out int choice)
{
    choice = -1;

    ListMenu();

    Console.WriteLine();

    Console.Write("Nhập hành động menu : ");

    if (!int.TryParse(Console.ReadLine(), out choice))
        choice = -1;

}

bool HandleMenu(int choiceMenu,ref MyList obj)
{

    IntNode nodeValue;
    int value;
    int valueInsert;

    if (choiceMenu == 0)
    {
        Console.WriteLine("Thoát chương trình");
        return false;
    }
    else if (choiceMenu == 1)
    {
        Console.WriteLine("-------- Nhập giá trị cho danh sách ---------");

        obj.Input();
        Console.WriteLine();

        return true;
    }
    else if(obj.Count == 0)
    {
        Console.WriteLine("Mảng trống, không thực hiện được menu.\n Thoát menu.");
        return false;
    }    
    else
    {
        switch (choiceMenu)
        {

            case 2:
                Console.WriteLine("-------- Xuất giá trị cho danh sách ---------");

                obj.Output();
                Console.WriteLine();

                return true;

            case 3:
                Console.WriteLine("-------- Xuất giá trị danh sách số chẳn --------");

                obj.GetEvenNumberList().Output();

                Console.WriteLine();

                return true;

            case 4:
                Console.WriteLine("-------- Xuất giá trị danh sách số lẻ --------");

                obj.GetOddNumbersList();

                Console.WriteLine();

                return true;

            case 5:
                Console.WriteLine("-------- Chèn giá trị vào đầu danh sách --------");

                Console.Write("Nhập giá trị cần chèn ");

                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                nodeValue = new IntNode(valueInsert);
                obj.AddFirst(nodeValue);

                return true;

            case 6:
                Console.WriteLine("-------- Chèn giá trị và cuối danh sách --------");

                Console.Write("Nhập giá trị cần chèn ");

                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                nodeValue = new IntNode(valueInsert);
                obj.AddLast(nodeValue);

                return true;

            case 7:

                Console.WriteLine("-------- Chèn giá trị trước giá trị chỉ định --------");

                Console.Write("Nhập giá trị cần chèn : ");
                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                Console.Write("Nhập giá trị chỉ định : ");
                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                obj.InsertValueBeforeValue(valueInsert, value);

                return true;

            case 8:
                Console.WriteLine("-------- Chèn giá trị sau giá trị chỉ định --------");

                Console.Write("Nhập giá trị cần chèn : ");
                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                Console.Write("Nhập giá trị chỉ định : ");
                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                obj.InsertValueAfterValue(valueInsert, value);

                return true;

            case 9:
                Console.WriteLine("-------- Chèn giá trị trước giá trị lớn nhất --------");

                Console.Write("Nhập giá trị cần chèn ");

                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                obj.InsertValueBeforeMax(valueInsert);

                return true;

            case 10:
                Console.WriteLine("--------  Chèn giá trị sau giá trị nhỏ nhát --------");

                Console.Write("Nhập giá trị cần chèn ");

                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                obj.InsertValueAfterMin(valueInsert);

                return true;

            case 11:
                Console.WriteLine("-------- Chèn giá trị tại vị trí chỉ định --------");

                Console.Write("Nhập giá trị cần chèn : ");
                while (!int.TryParse(Console.ReadLine(), out valueInsert))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                Console.Write("Nhập vị trí chỉ định : ");
                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Giá trị truyền vào không hợp lệ");

                obj.InsertValueByIndex(value, valueInsert);

                return true;

            case 12:
                Console.WriteLine("-------- Trả về vị trị giá trị lớn nhất --------");

                nodeValue = obj.GetMax();

                Console.WriteLine();

                Console.WriteLine($"Vị trí lớn nhất trong danh sách là : {nodeValue}");

                Console.WriteLine();

                return true;

            case 13:
                Console.WriteLine("-------- Trả về giá trị lớn nhất --------");

                value = obj.GetMax().Data;

                Console.WriteLine();

                Console.WriteLine($"Giá trị lớn nhất trong danh sách là : {value}");

                Console.WriteLine();

                return true;

            case 14:
                Console.WriteLine("-------- Trả về vị trí giá trị nhỏ nhất --------");

                nodeValue = obj.GetMax();

                Console.WriteLine();

                Console.WriteLine($"Vị trí lớn nhất trong danh sách là : {nodeValue}");

                Console.WriteLine();

                return true;

            case 15:
                Console.WriteLine("-------- Trả về giá trị nhỏ nhất --------");

                value = obj.GetMax().Data;

                Console.WriteLine();

                Console.WriteLine($"Giá trị nhỏ nhất trong danh sách là : {value}");

                Console.WriteLine();

                return true;

            case 16:
                Console.WriteLine("-------- Trả về vị trí của giá trị chỉ định --------");

                Console.Write("Nhập giá trị chỉ định : ");

                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Gias trị nhập vào không đúng.");

                nodeValue = obj.FindNodeByValue(value);

                Console.WriteLine();

                Console.WriteLine($"Vị trí giá trị trong danh sách là : {nodeValue}");

                Console.WriteLine();

                return true;

            case 17:
                Console.WriteLine("-------- Trả về giá trị của vị trí chỉ định --------");

                Console.Write("Nhập vị trí chỉ định : ");

                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Gias trị nhập vào không đúng.");

                nodeValue = obj.FindNodeByIndex(value);

                Console.WriteLine();

                Console.WriteLine($"Giá trị của vị trí trong danh sách là : {nodeValue.Data}");

                Console.WriteLine();

                return true;

            case 18:
                Console.WriteLine("-------- Xoá giá trị tại vị chỉ định --------");
;

                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Giá trị nhập vào không đúng.");

                obj.RemoveNodeByIndex(value);

                Console.WriteLine();

                return true;

            case 19:
                Console.WriteLine("-------- Xoá giá trị được chỉ định --------");

                Console.Write("Nhập giá trị cần xoá : ");       

                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Giá trị nhập vào không đúng.");

                obj.RemoveNodeByValue(value);

                Console.WriteLine();

                return true;

            case 20:
                Console.WriteLine("-------- Xắp xếp danh sách tăng dần --------");

                obj.InterchangeSort();

                Console.WriteLine("Hoàn thành");

                Console.WriteLine();

                return true;

            case 21:
                Console.WriteLine("-------- Xắp xếp danh sách giảm dần --------");
                Console.Write("Nhập vị trí cần xoá : ")

                obj.SelectionSort();

                Console.WriteLine("Hoàn thành");

                Console.WriteLine();

                return true;

            case 22:
                Console.WriteLine("-------- Dịch chuyển giá trị sang phải --------");

                obj.RShiftRight();

                Console.WriteLine("Hoàn thành");

                Console.WriteLine();

                return true;

        }
    }

        
    Console.WriteLine("Thực hiện menu thất bại, thoát menu.");
    return false;
}

void Menu()
{
    int choiceMenu;
    MyList myList = new MyList();
   
    while (true)
    {
        Console.Clear();

        ChoiceMenu(out choiceMenu);

        if(!HandleMenu(choiceMenu, ref myList)) break;

        Console.ReadKey();
    }
}

Console.OutputEncoding = System.Text.Encoding.UTF8;

Menu();