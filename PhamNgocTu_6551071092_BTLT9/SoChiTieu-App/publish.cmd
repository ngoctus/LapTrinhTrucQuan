@echo off
rem Publish Framework-Dependent, win-x64 ra thu muc "publish" (canh file nay).
cd /d "%~dp0"
dotnet publish SoChiTieu\SoChiTieu.csproj -c Release -r win-x64 --self-contained false -o "%~dp0publish"
echo.
echo Xong. Chep ca thu muc "publish" sang may khac (may do can .NET Desktop Runtime 10 x64).
echo Mo publish\appsettings.json de sua connection string cho dung may do, khong can build lai.
pause
