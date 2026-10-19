/* =====================================================================
   Tao CSDL QL_ChiTieu + bang ChiTieu + du lieu mau (SQL Server)
   Chay an toan nhieu lan: khong xoa du lieu, chi them mau khi bang rong.
   Ngay chi mau tinh theo ngay hien tai de loc "thang nay" co du lieu.
   ===================================================================== */
IF DB_ID(N'QL_ChiTieu') IS NULL
    CREATE DATABASE QL_ChiTieu;
GO

USE QL_ChiTieu;
GO

IF OBJECT_ID(N'dbo.ChiTieu', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTieu
    (
        MaCT    int            IDENTITY(1,1) NOT NULL CONSTRAINT PK_ChiTieu PRIMARY KEY,
        NgayChi date           NOT NULL,
        NoiDung nvarchar(100)  NOT NULL,
        LoaiChi nvarchar(30)   NOT NULL,
        SoTien  decimal(18, 0) NOT NULL CONSTRAINT CK_ChiTieu_SoTien CHECK (SoTien > 0),
        GhiChu  nvarchar(200)  NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.ChiTieu)
BEGIN
    INSERT INTO dbo.ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu)
    SELECT DATEADD(DAY, -v.SoNgayTruoc, CAST(GETDATE() AS date)), v.NoiDung, v.LoaiChi, v.SoTien, v.GhiChu
    FROM (VALUES
        (0,  N'Ăn sáng phở bò',          N'Ăn uống', 45000,  N'Quán đầu ngõ'),
        (0,  N'Đổ xăng xe máy',          N'Đi lại',  70000,  NULL),
        (1,  N'Cà phê với bạn',          N'Ăn uống', 35000,  NULL),
        (1,  N'Mua giáo trình CSDL',     N'Học tập', 120000, N'Giáo trình môn Cơ sở dữ liệu'),
        (2,  N'Vé xem phim',             N'Giải trí', 90000, N'Đi cùng nhóm bạn'),
        (3,  N'Cơm trưa căng tin',       N'Ăn uống', 30000,  NULL),
        (4,  N'Vé xe buýt tháng',        N'Đi lại',  140000, NULL),
        (5,  N'In tài liệu làm bài nhóm', N'Học tập', 25000, NULL),
        (6,  N'Trà sữa',                 N'Ăn uống', 48000,  N'Sinh nhật bạn'),
        (8,  N'Nạp game',                N'Giải trí', 150000, NULL),
        (10, N'Mua quà tặng',            N'Khác',    200000, N'Quà sinh nhật'),
        (12, N'Ăn lẩu liên hoan lớp',    N'Ăn uống', 180000, N'Chia đều cả lớp')
    ) AS v(SoNgayTruoc, NoiDung, LoaiChi, SoTien, GhiChu);
END
GO

SELECT * FROM dbo.ChiTieu ORDER BY NgayChi DESC, MaCT DESC;
GO
