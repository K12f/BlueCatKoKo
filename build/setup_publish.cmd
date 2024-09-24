cd /d %~dp0
set app_dir=../src/BlueCatKoKo.Ui
set app_bin_dir=..\src\BlueCatKoKo.Ui\bin\Release\net8.0-windows\publish
set app_name=BlueCatKoKo.Ui
set setup_name=BlueCatKoKo
set tempfolder=%~dp0dist

mkdir %tempfolder%\%app_name%

@echo [prepare somethings]
for /f "usebackq tokens=*" %%i in (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -latest -property installationPath`) do set "path=%path%;%%i\MSBuild\Current\Bin;%%i\Common7\IDE"

@echo [prepare version]
cd /d %app_dir%
set "script=Get-Content "%app_name%.csproj" | Select-String -Pattern 'AssemblyVersion\>(.*)\<\/AssemblyVersion' | ForEach-Object { $_.Matches.Groups[1].Value }"
for /f "usebackq delims=" %%i in (`powershell -NoLogo -NoProfile -Command "%script%"`) do set version=%%i
echo current version is %version%
if "%b%"=="" ( set "b=%version%" )

echo [build app using vs2022]
cd /d %~dp0
rd /s /q %app_bin_dir%
cd /d %app_dir%
cd ..\
dotnet restore
dotnet publish -c Release -p:PublishProfile=FolderProfile

echo [pack app using 7z]
cd /d %~dp0
rd /s /q %tempfolder%
cd /d %app_bin_dir%
xcopy * "%tempfolder%\%app_name%" /E /C /I /Y

cd /d %~dp0
MicaSetup.Tools\7-Zip\7z a publish.7z %tempfolder%\%app_name%\* -t7z -mx=5 -mf=BCJ2 -r -y
copy /y publish.7z .\MicaSetup\Resources\Setups\publish.7z
move publish.7z %setup_name%_v%version%.7z
rd /s /q %tempfolder%

@echo [build uninst using vs2022]
msbuild MicaSetup\MicaSetup.Uninst.csproj /t:Rebuild /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /restore

@echo [build setup using vs2022]
copy /y .\MicaSetup\bin\Release\net472\MicaSetup.exe .\MicaSetup\Resources\Setups\Uninst.exe
msbuild MicaSetup\MicaSetup.csproj /t:Build /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /restore

@echo [finish]
cd /d %~dp0
dir
copy /y .\MicaSetup\bin\Release\net472\MicaSetup.exe .\
move MicaSetup.exe %setup_name%_Setup_v%version%.exe

@pause
