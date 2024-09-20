set app_dir=../src/BlueCatKoKo.Ui
cd /d %app_dir%
set "script=Get-Content 'BlueCatKoKo.Ui.csproj' | Select-String -Pattern 'AssemblyVersion\>(.*)\<\/AssemblyVersion' | ForEach-Object { $_.Matches.Groups[1].Value }"
for /f "usebackq delims=" %%i in (`powershell -NoLogo -NoProfile -Command "%script%"`) do set version=%%i
echo current version is %version%
if "%b%"=="" ( set "b=%version%" )
@pause
