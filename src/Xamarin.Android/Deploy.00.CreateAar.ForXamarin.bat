@echo off

rmdir Jars /S /Q
mkdir Jars

REM Delete existing jars
pushd SciChart.Android.Charting\Jars
del /S *.aar
popd

pushd SciChart.Android.Core\Jars
del /S *.aar
popd

pushd SciChart.Android.Data\Jars
del /S *.aar
popd

pushd SciChart.Android.Drawing\Jars
del /S *.aar
popd

pushd "..\SciChart.Android"

REM build release AARs
call gradlew assembleRelease -x testReleaseUnitTest zip
if NOT ERRORLEVEL == 0 goto :gradleError


REM Copy and unzip aars to output
"..\..\Lib\7Zip\7z.exe" e outputAar\sciChart.zip -o"..\Xamarin.Android\Jars"
popd

REM Copy AARs to JARs directory
echo f | XCOPY Jars\charting-release.aar SciChart.Android.Charting\Jars\charting-release.aar /Y
echo f | XCOPY Jars\core-release.aar SciChart.Android.Core\Jars\core-release.aar /Y
echo f | XCOPY Jars\data-release.aar SciChart.Android.Data\Jars\data-release.aar /Y
echo f | XCOPY Jars\drawing-release.aar SciChart.Android.Drawing\Jars\drawing-release.aar /Y

rmdir Jars /S /Q
pause(0)
echo SUCCESS!
exit /b

:gradleError

popd
echo Failed to build the AAR libs via Gradle
exit %ERRORLEVEL%
