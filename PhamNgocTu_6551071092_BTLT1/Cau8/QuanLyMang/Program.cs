using System;

namespace QuanLyMang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");
            int[] arr = new int[10];

            Console.WriteLine("Nhập 10 phần tử cho mảng:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Phần tử thứ {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("\nMảng vừa nhập: ");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }

            // Tính sum và avg
            int tong = 0;
            foreach (int item in arr)
            {
                tong += item;
            }
            double trungBinh = (double)tong / arr.Length;
            Console.WriteLine($"\nTổng: {tong}, Trung bình: {trungBinh}");

            // Gtri min, max, idx
            int max = arr[0], min = arr[0];
            int viTriMax = 0, viTriMin = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    viTriMax = i;
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                    viTriMin = i;
                }
            }
            Console.WriteLine($"Max: {max} ở vị trí {viTriMax + 1}");
            Console.WriteLine($"Min: {min} ở vị trí {viTriMin + 1}");

            // Số ptu chẵn, lẻ
            int chan = 0, le = 0;
            foreach (int item in arr)
            {
                if (item % 2 == 0) chan++;
                else le++;
            }
            Console.WriteLine($"Số lượng phần tử chẵn: {chan}, lẻ: {le}");

            // Mảng sau khi đảo ngược thứ tự
            Console.Write("Mảng sau khi đảo ngược: ");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}