@echo off
rem Database First: sinh lai DbContext + Model tu CSDL QL_ChiTieu (can chay Database\QL_ChiTieu.sql truoc).
rem Sua chuoi ket noi ben duoi cho dung may cua ban.
cd /d "%~dp0SoChiTieu"
dotnet tool update --global dotnet-ef
dotnet ef dbcontext scaffold "Server=localhost;Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --context QlChiTieuContext --context-dir Data --output-dir Models --table ChiTieu --no-onconfiguring --force
pause
