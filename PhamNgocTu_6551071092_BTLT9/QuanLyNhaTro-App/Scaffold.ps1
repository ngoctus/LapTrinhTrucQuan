# Scaffold EF Core Database First (chạy sau khi CSDL QL_NhaTro đã được tạo - mở ứng dụng 1 lần hoặc chạy QuanLyNhaTro\Database\QL_NhaTro.sql trong SSMS)
# Cần công cụ: dotnet tool install --global dotnet-ef
Set-Location "$PSScriptRoot\QuanLyNhaTro"
dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=QL_NhaTro;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context QlNhaTroContext --force
