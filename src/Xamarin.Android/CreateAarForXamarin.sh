#!/bin/bash

rm -rf Jars
mkdir Jars

# Delete existing jars
pushd SciChart.Android.Charting/Jars
find . -name \*aar -delete
popd

pushd SciChart.Android.Core/Jars
find . -name \*aar -delete
popd

pushd SciChart.Android.Data/Jars
find . -name \*aar -delete
popd

pushd SciChart.Android.Drawing/Jars
find . -name \*aar -delete
popd

pushd ../SciChart.Android

# build release AARs
gradle assembleRelease -x testReleaseUnitTest zip


# Copy and unzip aars to output
# ”..\..\Lib\7Zip\7z.exe" e outputAar\sciChart.zip -o"..\Xamarin.Android\Jars"
unzip outputAar/sciChart.zip -d ../Xamarin.Android/Jars
popd

# Copy AARs to JARs directory
cp Jars/charting-release.aar SciChart.Android.Charting/Jars/charting-release.aar 
cp Jars/core-release.aar SciChart.Android.Core/Jars/core-release.aar 
cp Jars/data-release.aar SciChart.Android.Data/Jars/data-release.aar 
cp Jars/drawing-release.aar SciChart.Android.Drawing/Jars/drawing-release.aar 

rm -rf Jars