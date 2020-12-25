del *.zip
rmdir /S /Q ArmsArmor

mkdir ArmsArmor || goto :error
xcopy ArmsArmor.dll ArmsArmor || goto :error
xcopy ..\..\..\Info.json ArmsArmor || goto :error
"C:\Program Files\7-Zip\7z.exe" a ArmsArmor.zip ArmsArmor || goto :error

"C:\Program Files\7-Zip\7z.exe" a ArmsArmor-Source.zip ..\..\*.cs ..\..\*\*.cs || goto :error

goto :EOF

:error
echo Failed with error #%errorlevel%.
exit /b %errorlevel%
