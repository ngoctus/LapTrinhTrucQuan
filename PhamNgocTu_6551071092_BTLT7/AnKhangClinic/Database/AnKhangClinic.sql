-- Bài 4: Quản lý Lịch khám bệnh - Phòng khám tư An Khang Clinic
IF DB_ID(N'AnKhangClinicDB') IS NULL
    CREATE DATABASE AnKhangClinicDB;
GO
USE AnKhangClinicDB;
GO
IF OBJECT_ID(N'dbo.BacSi', N'U') IS NULL
CREATE TABLE dbo.BacSi
(
    MaBS       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_BacSi PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100) NULL,
    SDT        VARCHAR(15) NULL
);
GO
IF OBJECT_ID(N'dbo.LichKham', N'U') IS NULL
CREATE TABLE dbo.LichKham
(
    MaLich      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LichKham PRIMARY KEY,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    SDT         VARCHAR(15) NULL,
    NgayKham    DATE NULL,
    GioKham     TIME(0) NULL,
    MaBS        INT NULL CONSTRAINT FK_LichKham_BacSi FOREIGN KEY REFERENCES dbo.BacSi(MaBS),
    TrangThai   NVARCHAR(20) NULL CONSTRAINT CK_LichKham_TrangThai CHECK (TrangThai IN (N'Chờ khám', N'Đã khám', N'Đã hủy'))
);
GO
IF NOT EXISTS (SELECT 1 FROM dbo.BacSi)
INSERT INTO dbo.BacSi (HoTen, ChuyenKhoa, SDT) VALUES
(N'Nguyễn Văn Hùng', N'Nội tổng quát', '0901111222'),
(N'Trần Thị Lan', N'Nhi khoa', '0902222333'),
(N'Lê Quốc Minh', N'Tai Mũi Họng', '0903333444');
GO
IF NOT EXISTS (SELECT 1 FROM dbo.LichKham)
INSERT INTO dbo.LichKham (TenBenhNhan, SDT, NgayKham, GioKham, MaBS, TrangThai) VALUES
(N'Phạm Thị Hoa', '0911000111', CAST(GETDATE() AS DATE), '09:00', 1, N'Chờ khám'),
(N'Võ Văn Nam', '0911000222', DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), '14:30', 2, N'Chờ khám');
GO
