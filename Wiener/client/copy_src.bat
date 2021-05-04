@echo off

set SRC_PATH="%CD%\makes\csharp"
set DST_PATH="%CD%\XXX\csharp"

if exist %DST_PATH% rmdir /S /Q %DST_PATH%
mkdir %DST_PATH%

xcopy /E %SRC_PATH% %DST_PATH%

pause
