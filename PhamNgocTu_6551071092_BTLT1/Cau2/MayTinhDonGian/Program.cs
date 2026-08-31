using System;

namespace MayTinhDonGian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            Console.Write("Nhập số a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhập số b: ");
            double b = double.Parse(Console.ReadLine());


            Console.WriteLine("Cộng: " + (a + b));
            Console.WriteLine("Trừ: " + (a - b));
            Console.WriteLine("Nhân: " + (a * b));

            if (b != 0)
            {
                Console.WriteLine("Chia: " + (a / b));

                // Chia lấy nguyên
                Console.WriteLine("Chia lấy phần nguyên: " + ((int)a / (int)b));

                //Chia lấy dư
                Console.WriteLine("Chia lấy phần dư: " + ((int)a % (int)b));
            }
            else
            {
                Console.WriteLine("Không thể chia cho 0.");
                Console.WriteLine("Không thể chia lấy phần nguyên.");
                Console.WriteLine("Không thể chia lấy phần dư.");
            }

            // Lũy thừa
            Console.WriteLine("Lũy thừa a^b: " + Math.Pow(a, b));
        }
    }
}