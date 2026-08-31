using System;

namespace Cau15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            int[,] matrix = new int[3, 3];

            Console.WriteLine("Nhập giá trị cho ma trận 3x3:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Phần tử [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n--- Ma trận gốc ---");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int tongAll = 0, tongChinh = 0, tongPhu = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tongAll += matrix[i, j];

                    // Đường chéo 9: chỉ số hàng == chỉ số cột
                    if (i == j) tongChinh += matrix[i, j];

                    // Đường chéo 8: sum chỉ số hàng và cột = size ma trận - 1 (ở đây là 2)
                    if (i + j == 2) tongPhu += matrix[i, j];
                }
            }
            Console.WriteLine($"\nTổng tất cả phần tử: {tongAll}");
            Console.WriteLine($"Tổng đường chéo chính: {tongChinh}");
            Console.WriteLine($"Tổng đường chéo phụ: {tongPhu}");

            int maxRowSum = int.MinValue;
            int minColSum = int.MaxValue;
            int maxRowIdx = -1, minColIdx = -1;

            // Tìm hàng lớn nhất
            for (int i = 0; i < 3; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < 3; j++) rowSum += matrix[i, j];

                if (rowSum > maxRowSum)
                {
                    maxRowSum = rowSum;
                    maxRowIdx = i;
                }
            }

            // Tìm cột nhỏ nhất
            for (int j = 0; j < 3; j++)
            {
                int colSum = 0;
                for (int i = 0; i < 3; i++) colSum += matrix[i, j];

                if (colSum < minColSum)
                {
                    minColSum = colSum;
                    minColIdx = j;
                }
            }
            Console.WriteLine($"\nHàng có tổng lớn nhất là hàng {maxRowIdx} (Tổng = {maxRowSum})");
            Console.WriteLine($"Cột có tổng nhỏ nhất là cột {minColIdx} (Tổng = {minColSum})");

            // Ma trận chuyển vị
            Console.WriteLine("\n--- Ma trận chuyển vị ---");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Đảo ngược vị trí hàng và cột [i, j] thành [j, i] khi in
                    Console.Write(matrix[j, i] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}