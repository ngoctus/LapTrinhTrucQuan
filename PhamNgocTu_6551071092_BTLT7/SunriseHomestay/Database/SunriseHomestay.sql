-- Bài 3: Quản lý Loại phòng - Phòng ở Sunrise Homestay
IF DB_ID(N'SunriseHomestayDB') IS NULL
    CREATE DATABASE SunriseHomestayDB;
GO
USE SunriseHomestayDB;
GO
IF OBJECT_ID(N'dbo.LoaiPhong', N'U') IS NULL
CREATE TABLE dbo.LoaiPhong
(
    MaLoai     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LoaiPhong PRIMARY KEY,
    TenLoai    NVARCHAR(100) NOT NULL,
    GiaMoiDem  DECIMAL(18,2) NULL,
    MoTa       NVARCHAR(255) NULL
);
GO
IF OBJECT_ID(N'dbo.Phong', N'U') IS NULL
CREATE TABLE dbo.Phong
(
    MaPhong   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Phong PRIMARY KEY,
    SoPhong   VARCHAR(10) NOT NULL,
    TangSo    INT NULL,
    TinhTrang NVARCHAR(20) NULL CONSTRAINT CK_Phong_TinhTrang CHECK (TinhTrang IN (N'Trống', N'Đang ở', N'Đang dọn')),
    HinhAnh   NVARCHAR(255) NULL,          -- chỉ lưu TÊN FILE, không lưu đường dẫn đầy đủ
    MaLoai    INT NULL CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY REFERENCES dbo.LoaiPhong(MaLoai)
);
GO
IF NOT EXISTS (SELECT 1 FROM dbo.LoaiPhong)
INSERT INTO dbo.LoaiPhong (TenLoai, GiaMoiDem, MoTa) VALUES
(N'Standard', 350000, N'Phòng tiêu chuẩn, 1 giường đôi'),
(N'Deluxe', 550000, N'Phòng rộng, có ban công'),
(N'Family', 800000, N'Phòng gia đình, 2 giường');
GO
IF NOT EXISTS (SELECT 1 FROM dbo.Phong)
INSERT INTO dbo.Phong (SoPhong, TangSo, TinhTrang, HinhAnh, MaLoai) VALUES
('101', 1, N'Trống', NULL, 1),
('202', 2, N'Đang ở', NULL, 2),
('303', 3, N'Đang dọn', NULL, 3);
GO
