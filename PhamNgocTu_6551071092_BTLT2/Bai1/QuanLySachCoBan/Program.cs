using System;
using System.Text;

namespace QuanLySachCoBan
{
    class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;

        public Sach(string m, string t, string tg, int n, double g)
        {
            _maSach = m;

            if (string.IsNullOrWhiteSpace(t))
            {
                throw new ArgumentException(
                    "Tên sách không được để trống!"
                );
            }

            _tenSach = t;

            _tacGia = tg;


            if (n < 1900 || n > DateTime.Now.Year)
            {
                throw new ArgumentException(
                    "Năm xuất bản không hợp lệ!"
                );
            }

            _namXuatBan = n;


            if (g < 0)
            {
                throw new ArgumentException(
                    "Giá bán không được nhỏ hơn 0!"
                );
            }

            _giaBan = g;
        }

        public Sach()
        {
            _maSach = "MS001";
            _tenSach = "Chưa có tên";
            _tacGia = "Chưa rõ";
            _namXuatBan = DateTime.Now.Year;
            _giaBan = 0;
        }

        public string MaSach // read only btw
        {
            get
            {
                return _maSach;
            }
        }

        public string TenSach
        {
            get
            {
                return _tenSach;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        ("Tên sách không được để trống!");
                }

                _tenSach = value;
            }
        }

        public string TacGia
        {
            get
            {
                return _tacGia;
            }

            set
            {
                _tacGia = value;
            }
        }

        public int NamXuatBan
        {
            get
            {
                return _namXuatBan;
            }

            set
            {
                if (value < 1900 ||
                    value > DateTime.Now.Year)
                {
                    throw new ArgumentException(
                        "Năm xuất bản phải từ 1900 đến năm hiện tại"
                    );
                }

                _namXuatBan = value;
            }
        }

        public double GiaBan // read only
        {
            get
            {
                return _giaBan;
            }
        }

        public void HienThiThongTin()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Mã sách: " + _maSach);
            Console.WriteLine("Tên sách: " + _tenSach);
            Console.WriteLine("Tác giả: " + _tacGia);
            Console.WriteLine("Năm xuất bản: " + _namXuatBan);
            Console.WriteLine("Giá bán: " + _giaBan);
            Console.WriteLine("================================");
        }

        public override string ToString()
        {
            return "Mã sách: " + _maSach +
                   " | Tên sách: " + _tenSach +
                   " | Tác giả: " + _tacGia;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Sach sach1 = new Sach(
                "S001",
                "Lập trình C#",
                "Nguyễn Văn A",
                2025,
                120000
            );


            Sach sach2 = new Sach();

            sach2.TenSach = "Cơ sở dữ liệu";
            sach2.TacGia = "Trần Văn B";
            sach2.NamXuatBan = 2024;


            Sach sach3 = new Sach()
            {
                TenSach = "Lập trình hướng đối tượng",
                TacGia = "Lê Văn C",
                NamXuatBan = 2023
            };


            Console.WriteLine("SÁCH 1:");
            sach1.HienThiThongTin();

            Console.WriteLine("\nSÁCH 2:");
            sach2.HienThiThongTin();

            Console.WriteLine("\nSÁCH 3:");
            sach3.HienThiThongTin();


            Console.WriteLine("\nTHÔNG TIN TÓM TẮT:");
            Console.WriteLine(sach1.ToString());


            try
            {
                sach1.NamXuatBan = 1800;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nLỖI:");
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}
