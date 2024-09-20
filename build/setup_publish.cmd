cd /d %~dp0
set app_dir=../src/BlueCatKoKo.Ui
set app_bin_dir=..\src\BlueCatKoKo.Ui\bin\Release\net8.0-windows\publish
set app_name=BlueCatKoKo

@echo [prepare somethings]
del MicaSetup.exe
for /f "usebackq tokens=*" %%i in (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -latest -property installationPath`) do set "path=%path%;%%i\MSBuild\Current\Bin;%%i\Common7\IDE"

@echo [prepare version]
cd /d %app_dir%
set "script=Get-Content 'BlueCatKoKo.Ui.csproj' | Select-String -Pattern 'AssemblyVersion\>(.*)\<\/AssemblyVersion' | ForEach-Object { $_.Matches.Groups[1].Value }"
for /f "usebackq delims=" %%i in (`powershell -NoLogo -NoProfile -Command "%script%"`) do set version=%%i
echo current version is %version%
if "%b%"=="" ( set "b=%version%" )

echo [build app using vs2022]
cd ..\src\
dotnet restore
dotnet publish -c Release -p:PublishProfile=FolderProfile
cd /d %~dp0

echo [pack app using 7z]
del %app_dir%
MicaSetup.Tools\7-Zip\7z a publish.7z %app_dir%\* -t7z -mx=5 -mf=BCJ2 -r -y
copy /y publish.7z .\MicaSetup\Resources\Setups\publish.7z
move publish.7z BlueCatKoKo_v%version%.7z

@echo [build uninst using vs2022]
msbuild MicaSetup\MicaSetup.Uninst.csproj /t:Rebuild /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /restore

@echo [build setup using vs2022]
copy /y .\MicaSetup\bin\Release\net472\MicaSetup.exe .\MicaSetup\Resources\Setups\Uninst.exe
msbuild MicaSetup\MicaSetup.csproj /t:Build /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /restore

@echo [finish]
del /f /q MicaSetup.exe
copy /y .\MicaSetup\bin\Release\net472\MicaSetup.exe .\
move MicaSetup.exe BlueCatKoKoSetup_v%version%.exe

@pause
