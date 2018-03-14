call "C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe" /ToolsVersion:14.0 /p:Configuration="Release" SciChart.Android.Xamarin.sln /p:Platform="Any CPU" /p:WarningLevel=0
if ERRORLEVEL 1 goto :msBuildError

:msBuildError
echo Failed to Build SciChart Xamarin Android bindings 
exit %ERRORLEVEL%