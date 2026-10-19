IF DB_ID(N'QL_NhaTro') IS NULL
    CREATE DATABASE QL_NhaTro;
GO

USE QL_NhaTro;
GO

IF OBJECT_ID(N'dbo.PhongTro', N'U') IS NULL
CREATE TABLE dbo.PhongTro
(
    MaPhong   int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PhongTro PRIMARY KEY,
    TenPhong  nvarchar(20)  NOT NULL CONSTRAINT UQ_PhongTro_TenPhong UNIQUE,
    GiaThue   decimal(18,0) NOT NULL,
    TinhTrang nvarchar(20)  NOT NULL CONSTRAINT DF_PhongTro_TinhTrang DEFAULT (N'Trống'),
    CONSTRAINT CK_PhongTro_TinhTrang CHECK (TinhTrang IN (N'Trống', N'Đang thuê'))
);
GO

IF OBJECT_ID(N'dbo.KhachThue', N'U') IS NULL
CREATE TABLE dbo.KhachThue
(
    MaKhach         int IDENTITY(1,1) NOT NULL CONSTRAINT PK_KhachThue PRIMARY KEY,
    HoTen           nvarchar(100) NOT NULL,
    GioiTinh        nvarchar(5)   NOT NULL,
    NgaySinh        date          NOT NULL,
    SoDienThoai     varchar(15)   NOT NULL,
    MaTinh          int           NULL,
    TenTinh         nvarchar(100) NOT NULL,
    MaPhuongXa      int           NULL,
    TenPhuongXa     nvarchar(100) NOT NULL,
    DaDangKyTamTru  bit           NOT NULL CONSTRAINT DF_KhachThue_TamTru DEFAULT (0),
    MaPhong         int           NOT NULL,
    CONSTRAINT FK_KhachThue_PhongTro FOREIGN KEY (MaPhong) REFERENCES dbo.PhongTro (MaPhong)
);
GO

-- 6 phong
IF NOT EXISTS (SELECT 1 FROM dbo.PhongTro)
INSERT INTO dbo.PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
    (N'P101', 1500000, N'Trống'),
    (N'P102', 1800000, N'Trống'),
    (N'P103', 2000000, N'Trống'),
    (N'P201', 2000000, N'Trống'),
    (N'P202', 2200000, N'Trống'),
    (N'P203', 2500000, N'Trống');
GO

-- Vai khach mau (ma tinh la ma that cua API; ma phuong/xa de NULL, ung dung doi chieu theo ten)
IF NOT EXISTS (SELECT 1 FROM dbo.KhachThue)
INSERT INTO dbo.KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
    (N'Nguyễn Văn An',  N'Nam', '2001-05-12', '0901234567', 1,  N'Thành phố Hà Nội',        NULL, N'Phường Ba Đình',  1, (SELECT MaPhong FROM dbo.PhongTro WHERE TenPhong = N'P101')),
    (N'Phạm Thị Dung',  N'Nữ',  '2002-02-20', '0933456789', 1,  N'Thành phố Hà Nội',        NULL, N'Phường Ba Đình',  0, (SELECT MaPhong FROM dbo.PhongTro WHERE TenPhong = N'P101')),
    (N'Trần Thị Bình',  N'Nữ',  '2002-09-30', '0912345678', 79, N'Thành phố Hồ Chí Minh',   NULL, N'Phường Sài Gòn',  1, (SELECT MaPhong FROM dbo.PhongTro WHERE TenPhong = N'P102')),
    (N'Lê Minh Cường',  N'Nam', '2000-11-03', '0987654321', 48, N'Thành phố Đà Nẵng',       NULL, N'Phường Hải Châu', 0, (SELECT MaPhong FROM dbo.PhongTro WHERE TenPhong = N'P103'));
GO

-- Dong bo trang thai phong theo khach hien co
UPDATE p SET TinhTrang = CASE WHEN EXISTS (SELECT 1 FROM dbo.KhachThue k WHERE k.MaPhong = p.MaPhong)
                              THEN N'Đang thuê' ELSE N'Trống' END
FROM dbo.PhongTro p;
GO
