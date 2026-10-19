-- Tạo CSDL QL_TraSua (SQL Server Express: .\SQLEXPRESS)
IF DB_ID(N'QL_TraSua') IS NULL
    CREATE DATABASE QL_TraSua;
GO
USE QL_TraSua;
GO

IF OBJECT_ID(N'dbo.ChiTietHoaDon') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID(N'dbo.HoaDon')        IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.MonUong')       IS NOT NULL DROP TABLE dbo.MonUong;
IF OBJECT_ID(N'dbo.DanhMucMon')    IS NOT NULL DROP TABLE dbo.DanhMucMon;
GO

CREATE TABLE dbo.DanhMucMon (
    MaDM  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DanhMucMon PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);

CREATE TABLE dbo.MonUong (
    MaMon   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_MonUong PRIMARY KEY,
    TenMon  NVARCHAR(100) NOT NULL,
    GiaBan  DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL,
    MaDM    INT NOT NULL,
    CONSTRAINT FK_MonUong_DanhMucMon FOREIGN KEY (MaDM) REFERENCES dbo.DanhMucMon(MaDM)
);

CREATE TABLE dbo.HoaDon (
    MaHD        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HoaDon PRIMARY KEY,
    NgayLap     DATETIME NOT NULL,
    TongTien    DECIMAL(18,0) NOT NULL,
    HinhThucTT  NVARCHAR(20) NOT NULL,   -- N'Tiền mặt' / N'Chuyển khoản'
    DaThanhToan BIT NOT NULL
);

CREATE TABLE dbo.ChiTietHoaDon (
    MaHD   INT NOT NULL,
    MaMon  INT NOT NULL,
    SoLy   INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaMon),
    CONSTRAINT FK_ChiTietHoaDon_HoaDon  FOREIGN KEY (MaHD)  REFERENCES dbo.HoaDon(MaHD),
    CONSTRAINT FK_ChiTietHoaDon_MonUong FOREIGN KEY (MaMon) REFERENCES dbo.MonUong(MaMon)
);
GO

-- Dữ liệu mẫu: 4 danh mục
INSERT INTO dbo.DanhMucMon (TenDM) VALUES
 (N'Trà sữa'), (N'Trà trái cây'), (N'Topping'), (N'Đồ ăn vặt');

-- 14 món
INSERT INTO dbo.MonUong (TenMon, GiaBan, DangBan, MaDM)
SELECT v.TenMon, v.GiaBan, v.DangBan, d.MaDM
FROM (VALUES
 (N'Trà sữa trân châu đen', 35000, 1, N'Trà sữa'),
 (N'Trà sữa matcha',        40000, 1, N'Trà sữa'),
 (N'Trà sữa Thái xanh',     38000, 1, N'Trà sữa'),
 (N'Hồng trà sữa',          32000, 1, N'Trà sữa'),
 (N'Trà đào cam sả',        42000, 1, N'Trà trái cây'),
 (N'Trà vải',               40000, 1, N'Trà trái cây'),
 (N'Trà dâu tằm',           42000, 1, N'Trà trái cây'),
 (N'Trà chanh mật ong',     30000, 1, N'Trà trái cây'),
 (N'Trân châu trắng',        8000, 1, N'Topping'),
 (N'Thạch dừa',              7000, 1, N'Topping'),
 (N'Pudding trứng',         10000, 0, N'Topping'),
 (N'Khoai tây chiên',       25000, 1, N'Đồ ăn vặt'),
 (N'Bánh tráng trộn',       20000, 1, N'Đồ ăn vặt'),
 (N'Gà viên chiên',         30000, 1, N'Đồ ăn vặt')
) AS v(TenMon, GiaBan, DangBan, TenDM)
JOIN dbo.DanhMucMon d ON d.TenDM = v.TenDM;
GO
