using System;

namespace BangCuuChuong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            int n;
            do
            {
                Console.Write("Nhập số n (1 - 9): ");
                n = int.Parse(Console.ReadLine());

                if (n<1 || n>9)
                {
                    Console.WriteLine("Số không hợp lệ. Nhập lại.");
                }

            } while (n<1 || n>9);

            Console.WriteLine("\n===== BẢNG CỬU CHƯƠNG " +n+ " =====");

            for (int i=1; i<=10; i++)
            {
                Console.WriteLine(n+ " × " + i + " = " +(n * i));
            }
        }
    }
}