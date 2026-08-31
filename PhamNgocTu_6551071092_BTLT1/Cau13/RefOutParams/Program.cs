namespace RefOutParams
{
    class Program
    {
        static void HoanVi(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void TachSo(double n, out long phanNguyen, out double phanThapPhan)
        {
            phanNguyen = (long)n;
            phanThapPhan = n - phanNguyen;
        }

        static int TinhTong(params int[] soNguyen)
        {
            int tong = 0;
            foreach (int so in soNguyen)
            {
                tong += so;
            }
            return tong;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

            // Check HoanVi
            int x = 10, y = 20;
            Console.WriteLine($"Trước hoán vị: x = {x}, y = {y}");
            HoanVi(ref x, ref y);
            Console.WriteLine($"Sau hoán vị: x = {x}, y = {y}\n");

            // Check TachSo
            double soThuc = 15.789;
            long nguyen;
            double thapPhan;
            TachSo(soThuc, out nguyen, out thapPhan);
            Console.WriteLine($"Số ban đầu: {soThuc}");
            Console.WriteLine($"Phần nguyên: {nguyen}, Phần thập phân: {thapPhan:F3}\n");

            // Check TinhTong
            int tong1 = TinhTong(1, 2, 3);
            int tong2 = TinhTong(10, 20, 30, 40, 50);
            Console.WriteLine($"Tổng của (1, 2, 3) = {tong1}");
            Console.WriteLine($"Tổng của (10, 20, 30, 40, 50) = {tong2}");
        }
    }
}