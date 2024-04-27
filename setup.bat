setlocal

set "relative_folder=.\Diplomeocy\Web\Scripts"

cd /d "%~dp0%relative_folder%"

echo meow :3
npm i
npm i -g tailwindcss tailwind

endlocal
