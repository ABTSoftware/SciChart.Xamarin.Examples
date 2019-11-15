using System;
using System.Timers;
using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [Example3DDefinition("Realtime 3D Geoid", description: "Update a Ellipsoid Mesh in real-time", icon: ExampleIcon.RealTime)]
    class RealtimeGeoid3DChartViewController : SingleChartViewController<SCIChartSurface3D>
    {
        private const int Size = 100;
        private const double HeightOffsetScale = 0.5;

        private const int TimerInterval = 20;
        private volatile bool _isRunning = false;
        private Timer _timer;
        private int _frames = 0;

        private readonly EllipsoidDataSeries3D<double> _dataSeries3D = new EllipsoidDataSeries3D<double>(Size, Size) { A = 6, B = 6, C = 6 };
        private readonly SCIDoubleValues _heightMap = new SCIDoubleValues();
        private readonly SCIDoubleValues _buffer = new SCIDoubleValues();

        protected override void InitExample()
        {
            GetGlobalHeatmap(_heightMap);
            _dataSeries3D.CopyFrom(_heightMap);

            var rSeries3D = new SCIFreeSurfaceRenderableSeries3D
            {
                DataSeries = _dataSeries3D,
                DrawMeshAs = SCIDrawMeshAs.SolidMesh,
                Stroke = 0x77228B22,
                ContourStroke = 0x77228B22,
                StrokeThickness = 2f,
                MeshColorPalette = new SCIGradientColorPalette(
                    new[] { ColorUtil.Sapphire, ColorUtil.Blue, ColorUtil.Cyan, ColorUtil.GreenYellow, ColorUtil.Yellow, ColorUtil.Red, ColorUtil.DarkRed },
                    new[] { 0, 0.1f, 0.3f, 0.5f, 0.7f, 0.9f, 1f }),
                PaletteMinimum = new SCIVector3(0, 6, 0),
                PaletteMaximum = new SCIVector3(0, 7, 0),
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-8, 8) };
                Surface.YAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-8, 8) };
                Surface.ZAxis = new SCINumericAxis3D { VisibleRange = new SCIDoubleRange(-8, 8) };
                Surface.RenderableSeries.Add(rSeries3D);
                Surface.ChartModifiers.Add(CreateDefault3DModifiers());

                Surface.Camera = new SCICamera3D();
                Surface.WorldDimensions = new SCIVector3(200, 200, 200);
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

                var freq = (Math.Sin(_frames++ * 0.1) + 1) / 2;
                var exp = freq * 10;

                var offset = _frames % Size;
                var count = _heightMap.Count;

                _buffer.Count = count;
                for (int i = 0; i < count; i++)
                {
                    var currentValueIndex = i + offset;
                    if(currentValueIndex >= count)
                    {
                        currentValueIndex -= count;
                    }

                    var currentValue = _heightMap.GetValueAt(currentValueIndex);
                    _buffer.Set(currentValue + Math.Pow(currentValue, exp) * HeightOffsetScale, i);
                }

                _dataSeries3D.CopyFrom(_buffer);
            });
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        private static SCIDoubleValues GetGlobalHeatmap(SCIDoubleValues heightMapValues)
        {
            var bitmap = new UIImage("example_globe_heightmap").ToBitmap();
            var stepU = bitmap.Width / Size;
            var stepV = bitmap.Height / Size;

            heightMapValues.Count = Size * Size;
            for (uint v = 0; v < Size; v++)
            {
                for (uint u = 0; u < Size; u++)
                {
                    var index = v * Size + u;
                    var x = u * stepU;
                    var y = v * stepV;

                    var pixel = bitmap.PixelAtX(x, y).ToUIColor().R();
                    heightMapValues.Set(pixel / 255d, (int)index);
                }
            }

            return heightMapValues;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Pause();
        }
    }
}