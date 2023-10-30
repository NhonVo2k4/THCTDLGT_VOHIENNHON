
using CSDL_SinhVien;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

#region Test sinh viên default

SinhVien sv = new SinhVien();

sv.Input();

Console.WriteLine();

sv.Output();

#endregion 

#region Test mảng sinh viên

MangSinhVien msv = new MangSinhVien();

Console.WriteLine();

msv.Input();

msv.Output();

#endregion