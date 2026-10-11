-- Bài 1: Quản lý Thể loại Sách - Nhà sách mini Tri Thức Books
-- Chạy script này trong SQL Server (SSMS) trước khi chạy ứng dụng.
IF DB_ID(N'TriThucBooksDB') IS NULL
    CREATE DATABASE TriThucBooksDB;
GO
USE TriThucBooksDB;
GO
IF OBJECT_ID(N'dbo.TheLoaiSach', N'U') IS NULL
CREATE TABLE dbo.TheLoaiSach
(
    MaTL        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TheLoaiSach PRIMARY KEY,
    TenTheLoai  NVARCHAR(100) NOT NULL CONSTRAINT UQ_TheLoaiSach_TenTheLoai UNIQUE,
    MoTa        NVARCHAR(255) NULL,
    SoLuongSach INT NULL CONSTRAINT DF_TheLoaiSach_SoLuongSach DEFAULT (0),
    NgayTao     DATETIME NULL CONSTRAINT DF_TheLoaiSach_NgayTao DEFAULT (GETDATE())
);
GO
-- Dữ liệu mẫu (tuỳ chọn)
IF NOT EXISTS (SELECT 1 FROM dbo.TheLoaiSach)
INSERT INTO dbo.TheLoaiSach (TenTheLoai, MoTa, SoLuongSach) VALUES
(N'Văn học', N'Tiểu thuyết, truyện ngắn, thơ', 120),
(N'Kinh tế', N'Quản trị, tài chính, khởi nghiệp', 80),
(N'Thiếu nhi', N'Truyện tranh, sách tô màu', 60);
GO
