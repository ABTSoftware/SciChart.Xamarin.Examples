using Android.Views.Animations;

using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Animations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using Xamarin.Examples.Demo.Data;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;
using Android.Views;
using SciChart.Core.Utility.Touch;
using SciChart.Core;
using Android.Graphics;
using System;
using SciChart.Charting.Visuals.Annotations;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Custom Gesture Modifier", description: "Shows how to create custom gesture modifier", icon: ExampleIcon.Impulse)]
    class CreateCustomGestureModifierFragment : ExampleBaseFragment
    {
        public SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        protected override void InitExample()
        {
            var xAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1) };
            var yAxis = new NumericAxis(Activity) { GrowBy = new DoubleRange(0.1, 0.1) };

            var ds1Points = DataManager.Instance.GetDampedSinewave(1.0, 0.05, 50, 5);
            var dataSeries = new XyDataSeries<double, double>();
            dataSeries.Append(ds1Points.XData, ds1Points.YData);

            var rSeries = new FastImpulseRenderableSeries
            {
                DataSeries = dataSeries,
                StrokeStyle = new SolidPenStyle(0xFF0066FF, 2f.ToDip(Activity)),
                PointMarker = new EllipsePointMarker
                {
                    Width = 10.ToDip(Activity),
                    Height = 10.ToDip(Activity),
                    StrokeStyle = new SolidPenStyle(0xFF0066FF, 2f.ToDip(Activity)),
                    FillStyle = new SolidBrushStyle(0xFF0066FF)
                }
            };

            var annotation = new TextAnnotation(Activity)
            {
                Text = "Double Tap and pan vertically to Zoom In/Out. \nDouble tap to Zoom Extents.",
                X1Value = 0.5,
                Y1Value = 0,
                CoordinateMode = AnnotationCoordinateMode.Relative,
                VerticalAnchorPoint = VerticalAnchorPoint.Top,
                HorizontalAnchorPoint = HorizontalAnchorPoint.Center
            };

            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(xAxis);
                Surface.YAxes.Add(yAxis);
                Surface.RenderableSeries.Add(rSeries);
                Surface.Annotations.Add(annotation);
                Surface.ChartModifiers.Add(new CustomGestureModifier());

                new WaveAnimatorBuilder(rSeries) { Interpolator = new DecelerateInterpolator(), Duration = 3000, StartDelay = 350 }.Start();
            }
        }
    }

    class CustomGestureModifier : GestureModifierBase
    {
        private bool _isScrolling = false;
        private bool _isZoomEnabled = false;

        private float _touchSlop;
        private readonly PointF _start = new PointF();
        private float _lastY;

        public override void AttachTo(IServiceContainer services)
        {
            base.AttachTo(services);

            var context = Context;

            if (context == null) return;

            this._touchSlop = ViewConfiguration.Get(context).ScaledTouchSlop * 2;
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            _start.Set(e.GetX(), e.GetY());
            _lastY = e.GetY();
            _isZoomEnabled = true;

            return true;
        }

        public override void OnTouch(ModifierTouchEventArgs args)
        {
            base.OnTouch(args);

            var motionEvent = args.E;
            if (_isZoomEnabled && motionEvent.Action == MotionEventActions.Move)
            {
                OnScrollInYDirection(motionEvent.GetY());
            }
        }

        private void OnScrollInYDirection(float y)
        {
            var distance = Math.Abs(y - _start.Y);

            if (distance < _touchSlop || Math.Abs(y - _lastY) < 1f) return;

            _isScrolling = true;

            var prevDistance = Math.Abs(_lastY - _start.Y);
            var diff = prevDistance > 0 ? distance / prevDistance - 1 : 0;

            GrowBy(_start, XAxis, diff);

            _lastY = y;
        }

        // zoom axis relative to the start point using fraction
        private void GrowBy(PointF point, IAxis axis, double fraction)
        {
            var size = axis.AxisViewportDimension;
            var coord = size - point.Y;

            double minFraction = (coord / size) * fraction;
            double maxFraction = (1 - coord / size) * fraction;

            axis.ZoomBy(minFraction, maxFraction);
        }

        protected override void OnUp(MotionEvent e)
        {
            // need to disable zoom after finishing scrolling
            if (_isScrolling)
            {
                _isScrolling = _isZoomEnabled = false;
                _start.Set(float.NaN, float.NaN);
                _lastY = float.NaN;
            }
        }
    }
}