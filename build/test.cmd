set app_dir=../src/BlueCatKoKo.Ui
set app_bin_dir=..\src\BlueCatKoKo.Ui\bin\Release\net8.0-windows\publish
set app_name=BlueCatKoKo
set tempfolder=%~dp0dist\BlueCatKoKo

cd /d %~dp0
rd /s /q %tempfolder%

@pause