using System;
using System.Text;

enum TrangThaiDonHang
{
    ChoDuyet = 0,
    DaDuyet = 1,
    DangGiao = 2,
    HoanThanh = 3,
    DaHuy = 4
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("MSSV: [6551071092] - Họ và tên: [Phạm Ngọc Tú]");

        int soNhap;

        do
        {
            Console.WriteLine("\n===== TRẠNG THÁI ĐƠN HÀNG =====");
            Console.WriteLine("0. Chờ duyệt");
            Console.WriteLine("1. Đã duyệt");
            Console.WriteLine("2. Đang giao");
            Console.WriteLine("3. Hoàn thành");
            Console.WriteLine("4. Đã hủy");
            Console.WriteLine("-1. Thoát");
            Console.Write("Nhập trạng thái: ");

            // Xử lý trường hợp nhập k phải số
            try
            {
                soNhap = int.Parse(Console.ReadLine());

                // Check nếu muốn thoát
                if (soNhap == -1)
                {
                    Console.WriteLine("Đã thoát chương trình.");
                    break;
                }

                // Xử lý ngoại lệ khi nhập ngoài 0-4
                if (soNhap < 0 || soNhap > 4)
                {
                    throw new Exception("Giá trị phải nằm trong khoảng từ 0 đến 4!");
                }

                // Ép kiểu int sang enum
                TrangThaiDonHang trangThai = (TrangThaiDonHang)soNhap;

                switch (trangThai)
                {
                    case TrangThaiDonHang.ChoDuyet:
                        Console.WriteLine("Trạng thái: Chờ duyệt");
                        Console.WriteLine("Đơn hàng đã được tạo và đang chờ người bán xác nhận.");
                        break;

                    case TrangThaiDonHang.DaDuyet:
                        Console.WriteLine("Trạng thái: Đã duyệt");
                        Console.WriteLine("Đơn hàng đã được người bán xác nhận.");
                        break;

                    case TrangThaiDonHang.DangGiao:
                        Console.WriteLine("Trạng thái: Đang giao");
                        Console.WriteLine("Đơn hàng đang được vận chuyển đến khách hàng.");
                        break;

                    case TrangThaiDonHang.HoanThanh:
                        Console.WriteLine("Trạng thái: Hoàn thành");
                        Console.WriteLine("Đơn hàng đã được giao thành công.");
                        break;

                    case TrangThaiDonHang.DaHuy:
                        Console.WriteLine("Trạng thái: Đã hủy");
                        Console.WriteLine("Đơn hàng đã bị hủy.");
                        break;
                }
            }
            catch (FormatException)
            {
                // Xử lý khi ng dùng nhập k phải số
                Console.WriteLine("Lỗi: Vui lòng nhập một số!");
                soNhap = 0;
            }
            catch (Exception ex)
            {
                // Xử lý giá trị nằm ngoài phạm vi
                Console.WriteLine("Lỗi: " + ex.Message);
                soNhap = 0;
            }

        } while (soNhap != -1);
    }
}
