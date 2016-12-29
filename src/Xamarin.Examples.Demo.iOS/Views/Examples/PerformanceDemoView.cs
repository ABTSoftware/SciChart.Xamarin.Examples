using System;
using SciChart.Examples.Demo.Fragments.Base;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using Xamarin.Examples.Demo.iOS.Views.Base;

namespace Xamarin.Examples.Demo.iOS.Views.Examples
{
    [ExampleDefinition("Performance Demo")]
    public class PerformanceDemoView : ExampleBaseView
    {
        private readonly SingleChartView _exampleView = SingleChartView.Create();

        public SCIChartSurface Surface;

        public override UIView ExampleView => _exampleView;

        //private static readonly int MaxPointCount = CalculateMaxPointCountToDisplay();
        //private const int TimerInterval = 10;
        //private const int BufferSize = 1000;

        //private readonly MovingAverage _maLow = new MovingAverage(200);
        //private readonly MovingAverage _maHigh = new MovingAverage(1000);

        //private int _xValue = 0;
        //private double _yValue = 10;

        //private readonly IntegerValues _xValues = new IntegerValues(BufferSize);
        //private readonly FloatValues _firstYValues = new FloatValues(BufferSize);
        //private readonly FloatValues _secondYValues = new FloatValues(BufferSize);
        //private readonly FloatValues _thirdYValues = new FloatValues(BufferSize);

        //private readonly XyDataSeries<int, float> _mainSeries = new XyDataSeries<int, float>();
        //private readonly XyDataSeries<int, float> _maLowSeries = new XyDataSeries<int, float>();
        //private readonly XyDataSeries<int, float> _maHighSeries = new XyDataSeries<int, float>();

        //private readonly Random _random = new Random();

        //private volatile bool _isRunning = false;
        //private Timer _timer;
        protected override void UpdateFrame()
        {
            throw new NotImplementedException();
        }

        protected override void InitExampleInternal()
        {
            throw new NotImplementedException();
        }
    }
}
