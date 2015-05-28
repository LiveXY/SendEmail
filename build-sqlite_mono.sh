#!/bin/sh
MONO_IOMAP=all xbuild TH.Mailer.sln
cp ./EntityTool/Pub.Class.MonoSQLite.dll ./bin/
cp ./EntityTool/net20_sqlite_mono/*.* ./bin/
mono ./bin/Mailer.exe