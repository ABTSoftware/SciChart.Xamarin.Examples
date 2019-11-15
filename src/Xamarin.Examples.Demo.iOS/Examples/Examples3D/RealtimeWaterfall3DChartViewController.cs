using System.Collections.Generic;
using System.Timers;
using Xamarin.Examples.Demo.Data;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Realtime Waterfall 3D", description: "Update a Waterfall Chart in real-time", icon: ExampleIcon.RealTime)]
    class CreateRealtimeWaterfall3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        private const int PointsPerSlice = 128;
        private const int SliceCount = 10;

        private const int TimerInterval = 25;
        private volatile bool _isRunning = false;
        private Timer _timer;

        private int _tick = 0;

        private List<List<double>> _fftData;

        private readonly WaterfallDataSeries3D<double, double, double> _dataSeries3D = new WaterfallDataSeries3D<double, double, double>(PointsPerSlice, SliceCount)
        {
            StartX = 10d,
            StepX = 1d,
            StartZ = 25d,
            StepZ = 10d
        };

        protected override void InitExample()
        {
            _fftData = DataManager.Instance.LoadFFT();

            FillDataSeries(_dataSeries3D);

            var rSeries3D = new SCIWaterfallRenderableSeries3D
            {
                DataSeries = _dataSeries3D,
                StrokeThickness = 1f,
                SliceThickness = 5f,
                YColorMapping = new SCIGradientColorPalette(
                    new[] { ColorUtil.Red, ColorUtil.Orange, ColorUtil.Yellow, ColorUtil.GreenYellow, ColorUtil.DarkGreen },
                    new[] { 0, .25f, .5f, .75f, 1 }),
                YStrokeColorMapping = new SCIGradientColorPalette(
                    new[] { ColorUtil.Crimson, ColorUtil.DarkOrange, ColorUtil.LimeGreen, ColorUtil.LimeGreen },
                    new[] { 0, 0.33f, 0.67f, 1 }),
                Opacity = 0.8f,
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D();
                Surface.YAxis = new SCINumericAxis3D();
                Surface.ZAxis = new SCINumericAxis3D();
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
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
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            InvokeOnMainThread(() =>
            {
                if (!_isRunning) return;

                FillDataSeries(_dataSeries3D);
            });
        }

        private void FillDataSeries(WaterfallDataSeries3D<double, double, double> ds)
        {
            var index = _tick++ % _fftData.Count;

            ds.PushRow(_fftData[index]);
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Pause();
        }
    }
}