@echo off

del /S SciChart.Android.Core\\Jars\\*.aar
del /S SciChart.Android.Data\\Jars\\*.aar
del /S SciChart.Android.Drawing\\Jars\\*.aar
del /S SciChart.Android.Charting\\Jars\\*.aar

copy core-release.aar SciChart.Android.Core\\Jars\\
copy data-release.aar SciChart.Android.Data\\Jars\\
copy drawing-release.aar SciChart.Android.Drawing\\Jars\\
copy charting-release.aar SciChart.Android.Charting\\Jars\\
