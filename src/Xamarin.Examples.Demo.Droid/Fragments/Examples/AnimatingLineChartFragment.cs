using System;
using System.Timers;
using Android.Animation;
using Android.Views.Animations;
using Android.Widget;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;
using SciChart.Charting.Visuals.Rendering;
using SciChart.Core.Utility;
using SciChart.Data.Model;
using SciChart.Data.Numerics;
using SciChart.Data.Numerics.PointResamplers;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Animating Line Chart", description:"Demonstrates animating the latest X,Y value on a line chart", icon:ExampleIcon.LineChart)]
    public class AnimatingLineChartFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Realtime_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        private const int FifoCapacity = 50;
        private const long TimerInterval = 1000;
        private const double OneOverTimeInteval = 1.0/TimerInterval;
        private const double VisibleRangeMax = FifoCapacity*OneOverTimeInteval;
        private const double GrowBy = VisibleRangeMax*0.1;

        private readonly Random _random = new Random(42);

        private readonly XyDataSeries<double, double> _dataSeries = new XyDataSeries<double, double> {FifoCapacityValue = FifoCapacity};

        private volatile bool _isRunning;
        private readonly object _syncRoot = new object();
        private double _t;
        private double _yValue;
        private Timer _timer;

        private readonly DoubleRange _xVisibleRange = new DoubleRange(-GrowBy, VisibleRangeMax + GrowBy);

        protected override void InitExample()
        {
            View.FindViewById<Button>(Resource.Id.start).Click += (sender, args) => Start();
            View.FindViewById<Button>(Resource.Id.pause).Click += (sender, args) => Pause();
            View.FindViewById<Button>(Resource.Id.reset).Click += (sender, args) => Reset();

            using (Surface.SuspendUpdates())
            {
                var xAxis = new NumericAxis(Activity) {VisibleRange = _xVisibleRange, AutoRange = AutoRange.Never};
                var yAxis = new NumericAxis(Activity) {GrowBy = new DoubleRange(0.1, 0.1), AutoRange = AutoRange.Always};

                var rs = new AnimatingLineRenderableSeries
                {
                    DataSeries = _dataSeries,
                    StrokeStyle = new SolidPenStyle(0xFF4083B7, 3.ToDip(Activity))
                };

                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rs);
            }

            Start();
        }

        private void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _timer = new Timer(TimerInterval);
            _timer.Elapsed += OnTick;
            _timer.AutoReset = true;
            _timer.Start();

            Surface.InvalidateElement();
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;

            Surface.InvalidateElement();
        }

        private void Reset()
        {
            if (_isRunning)
                Pause();

            using (Surface.SuspendUpdates())
            {
                _dataSeries.Clear();
                _t = 0;
                _yValue = 0;
            }
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_timer)
            {
                if(!_isRunning) return;

                AppendData(_random);
            }
        }

        private void AppendData(Random random)
        {
            _yValue += random.NextDouble() - 0.5;

            _dataSeries.Append(_t, _yValue);

            _t += OneOverTimeInteval;

            if (_t > VisibleRangeMax)
                _xVisibleRange.SetMinMax(_xVisibleRange.Min + OneOverTimeInteval, _xVisibleRange.Max + OneOverTimeInteval);
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            Reset();
        }

        public override void InitExampleForUiTest()
        {
            base.InitExampleForUiTest();

            lock (_syncRoot)
            {
                Reset();

                var random = new Random(42);
                for (var i = 0; i < 20; i++)
                {
                    AppendData(random);
                }
            }
        }
    }

    class AnimatingLineRenderableSeries : FastLineRenderableSeries, Animator.IAnimatorListener, ValueAnimator.IAnimatorUpdateListener
    {
        private const float StartValue = 0f;
        private const float EndValue = 1f;
        private const long Duration = 1000;

        private double _fromX, _fromY, _toX, _toY;

        private readonly ValueAnimator _animator;

        private readonly ActionRunnable _animatorRestartRunnable;

        private volatile float _animatedFraction;
        private volatile bool _isUpdatesAllowes;

        public AnimatingLineRenderableSeries()
        {
            _animator = ValueAnimator.OfFloat(StartValue, EndValue);
            _animator.SetInterpolator(new DecelerateInterpolator());
            _animator.SetDuration(Duration);
            _animator.AddUpdateListener(this);
            _animator.AddListener(this);

            _animatorRestartRunnable = new ActionRunnable(() =>
            {
                if (_animator.IsRunning)
                    _animator.Cancel();

                _animator.Start();
            });
        }

        protected override void InternalUpdateRenderPassData(ISeriesRenderPassData renderPassDataToUpdate, IDataSeries dataSeries, ResamplingMode resamplingMode, IPointResamplerFactory factory)
        {
            base.InternalUpdateRenderPassData(renderPassDataToUpdate, dataSeries, resamplingMode, factory);

            if (renderPassDataToUpdate.PointsCount() < 2) return;

            var lineRenderPassData = (LineRenderPassData)renderPassDataToUpdate;

            var xValues = lineRenderPassData.XValues;
            var yValues = lineRenderPassData.YValues;

            var pointsCount = lineRenderPassData.PointsCount();
            _fromX = xValues.Get(pointsCount - 2);
            _fromY = yValues.Get(pointsCount - 2);
            _toX = xValues.Get(pointsCount - 1);
            _toY = yValues.Get(pointsCount - 1);


            xValues.Set(pointsCount - 1, _fromX);
            yValues.Set(pointsCount - 1, _fromY);

            _isUpdatesAllowes = false;

            Dispatcher.PostOnUiThread(_animatorRestartRunnable);
        }

        protected override void InternalUpdate(IAssetManager2D assetManager, RenderPassState renderPassState)
        {
            base.InternalUpdate(assetManager, renderPassState);

            if (!_isUpdatesAllowes) return;

            var currentRenderPassData = (LineRenderPassData)CurrentRenderPassData;

            var x = _fromX + (_toX - _fromX) * _animatedFraction;
            var y = InterpolateLinear(x, _fromX, _fromY, _toX, _toY);

            var indexToSet = currentRenderPassData.PointsCount() - 1;
            currentRenderPassData.XValues.Set(indexToSet, x);
            currentRenderPassData.YValues.Set(indexToSet, y);

            var xCoord = currentRenderPassData.XCoordinateCalculator.GetCoordinate(x);
            var yCoord = currentRenderPassData.YCoordinateCalculator.GetCoordinate(y);

            currentRenderPassData.XCoords.Set(indexToSet, xCoord);
            currentRenderPassData.YCoords.Set(indexToSet, yCoord);
        }

        private static double InterpolateLinear(double x, double x1, double y1, double x2, double y2)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }

        public void OnAnimationCancel(Animator animation)
        {
            _animatedFraction = StartValue;
            InvalidateElement();
        }

        public void OnAnimationEnd(Animator animation)
        {
            _animatedFraction = EndValue;
            InvalidateElement();
        }

        public void OnAnimationRepeat(Animator animation) { }

        public void OnAnimationStart(Animator animation)
        {
            _isUpdatesAllowes = true;

            _animatedFraction = StartValue;
            InvalidateElement();
        }

        public void OnAnimationUpdate(ValueAnimator animation)
        {
            _animatedFraction = animation.AnimatedFraction;
            InvalidateElement();
        }

        private class ActionRunnable : Java.Lang.Object, Java.Lang.IRunnable
        {
            private readonly Action _action;

            public ActionRunnable(Action action)
            {
                _action = action;
            }

            public void Run()
            {
                _action();
            }
        }
    }
}