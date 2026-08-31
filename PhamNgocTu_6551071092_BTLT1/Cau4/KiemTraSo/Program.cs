using System;

namespace KiemTraSo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            Console.Write("Nhập một số nguyên: ");
            int n = int.Parse(Console.ReadLine());

            // Check số dương, âm hay bằng 0
            if (n>0)
            {
                Console.WriteLine("Số đó là số dương.");
            }
            else if (n<0)
            {
                Console.WriteLine("Số đó là số âm.");
            }
            else
            {
                Console.WriteLine("Số đó bằng 0.");
            }

            //Check chẵn lẻ
            if (n%2 == 0)
            {
                Console.WriteLine("Số đó là số chẵn.");
            }
            else
            {
                Console.WriteLine("Số đó là số lẻ.");
            }

            //Check có chia hết cho 3 k
            if (n%3 == 0)
            {
                Console.WriteLine("Số đó chia hết cho 3.");
            }
            else
            {
                Console.WriteLine("Số đó không chia hết cho 3.");
            }

            //Check có chia hết cho cả 2 và 3 k
            if (n % 2 == 0 && n % 3 == 0)
            {
                Console.WriteLine("Số đó chia hết cho cả 2 và 3.");
            }
            else
            {
                Console.WriteLine("Số đó không chia hết cho cả 2 và 3.");
            }
        }
    }
}
