-- Bài 2: Quản lý Hội viên - Phòng tập Gym FitZone
IF DB_ID(N'FitZoneDB') IS NULL
    CREATE DATABASE FitZoneDB;
GO
USE FitZoneDB;
GO
IF OBJECT_ID(N'dbo.HoiVien', N'U') IS NULL
CREATE TABLE dbo.HoiVien
(
    MaHV          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HoiVien PRIMARY KEY,
    HoTen         NVARCHAR(100) NOT NULL,
    GioiTinh      BIT NULL,                 -- 1 = Nam, 0 = Nữ
    NgaySinh      DATE NULL,
    SDT           VARCHAR(15) NULL,
    Email         VARCHAR(100) NULL,
    HangThanhVien NVARCHAR(20) NULL CONSTRAINT CK_HoiVien_Hang CHECK (HangThanhVien IN (N'Basic', N'VIP', N'Premium')),
    NgayDangKy    DATETIME NULL CONSTRAINT DF_HoiVien_NgayDangKy DEFAULT (GETDATE()),
    TrangThai     BIT NULL
);
GO
IF NOT EXISTS (SELECT 1 FROM dbo.HoiVien)
INSERT INTO dbo.HoiVien (HoTen, GioiTinh, NgaySinh, SDT, Email, HangThanhVien, TrangThai) VALUES
(N'Nguyễn Văn An', 1, '2000-05-10', '0901234567', 'an@gmail.com', N'Basic', 1),
(N'Trần Thị Bình', 0, '1998-11-22', '0912345678', 'binh@gmail.com', N'VIP', 1),
(N'Lê Minh Châu', 0, '1995-03-01', '0987654321', 'chau@gmail.com', N'Premium', 0);
GO
