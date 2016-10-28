@echo off

set PROJECT=-projectPath 
set PROJECT_PATH="%USERPROFILE%\Documents\NothingSimulator"

set WIN_PATH="%USERPROFILE%\Documents\Projekte\NothingSimulator\builds\win\NothingSimulator\NothingSimulator.exe"
set OSX_PATH="%USERPROFILE%\Documents\Projekte\NothingSimulator\builds\mac\NothingSimulator.app"
 
@REM With Unity 4 we now have Linux
::set LINUX_PATH="%USERPROFILE%\Documents\Projekte\NothingSimulator\builds\linux\NothingSimulator\NothingSimulator.x86"
::set LINUX64_PATH="%USERPROFILE%\Documents\Projekte\NothingSimulator\builds\linux\NothingSimulator\NothingSimulator.x86_64"
set LINUX_U_PATH="%USERPROFILE%\Documents\Projekte\NothingSimulator\builds\linux\NothingSimulator\NothingSimulator."

@REM Common options
set BATCH=-batchmode
set QUIT=-quit
 
@REM Builds:
set WIN=-buildWindowsPlayer %WIN_PATH%
set OSX=-buildOSXPlayer %OSX_PATH%
set LINUX_U=-buildLinuxUniversalPlayer %LINUX_U_PATH%
::set LINUX=-buildLinux32Player %LINUX_PATH%
::set LINUX64=-buildLinux64Player %LINUX64_PATH%


@REM Win32 build
echo Running Win Build for: %PROJECT_PATH%
echo "%PROGRAMFILES%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %WIN%
"%ProgramFiles(x86)%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %WIN%
 
@REM OSX build
echo Running OSX Build for: %PROJECT_PATH%
echo "%PROGRAMFILES%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %OSX%
"%ProgramFiles(x86)%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %OSX%
 
::@REM Linux build
::echo Running Linux Build for: %PROJECT_PATH%
::echo "%PROGRAMFILES%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %LINUX%
::"%ProgramFiles(x86)%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %LINUX%
 
::@REM Linux 64-bit build
::echo Running Linux Build for: %PROJECT_PATH%
::echo "%PROGRAMFILES%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %LINUX64%
::"%ProgramFiles(x86)%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %LINUX64%
 
@REM Linux 32-64-bit build
echo Running Linux Build for: %PROJECT_PATH%
echo "%PROGRAMFILES%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %LINUX_U%
"%ProgramFiles(x86)%\Unity\Editor\Unity.exe" %BATCH% %QUIT% %PROJECT% %PROJECT_PATH% %LINUX_U%