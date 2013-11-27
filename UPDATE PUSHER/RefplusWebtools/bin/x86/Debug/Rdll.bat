REGSVR32  "KFRefplus.dll" -u /s
DEL KFRefplus.dll
DEL Interop.KFRefplus.dll
REN KFRefplus2.dll KFRefplus.dll
REN Interop.KFRefplus2.dll Interop.KFRefplus.dll
REGSVR32  "KFRefplus.dll" /s
REGSVR32  "pipes.dll" -u /s
DEL pipes.dll
DEL Interop.Pipes.dll
REN pipes2.dll pipes.dll
REN Interop.Pipes2.dll Interop.Pipes.dll
REGSVR32  "pipes.dll" /s
start 1242.exe
exit