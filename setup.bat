@echo off
setlocal

set "relative_folder=.\Diplomeocy\Web\"

cd /d "%~dp0%relative_folder%"

echo meow :3 > CON
npm i > nul

endlocal
