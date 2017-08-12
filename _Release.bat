C:\Factory\Tools\RDMD.exe /RC out

COPY C:\Factory\Program\Prime64\Prime64.exe out

FOR %%E IN (out\*.exe) DO (
	C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled "%%E"
)

COPY WPrime64\WPrime64\bin\Release\WPrime64.exe out
C:\Factory\Tools\xcp.exe doc out
C:\Factory\Tools\DirFltr.exe /EF out

C:\Factory\SubTools\zip.exe /O out Prime64

PAUSE
