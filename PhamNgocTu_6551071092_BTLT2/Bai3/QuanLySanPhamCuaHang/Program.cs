using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    class SanPham
    {
        private string _maSP;
        private string _tenSP;
        private decimal _gia;
        private int _soLuongTon;

        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public decimal Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }

        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set { _soLuongTon = value; }
        }

        public SanPham(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon)
        {
            _maSP = maSP;
            _tenSP = tenSP;
            _gia = gia;
            _soLuongTon = soLuongTon;
        }

        public virtual decimal TinhGiaBan()
        {
            return _gia;
        }

        public virtual string MoTa()
        {
            return "Mã SP: " + _maSP
                + " | Tên SP: " + _tenSP
                + " | Giá: " + _gia
                + " | Số lượng tồn: " + _soLuongTon;
        }
    }


    class SanPhamThucPham : SanPham
    {
        private DateTime _ngayHetHan;
        private int _nhietDoBaoQuan;

        public DateTime NgayHetHan
        {
            get { return _ngayHetHan; }
            set { _ngayHetHan = value; }
        }

        public int NhietDoBaoQuan
        {
            get { return _nhietDoBaoQuan; }
            set { _nhietDoBaoQuan = value; }
        }

        public SanPhamThucPham(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            DateTime ngayHetHan,
            int nhietDoBaoQuan)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _ngayHetHan = ngayHetHan;
            _nhietDoBaoQuan = nhietDoBaoQuan;
        }

        public override decimal TinhGiaBan()
        {
            int soNgayConLai =
                (_ngayHetHan - DateTime.Now).Days;

            if (soNgayConLai <= 3 && soNgayConLai >= 0)
            {
                return Gia * 70 / 100;
            }

            return Gia;
        }

        public override string MoTa()
        {
            return base.MoTa()
                + " | Loại: Thực phẩm"
                + " | Ngày hết hạn: "
                + _ngayHetHan.ToString("dd/MM/yyyy")
                + " | Nhiệt độ bảo quản: "
                + _nhietDoBaoQuan + "°C";
        }
    }


    class SanPhamDienTu : SanPham
    {
        private int _baoHanhThang;
        private string _hangSanXuat;

        public int BaoHanhThang
        {
            get { return _baoHanhThang; }
            set { _baoHanhThang = value; }
        }

        public string HangSanXuat
        {
            get { return _hangSanXuat; }
            set { _hangSanXuat = value; }
        }

        public SanPhamDienTu(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            int baoHanhThang,
            string hangSanXuat)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _baoHanhThang = baoHanhThang;
            _hangSanXuat = hangSanXuat;
        }

        public override decimal TinhGiaBan()
        {
            if (_baoHanhThang > 12)
            {
                return Gia * 110 / 100;
            }

            return Gia;
        }

        public override string MoTa()
        {
            return base.MoTa()
                + " | Loại: Điện tử"
                + " | Bảo hành: "
                + _baoHanhThang + " tháng"
                + " | Hãng sản xuất: "
                + _hangSanXuat;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<SanPham> danhSach =
                new List<SanPham>
                {
                    new SanPham(
                        "SP001",
                        "Bàn học",
                        1_500_000,
                        10
                    ),

                    new SanPhamThucPham(
                        "TP001",
                        "Sữa tươi",
                        30_000,
                        50,
                        DateTime.Now.AddDays(2),
                        5
                    ),

                    new SanPhamThucPham(
                        "TP002",
                        "Bánh mì",
                        20_000,
                        30,
                        DateTime.Now.AddDays(7),
                        25
                    ),

                    new SanPhamDienTu(
                        "DT001",
                        "Laptop",
                        20_000_000,
                        5,
                        24,
                        "ASUS"
                    ),

                    new SanPhamDienTu(
                        "DT002",
                        "Chuột",
                        500_000,
                        20,
                        12,
                        "Logitech"
                    )
                };


            Console.WriteLine(
                "DANH SÁCH SẢN PHẨM"
            );

            Console.WriteLine(
                "=============================="
            );


            foreach (SanPham sp in danhSach)
            {
                Console.WriteLine(
                    sp.MoTa()
                );

                Console.WriteLine(
                    "Giá bán: "
                    + sp.TinhGiaBan()
                        .ToString("N0")
                    + " VNĐ"
                );

                Console.WriteLine(
                    "------------------------------"
                );
            }


            decimal tongGiaTriKho = 0;


            foreach (SanPham sp in danhSach)
            {
                tongGiaTriKho =
                    tongGiaTriKho
                    + sp.Gia
                    * sp.SoLuongTon;
            }


            Console.WriteLine(
                "\nTỔNG GIÁ TRỊ KHO HÀNG: "
                + tongGiaTriKho.ToString("N0")
                + " VNĐ"
            );


            Console.ReadKey();
        }
    }
}