
# SciChart for Xamarin.iOS & Xamarin.Android
SciChart Xamarin, source code for our High Performance Scientific &amp; Financial Charting on Xamarin.
This repository contains v4.x of SciChart for Xamarin.iOS and Xamarin.Android:
 
### NOTE: NuGet Feed Setup & Build Instructions 
[SciChart.Android](https://www.myget.org/feed/abtsoftware/package/nuget/SciChart.Android) and [SciChart.iOS](https://www.myget.org/feed/abtsoftware/package/nuget/SciChart.iOS) Xamarin binding libraries are hosted by a [MyGet NuGet feed](https://www.myget.org/gallery/abtsoftware). **You will need to setup this NuGet feed before you can build the Xamarin examples**. 

Instructions for setting up the SciChart NuGet feed can be found at [SciChart.com: Getting Nightly Builds with NuGet](http://support.scichart.com/index.php?/Knowledgebase/Article/View/17232/37/getting-nightly-builds-with-nuget). 

After that, you can include SciChart packages in your application with the following NuGet Command:

```
> Install-Package SciChart.iOS // iOS
> Install-Package SciChart.Android // Android
```

# SciChart.Xamarin.Examples
Xamarin Examples for [SciChart](https://www.scichart.com): High Performance Realtime [iOS Chart Library](https://www.scichart.com/ios-chart-features) and [Android Chart Library](https://www.scichart.com/ios-chart-features).

![Xamarin Charts](https://www.scichart.com/wp-content/uploads/2017/06/scichart-iOS-collage-min.png)

Examples are provided for `Xamarin.iOS`, `Xamarin.Android` and support Visual Studio for both macOS and Windows. 
If you are looking for other platforms then please see here:
- [Android Charts](https://github.com/ABTSoftware/SciChart.Android.Examples) (Java & Kotlin)
- [iOS Charts](https://github.com/ABTSoftware/SciChart.iOS.Examples) (Objective-C & Swift)
- [WPF Charts](https://github.com/ABTSoftware/SciChart.WPF.Examples) (C# / WPF)

_Please ensure you have the latest Stable versions of Xamarin as they can and do often release bug fixes for crashes, hangs and the like!_

![Xamarin Stock Charts](https://www.scichart.com/wp-content/uploads/2017/07/xamarin-realtime-ticking-stock-charts.png)
![Xamarin Stacked Grouped Column Charts](https://www.scichart.com/wp-content/uploads/2017/07/xamarin-dashboard-style.png)
![Xamarin Line Charts](https://www.scichart.com/wp-content/uploads/2017/07/xamarin-performance-demo.png) 
![Xamarin Scatter Charts](https://www.scichart.com/wp-content/uploads/2017/07/xamarin-scatter-chart.png)
![Xamarin Heatmap Spectrogram Chart](https://www.scichart.com/wp-content/uploads/2017/07/xamarin-heatmap-chart-showcase.png)

# Repository Contents

## SciChart Xamarin Examples
The SciChart iOS/Android Xamarin Examples contain developer example code in C# to help you get started as soon as possible with SciChart iOS & Android. 

![Xamarin Chart Examples Code](https://www.scichart.com/wp-content/uploads/2017/06/SciChart-Xamarin-iOS-Simulator-Home.png)

Chart Types include:

#### Xamarin.iOS

* [Xamarin.iOS Band Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/BandChartView.cs)
* [Xamarin.iOS Bubble Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/BubbleChartView.cs)
* [Xamarin.iOS Candlestick Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/CandlestickChartView.cs)
* [Xamarin.iOS Error Bars Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/ErrorBarsChartView.cs)
* [Xamarin.iOS Fan Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/FanChartView.cs)
* [Xamarin.iOS Heatmap Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/HeatmapChartView.cs)
* [Xamarin.iOS Impulse / Stem Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/ImpulseChartView.cs)
* [Xamarin.iOS Line Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/LineChartView.cs)
* [Xamarin.iOS Mountain / Area Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/MountainChartView.cs)
* [Xamarin.iOS Scatter Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/ScatterChartView.cs)
* [Xamarin.iOS Stacked Bar Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/StackedBarChartView.cs)
* [Xamarin.iOS Stacked Column Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/StackedColumnChartView.cs)
* [Xamarin.iOS Grouped Column Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/StackedColumnSideBySideView.cs)
* [Xamarin.iOS Stacked Mountain Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.iOS/Views/Examples/StackedMountainChartView.cs)

#### Xamarin.Android

* [Xamarin.Android Band Chart] (https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/BandChartFragment.cs) 
* [Xamarin.Android Bubble Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/BubbleChartFragment.cs)
* [Xamarin.Android Candlestick Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/CandlestickChartFragment.cs)
* [Xamarin.Android Heatmap Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/HeatmapChartFragment.cs)
* [Xamarin.Android Impulse / Stem Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/ImpulseChartFragment.cs)
* [Xamarin.Android Line Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/LineChartFragment.cs)
* [Xamarin.Android Animted Line Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/AnimatingLineChartFragment.cs)
* [Xamarin.Android Mountain / Area Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/MountainChartFragment.cs)
* [Xamarin.Android Scatter Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/ScatterChartFragment.cs)
* [Xamarin.Android Stacked Bar Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/StackedBarChartFragment.cs)
* [Xamarin.Android Stacked Column Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/StackedColumnChartFragment.cs)
* [Xamarin.Android Grouped Column Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/StackedColumnSideBySideFragment.cs)
* [Xamarin.Android Stacked Mountain Chart](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/StackedMountainChartFragment.cs)
* [Xamarin.Android Chart Annotations](https://github.com/ABTSoftware/SciChart.Xamarin.Examples/blob/master/src/Xamarin.Examples.Demo.Droid/Fragments/Examples/InteractionWithAnnotationsFragment.cs)

## Tech Support and Help 
SciChart iOS & Android is a commercial chart control with world-class tech support. If you need help integrating SciChart to your Xamarin iOS or Android apps, [Contact Us](https://www.scichart.com/contact-us) and we will do our best to help! 

*Enjoy! - @SciChart Team*

![SciChart iOS Chart Library Collage](https://www.scichart.com/wp-content/uploads/2017/04/ios-chart-examples-collage-perspective.jpg)
