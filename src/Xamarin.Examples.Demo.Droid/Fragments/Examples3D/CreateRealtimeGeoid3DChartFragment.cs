using Android.Content;
using Android.Graphics;
using SciChart.Charting3D.Common.Math;
using SciChart.Charting3D.Model;
using SciChart.Charting3D.Model.DataSeries.FreeSurface;
using SciChart.Charting3D.Modifiers;
using SciChart.Charting3D.Visuals;
using SciChart.Charting3D.Visuals.Axes;
using SciChart.Charting3D.Visuals.Camera;
using SciChart.Charting3D.Visuals.RenderableSeries.Data;
using SciChart.Charting3D.Visuals.RenderableSeries.FreeSurface;
using SciChart.Core.Model;
using SciChart.Core.Utility;
using SciChart.Data.Model;
using Xamarin.Examples.Demo;
using System;
using System.Timers;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Color = System.Drawing.Color;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples3D
{
    [Example3DDefinition("Realtime 3D Geoid", description: "Update a Ellipsoid Mesh in real-time", icon: ExampleIcon.RealTime)]
    class CreateRealtimeGeoid3DChartFragment : ExampleBaseFragment
    {
        private const int Size = 100;
        private const double HeightOffsetScale = 0.5;

        public SciChartSurface3D Surface => View.FindViewById<SciChartSurface3D>(Resource.Id.chart3d);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_3D_Chart_Fragment;

        private const int TimerInterval = 33;
        private volatile bool _isRunning = false;
        private readonly object _syncRoot = new object();
        private Timer _timer;
        private int _frames = 0;

        private readonly EllipsoidDataSeries3D<double> _dataSeries3D = new EllipsoidDataSeries3D<double>(Size, Size);
        private readonly DoubleValues _heightMap = new DoubleValues();
        private readonly DoubleValues _buffer = new DoubleValues();

        protected override void InitExample()
        {
            GetGlobalHeatmap(Activity, _heightMap);

            _dataSeries3D.SetA(6d.FromComparable());
            _dataSeries3D.SetB(6d.FromComparable());
            _dataSeries3D.SetC(6d.FromComparable());

            _dataSeries3D.CopyFrom(_heightMap);

            var renderableSeries3D = new FreeSurfaceRenderableSeries3D()
            {
                DataSeries = _dataSeries3D,
                DrawMeshAs = DrawMeshAs.SolidMesh,
                StrokeColor = Color.FromArgb(0x77, 0x22, 0x8B, 0x22),
                ContourStrokeColor = Color.FromArgb(0x77, 0x22, 0x8B, 0x22),
                StrokeThickness = 2f.ToDip(Activity),
                MeshColorPalette = new GradientColorPalette(
                    new Color[] { Color.FromArgb(0xFF, 0x1D, 0x2C, 0x6B), Color.Blue, Color.Cyan, Color.GreenYellow, Color.Yellow, Color.Red, Color.DarkRed },
                    new float[] { 0, 0.005f, 0.0075f, 0.01f, 0.5f, 0.7f, 1f }),
                PaletteMinimum = new Vector3(0, 6, 0),
                PaletteMaximum = new Vector3(0, 7, 0),
            };

            using (Surface.SuspendUpdates())
            {
                Surface.WorldDimensions.Assign(200, 200, 200);

                Surface.XAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-8, 8) };
                Surface.YAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-8, 8) };
                Surface.ZAxis = new NumericAxis3D() { VisibleRange = new DoubleRange(-8, 8) };

                Surface.Camera = new Camera3D();

                Surface.RenderableSeries.Add(renderableSeries3D);

                Surface.ChartModifiers = new ChartModifier3DCollection
                {
                    new PinchZoomModifier3D(),
                    new OrbitModifier3D(),
                    new ZoomExtentsModifier3D()
                };
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
            lock (_syncRoot)
            {
                if (!_isRunning) return;

                var freq = (Math.Sin(_frames++ * 0.1) + 1) / 2;
                var exp = freq * 10;

                var offset = _frames % Size;
                var size = _heightMap.Size();

                _buffer.SetSize(size);

                for (int i = 0; i < size; i++)
                {
                    var currentValueIndex = i + offset;
                    if(currentValueIndex >= size)
                    {
                        currentValueIndex -= size;
                    }

                    var currentValue = _heightMap.Get(currentValueIndex);

                    _buffer.Set(i, currentValue + Math.Pow(currentValue, exp) * HeightOffsetScale);
                }

                _dataSeries3D.CopyFrom(_buffer);
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            Pause();
        }

        private void Pause()
        {
            if (!_isRunning) return;

            _isRunning = false;
            _timer.Stop();
            _timer.Elapsed -= OnTick;
            _timer = null;
        }

        private static DoubleValues GetGlobalHeatmap(Context context, DoubleValues heightMapValues)
        {
            var heightMap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.example_globe_heightmap);

            var stepU = heightMap.Width / Size;
            var stepV = heightMap.Height / Size;

            heightMapValues.SetSize(Size * Size);
            for (int v = 0; v < Size; v++)
            {
                for (int u = 0; u < Size; u++)
                {
                    var index = v * Size + u;

                    var x = u * stepU;
                    var y = v * stepV;

                    var pixel = heightMap.GetPixel(x, y);
                    var red = (pixel >> 16) & 0xFF;

                    heightMapValues.Set(index, red / 255d);
                }
            }

            heightMap.Recycle();

            return heightMapValues;
        }
    }
}