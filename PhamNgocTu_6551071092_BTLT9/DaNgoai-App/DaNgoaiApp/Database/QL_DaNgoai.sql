-- Chạy script này trong SSMS (kết nối .\SQLEXPRESS) hoặc:
--   sqlcmd -S .\SQLEXPRESS -E -i QL_DaNgoai.sql
IF DB_ID(N'QL_DaNgoai') IS NULL
    CREATE DATABASE QL_DaNgoai;
GO
USE QL_DaNgoai;
GO
IF OBJECT_ID(N'dbo.ChuyenDi', N'U') IS NULL
CREATE TABLE dbo.ChuyenDi
(
    MaChuyen    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_ChuyenDi PRIMARY KEY,
    TenChuyen   nvarchar(100) NOT NULL,
    DiaDiem     nvarchar(100) NOT NULL,
    NgayDi      date          NOT NULL,
    SoNguoi     int           NOT NULL CONSTRAINT CK_ChuyenDi_SoNguoi CHECK (SoNguoi >= 1),
    NganSach    decimal(18,0) NOT NULL CONSTRAINT CK_ChuyenDi_NganSach CHECK (NganSach >= 0),
    PhuongTien  nvarchar(30)  NOT NULL,
    DaHoanThanh bit           NOT NULL CONSTRAINT DF_ChuyenDi_DaHoanThanh DEFAULT (0),
    GhiChu      nvarchar(200) NULL
);
GO
IF NOT EXISTS (SELECT 1 FROM dbo.ChuyenDi)
BEGIN
    DECLARE @t date = CAST(GETDATE() AS date);
    INSERT INTO dbo.ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
    (N'Tắm biển Vũng Tàu',       N'Vũng Tàu',  DATEADD(DAY, 3,  @t), 6,  2400000,  N'Xe máy',   0, N'Đi sớm tránh kẹt xe'),
    (N'Cuối tuần ở Đà Lạt',      N'Đà Lạt',    DATEADD(DAY, 6,  @t), 4,  4500000,  N'Ô tô',     0, N'Săn mây, cà phê view đồi'),
    (N'Chinh phục Sa Pa',        N'Sa Pa',     DATEADD(DAY, 9,  @t), 5,  9800000,  N'Tàu hỏa',  0, N'Mang áo ấm'),
    (N'Nha Trang nghỉ dưỡng',    N'Nha Trang', DATEADD(DAY, 11, @t), 8,  12000000, N'Xe khách', 0, NULL),
    (N'Phố cổ Hội An',           N'Hội An',    DATEADD(DAY, 14, @t), 3,  6500000,  N'Ô tô',     0, N'Thả đèn hoa đăng'),
    (N'Cung đường Hà Giang',     N'Hà Giang',  DATEADD(DAY, 17, @t), 4,  7200000,  N'Xe máy',   0, N'Kiểm tra xe trước khi đi'),
    (N'Biển đảo Phú Quốc',       N'Phú Quốc',  DATEADD(DAY, 21, @t), 6,  15000000, N'Ô tô',     0, N'Đặt vé phà trước'),
    (N'Khám phá cố đô Huế',      N'Huế',       DATEADD(DAY, 28, @t), 5,  8000000,  N'Xe khách', 0, NULL);
END
GO
