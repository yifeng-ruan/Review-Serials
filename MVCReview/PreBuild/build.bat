set ProjectDir=%1
set OutDir=%2

REM call npm install

call %ProjectDir%PreBuild\copyenv.bat %ProjectDir% %OutDir%