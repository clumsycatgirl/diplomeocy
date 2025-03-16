setlocal

set "relative_folder=.\Scripts"

cd /d "%~dp0%relative_folder%"

echo meow :3
npm i
npm i -g tailwindcss tailwind

endlocal
