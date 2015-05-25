EntityTool\EntityTool-Mailer-Sqlite.exe

if exist "C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" "C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" TH.Mailer.sln /build Release
if exist "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe" TH.Mailer.sln /build Release

copy EntityTool\Pub.Class.SQLite.dll bin\


del /a /s /q /f bin\*.pdb
del /a /s /q /f bin\*.vshost.exe
del /a /s /q /f bin\*.vshost.exe.manifest
del /a /s /q /f bin\*.vshost.exe.config
del /a /s /q /f bin\Pub.Class.xml
del /a /s /q /f bin\Pub.Class.SqlServer.dll
del /a /s /q /f bin\Pub.Class.MonoSQLite.dll
del /a /s /q /f bin\sqlite3.dll


copy EntityTool\net20_sqlite_x64\*.* bin\


start bin\MailerUI.exe