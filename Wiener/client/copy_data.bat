@echo off

set SRC_PATH="%CD%\makes\bytes\basic.bytes"
set DST_PATH="%CD%\XXX\basic.bytes"

if exist %DST_PATH% del /s %DST_PATH% > nul
copy %SRC_PATH% %DST_PATH%

pause
