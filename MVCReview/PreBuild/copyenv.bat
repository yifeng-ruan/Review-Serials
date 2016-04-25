set ProjectDir=%1
set OutDir=%2

XCOPY %ProjectDir%\MyConfig\*.config %OutDir%\MyConfig /y /i