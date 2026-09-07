using System;
using System.Text;

namespace TinhLuongNhanVien
{
    class NhanVien
    {
        private string _maNV;
        private string _hoTen;
        private decimal _luongCoBan;
        private int _soNgayLam;
        private int _soNgayNghiPhep;

        public NhanVien()
        {
            _maNV = "NV000";
            _hoTen = "Chưa có tên";
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        public NhanVien(
            string maNV,
            string hoTen,
            decimal luong = 5_000_000,
            int soNgayLam = 26)
        {
            _maNV = maNV;

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                throw new ArgumentException(
                    "Họ tên không được để trống!"
                );
            }

            _hoTen = hoTen;

            if (luong < 0)
            {
                throw new ArgumentException(
                    "Lương cơ bản không được nhỏ hơn 0!"
                );
            }

            _luongCoBan = luong;

            if (soNgayLam < 0 || soNgayLam > 31)
            {
                throw new ArgumentException(
                    "Số ngày làm phải từ 0 đến 31!"
                );
            }

            _soNgayLam = soNgayLam;
            _soNgayNghiPhep = 0;
        }

        public string HoTen
        {
            get
            {
                return _hoTen;
            }

            set
            {
                _hoTen = value;
            }
        }

        public decimal LuongCoBan
        {
            get
            {
                return _luongCoBan;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Lương cơ bản không được nhỏ hơn 0!"
                    );
                }

                _luongCoBan = value;
            }
        }

        public int SoNgayLam
        {
            get
            {
                return _soNgayLam;
            }

            set
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentException(
                        "Số ngày làm phải từ 0 đến 31!"
                    );
                }

                _soNgayLam = value;
            }
        }

        public decimal LuongThucNhan
        {
            get
            {
                decimal khauTruBHXH =
                    _luongCoBan * 8 / 100;

                return _luongCoBan / 26
                       * _soNgayLam
                       - khauTruBHXH;
            }
        }

        public decimal TinhThuong()
        {
            return 0;
        }

        public decimal TinhThuong(decimal heSo)
        {
            return _luongCoBan * heSo;
        }

        public decimal TinhThuong(
            decimal heSo,
            bool coPhucLoi)
        {
            decimal thuong =
                _luongCoBan * heSo;

            if (coPhucLoi == true)
            {
                thuong = thuong + 500_000;
            }

            return thuong;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Mã NV: " + _maNV);
            Console.WriteLine("Họ tên: " + _hoTen);
            Console.WriteLine("Lương cơ bản: "
                + _luongCoBan.ToString("N0") + " VNĐ");
            Console.WriteLine("Số ngày làm: " + _soNgayLam);
            Console.WriteLine("Số ngày nghỉ phép: "
                + _soNgayNghiPhep);
            Console.WriteLine("Lương thực nhận: "
                + LuongThucNhan.ToString("N0") + " VNĐ");
            Console.WriteLine("==============================");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            NhanVien nv1 = new NhanVien();

            NhanVien nv2 =
                new NhanVien(
                    "NV002",
                    "Nguyễn Văn An"
                );

            NhanVien nv3 =
                new NhanVien(
                    maNV: "NV003",
                    hoTen: "Trần Thị Bình",
                    soNgayLam: 20
                );

            Console.WriteLine("NHÂN VIÊN 1:");
            nv1.HienThiThongTin();

            Console.WriteLine("\nNHÂN VIÊN 2:");
            nv2.HienThiThongTin();

            Console.WriteLine("\nNHÂN VIÊN 3:");
            nv3.HienThiThongTin();

            Console.WriteLine("\nSO SÁNH CÁC CÁCH TÍNH THƯỞNG");

            decimal thuong1 = nv3.TinhThuong();

            Console.WriteLine(
                "TinhThuong(): "
                + thuong1.ToString("N0")
                + " VNĐ"
            );

            decimal thuong2 =
                nv3.TinhThuong(0.1m);

            Console.WriteLine(
                "TinhThuong(0.1m): "
                + thuong2.ToString("N0")
                + " VNĐ"
            );

            decimal thuong3 =
                nv3.TinhThuong(
                    0.1m,
                    true
                );

            Console.WriteLine(
                "TinhThuong(0.1m, true): "
                + thuong3.ToString("N0")
                + " VNĐ"
            );

            try
            {
                nv3.LuongCoBan = -1_000_000;
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