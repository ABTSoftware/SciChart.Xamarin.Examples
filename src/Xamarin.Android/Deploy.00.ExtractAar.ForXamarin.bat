@echo off

SET build=%1

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

pushd artifacts
REM Copy and unzip aars to output
"..\..\..\Lib\7Zip\7z.exe" e SciChart_Android_r%build%.zip
popd

REM Copy AARs to JARs directory
echo f | XCOPY artifacts\charting-release.aar SciChart.Android.Charting\Jars\charting-release.aar /Y
echo f | XCOPY artifacts\core-release.aar SciChart.Android.Core\Jars\core-release.aar /Y
echo f | XCOPY artifacts\data-release.aar SciChart.Android.Data\Jars\data-release.aar /Y
echo f | XCOPY artifacts\drawing-release.aar SciChart.Android.Drawing\Jars\drawing-release.aar /Y

REM Remove extracted AARs from artifacts directory
pushd artifacts
del /S *.aar
popd

pause(0)
echo SUCCESS!
exit 0
