using System;

namespace TinhTongDay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            Console.Write("Nhập số nguyên dương n: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("n phải là số nguyên dương!");
                return;
            }

            long tong = 0;
            long tongChan = 0;
            long tongLe = 0;

            // Tính sum 1 + 2 + ... + n
            for (int i = 1; i <= n; i++)
            {
                tong += i;
            }

            // Tính sum các số chẵn và số lẻ
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    tongChan += i;
                }
                else
                {
                    tongLe += i;
                }
            }

            // Tính giai thừa
            long giaiThua = 1;
            int j = 1;

            while (j <= n)
            {
                giaiThua *= j;
                j++;
            }

            Console.WriteLine("\n===== KẾT QUẢ =====");
            Console.WriteLine("Tổng từ 1 đến " + n + ": " + tong);
            Console.WriteLine("Tổng các số chẵn: " + tongChan);
            Console.WriteLine("Tổng các số lẻ: " + tongLe);
            Console.WriteLine(n + "! = " + giaiThua);
        }
    }
}
