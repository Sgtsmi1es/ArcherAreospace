@echo off
setlocal enabledelayedexpansion

echo Building Argus KSP Mod...

REM >>> EDIT THIS to your dev KSP install <<<
set "KSP_DIR=C:\Users\Mleac\OneDrive\Desktop\Kerbal Space Program"

echo Using KSP directory: %KSP_DIR%

REM Sanity checks
for %%F in (
  "%KSP_DIR%\KSP_x64_Data\Managed\Assembly-CSharp.dll"
  "%KSP_DIR%\KSP_x64_Data\Managed\UnityEngine.dll"
  "%KSP_DIR%\KSP_x64_Data\Managed\UnityEngine.CoreModule.dll"
  "%KSP_DIR%\KSP_x64_Data\Managed\UnityEngine.UI.dll"
) do (
  if not exist "%%~fF" (
    echo [ERROR] Missing: %%~fF
    goto :eof
  )
)

REM Find MSBuild
set "MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
if not exist "%MSBUILD%" (
  echo [ERROR] MSBuild not found at %MSBUILD%
  goto :eof
)

echo.
echo Building project...
echo MSBuild command: "%MSBUILD%" Argus.csproj /p:Configuration=Release /p:KSP_DIR="%KSP_DIR%"
"%MSBUILD%" Argus.csproj /p:Configuration=Release /p:KSP_DIR="%KSP_DIR%"
if errorlevel 1 (
  echo.
  echo Build failed!
  echo.
  echo Press any key to continue...
  pause >nul
  goto :eof
)

echo.
echo Build succeeded!
echo.
echo Press any key to continue...
pause >nul
endlocal
