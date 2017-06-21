@echo off

REM Build JavaDocs
pushd "..\Examples"
CALL gradlew generateReleaseJavadoc
if NOT ERRORLEVEL == 0 goto :gradleError
echo JavaDocs Build Successful
popd

REM Delete existing JavaDocs
RMDIR SciChart.Core\Jars\docs /S /Q
RMDIR SciChart.Drawing\Jars\docs /S /Q
RMDIR SciChart.Data\Jars\docs /S /Q
RMDIR SciChart.Charting\Jars\docs /S /Q

REM Copy JavaDocs
echo d | XCOPY "..\Examples\outputDoc\core" "SciChart.Core\Jars\docs" /S
echo d | XCOPY "..\Examples\outputDoc\drawing" "SciChart.Drawing\Jars\docs" /S
echo d | XCOPY "..\Examples\outputDoc\data" "SciChart.Data\Jars\docs" /S
echo d | XCOPY "..\Examples\outputDoc\charting" "SciChart.Charting\Jars\docs" /S

REM Delete generated JavaDocs
RMDIR "..\Examples\outputDoc" /S /Q

exit 0

:gradleError
echo Failed to build JavaDocs via Gradle
exit %ERRORLEVEL%
popd
