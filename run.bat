@echo off

REM Запуск API в новом окне
start "ProductApi" cmd /k "cd /d C:\My_User\Documents\Code\projects\c sharp\RemoteProject\ProductApi && dotnet run"

REM Ждем 10 секунд для запуска API
timeout /t 10 /nobreak >nul

REM Запуск Web в новом окне
start "ProductWeb" cmd /k "cd /d C:\My_User\Documents\Code\projects\c sharp\RemoteProject\ProductWeb && dotnet run"

REM Ждем 5 секунд для запуска Web
timeout /t 5 /nobreak >nul

REM Открываем Chrome
start "" "C:\Program Files\Google\Chrome\Application\chrome.exe" "https://localhost:7166/"

exit
