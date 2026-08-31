using System;

namespace ChuyenDoiNhietDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            // Nhập nhiệt độ (Celsius)
            Console.Write("Nhập nhiệt độ Celsius: ");
            decimal celsius = decimal.Parse(Console.ReadLine());

            // Chuyển qua Fahrenheit
            decimal fahrenheit = celsius * 9 / 5 + 32;

            // Chuyển sang Kelvin
            decimal kelvin = celsius + 273.15m;

            Console.WriteLine("Fahrenheit: {0:F2}", fahrenheit);
            Console.WriteLine("Kelvin: {0:F2}", kelvin);
        }
    }
}