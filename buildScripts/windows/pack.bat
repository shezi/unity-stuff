:: by: bison
:: for: Nothing-Simulator.com
:: with: 7-Zip
:: license: WTFPL
:: WARNING!

@echo .............................
@echo WARNING! MAKE SURE YOU ARE USING THIS SCRIPT FROM WITHIN THE DIRECTORY WITH YOUR GAME-FOLDERS
@echo cd INTO THE PARENT DIR THAT CONTAINS gamename_win, gamename_lin, gamename_mac

@echo off
SET GAMENAME=NothingSimulator
set PATH=%PATH%;C:\Program Files\7-Zip\
set /p VersionNumber= Enter Version-Number:
@echo on

cd win

7z a %GAMENAME%_win_%VersionNumber%.zip %GAMENAME%\
move %GAMENAME%_win_%VersionNumber%.zip ../

cd ../linux

7z a %GAMENAME%_linux_%VersionNumber%.tar %GAMENAME%\
7z a %GAMENAME%_linux_%VersionNumber%.tar.gz %GAMENAME%_linux_%VersionNumber%.tar
del %GAMENAME%_linux_%VersionNumber%.tar
move %GAMENAME%_linux_%VersionNumber%.tar.gz ../

cd ../mac

7z a %GAMENAME%_mac_%VersionNumber%.app.tar %GAMENAME%.app\
7z a %GAMENAME%_mac_%VersionNumber%.app.tar.gz %GAMENAME%_mac_%VersionNumber%.app.tar
del %GAMENAME%_mac_%VersionNumber%.app.tar
move %GAMENAME%_mac_%VersionNumber%.app.tar.gz ../
