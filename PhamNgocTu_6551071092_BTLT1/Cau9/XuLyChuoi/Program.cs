using System;
using System.Text;

namespace XuLyChuoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            Console.Write("Nhập họ tên đầy đủ: ");
            string hoTen = Console.ReadLine();

            Console.WriteLine("Độ dài chuỗi: " + hoTen.Length);
            Console.WriteLine("Chuỗi chữ HOA: " + hoTen.ToUpper());
            Console.WriteLine("Chuỗi chữ thường: " + hoTen.ToLower());

            string chuoiTrim = hoTen.Trim();
            Console.WriteLine("Chuỗi sau khi Trim: " + chuoiTrim);

            Console.WriteLine("Có chứa từ \"Nguyễn\" không: "
                + hoTen.Contains("Nguyễn"));

            string[] mangTu = chuoiTrim.Split(' ');

            Console.WriteLine("Các từ trong họ tên:");

            foreach (string tu in mangTu)
            {
                if (tu != "")
                {
                    Console.WriteLine(tu);
                }
            }

            string chuoiGhep = String.Join("-", mangTu);
            Console.WriteLine("Chuỗi sau khi Join: " + chuoiGhep);

            Console.ReadKey();
        }
    }
}
