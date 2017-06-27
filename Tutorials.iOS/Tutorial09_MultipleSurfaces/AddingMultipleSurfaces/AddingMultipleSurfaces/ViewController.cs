using System;
using UIKit;
using SciChart.iOS.Charting;
using Foundation;

namespace AddingMultipleSurfaces
{
    public partial class ViewController : UIViewController
    {
        private SCIChartSurface _surfaceTop;
        private SCIChartSurface _surfaceBottom;

        private SCIMultiSurfaceModifier _szem;

        private XyDataSeries<Double, Double> _lineDataSeries;
        private XyDataSeries<Double, Double> _scatterDataSeries;

        private SCIFastLineRenderableSeries _lineRenderableSeries;
        private SCIXyScatterRenderableSeries _scatterRenderableSeries;
        private SCIFastMountainRenderableSeries _mountainRenderableSeries;

        // timer, used for updating data
        private NSTimer _timer;
        // phase variable used for data slipping
        private double _phase = 0.0;
        // instance variable for counting the data points in data series
        private int _i = 0;

        private SCIAnnotationCollection _annotationCollection = new SCIAnnotationCollection();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.BackgroundColor = UIColor.DarkGray;
            // Perform any additional setup after loading the view, typically from a nib.
            _surfaceTop = new SCIChartSurface();
            _surfaceTop.TranslatesAutoresizingMaskIntoConstraints = false;

            _surfaceBottom = new SCIChartSurface();
            _surfaceBottom.TranslatesAutoresizingMaskIntoConstraints = false;

            _szem = new SCIMultiSurfaceModifier(GetClassForType(typeof(SCIZoomExtentsModifier)));

            this.View.AddSubview(_surfaceTop);
            this.View.AddSubview(_surfaceBottom);

            var viewsDictionary = NSDictionary.FromObjectsAndKeys(new NSObject[] { _surfaceTop, _surfaceBottom }, new NSObject[] { new NSString("_surfaceTop"), new NSString("_surfaceBottom") });

            this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-[_surfaceTop]-|", 0, new NSDictionary(), viewsDictionary));
            this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-[_surfaceTop]-(==1)-[_surfaceBottom(==_surfaceTop)]-|", 0, new NSDictionary(), viewsDictionary));
            this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("|-[_surfaceBottom(==_surfaceTop)]-|", 0, new NSDictionary(), viewsDictionary));

            AddAxes(_surfaceTop);
            AddAxes(_surfaceBottom);

            _surfaceTop.Annotations = _annotationCollection;

            CreateDataSeries();
            CreateRenderableSeries();
            AddModifiers();
        }

        //
        // Using low-level handles, allows for error checking in case the 
        // type does not subclass NSObject:
        // https://developer.xamarin.com/api/type/ObjCRuntime.Class/
        //
        ObjCRuntime.Class GetClassForType(Type type)
        {
            IntPtr myClassHandle = ObjCRuntime.Class.GetHandle(type);
            if (myClassHandle != IntPtr.Zero)
                return new ObjCRuntime.Class(myClassHandle);
            else
                return null;
        }

        private void AddAxes(SCIChartSurface surface)
        {
            surface.XAxes.Add(new SCINumericAxis() { GrowBy = new SCIDoubleRange(0.1, 0.1) });

            var yAxis = new SCINumericAxis();
            yAxis.GrowBy = new SCIDoubleRange(min: 0.1, max: 0.1);
            yAxis.AxisId = "firstYAxis";
            surface.YAxes.Add(yAxis);

            var yLeftAxis = new SCINumericAxis();
            yLeftAxis.AxisId = "secondaryYAxis";
            yLeftAxis.AxisAlignment = SCIAxisAlignment.Left;
            yLeftAxis.VisibleRange = new SCIDoubleRange(min: -2, max: 2);
            yLeftAxis.AutoRange = SCIAutoRange.Never;
            surface.YAxes.Add(yLeftAxis);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (_timer == null)
            {
                _timer = NSTimer.CreateRepeatingScheduledTimer(0.01, (timer) =>
                {
                    _i++;

                    _lineDataSeries.Append(_i, Math.Sin(_i * 0.1 + _phase));
                    _scatterDataSeries.Append(_i, Math.Cos(_i * 0.1 + _phase));

                    _phase += 0.01;

                    var customAnnotation = new SCICustomAnnotation();
                    if (_i % 100 == 0)
                    {
                        customAnnotation.CustomView = new UILabel(new CoreGraphics.CGRect(0, 0, 10, 10)) { Text = "Y", BackgroundColor = UIColor.LightGray };
                        customAnnotation.X1Value = _i;
                        customAnnotation.Y1Value = 0.5;
                        customAnnotation.CoordinateMode = SCIAnnotationCoordinateMode.Absolute;
                        customAnnotation.YAxisId = "firstYAxis";
                        // adding new custom annotation into the annotationGroup property
                        _annotationCollection.Add(customAnnotation);

                        // removing annotations that are out of visible range
                        var customAn = _annotationCollection[0] as SCICustomAnnotation;

                        if (customAn != null)
                        {
                            if (customAn.X1Value.CompareTo(_i - 500) == 0)
                            {
                                // since the contentView is UIView element - we have to call removeFromSuperView method to remove it from screen
                                customAn.CustomView.RemoveFromSuperview();
                                _annotationCollection.Remove(customAn);
                            }
                        }
                    }
                    if (_i % 200 == 0)
                    {
                        customAnnotation.YAxisId = "secondaryYAxis";
                    }

                    _surfaceTop.ZoomExtentsX();
                    // Extents bottom chart 
                    _surfaceBottom.ZoomExtentsX();
                });
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _timer.Invalidate();
            _timer = null;
        }

        void CreateDataSeries()
        {
            // Init line data series
            _lineDataSeries = new XyDataSeries<Double, Double>();
            // Setting fifo capacity, once new data values will be added, the old one will be removed
            _lineDataSeries.FifoCapacity = 500;
            // Naming data series, so its name will be shown in LegendModifier
            _lineDataSeries.SeriesName = "LineSeries";
            for (var i = 0; i < 500; i++)
            {
                _lineDataSeries.Append(i, Math.Sin(i * 0.1));
            }

            // Init scatter data series
            _scatterDataSeries = new XyDataSeries<Double, Double>();
            // Setting fifo capacity, once new data values will be added, the old one will be removed
            _scatterDataSeries.FifoCapacity = 500;
            // Naming data series, so its name will be shown in LegendModifier
            _scatterDataSeries.SeriesName = "ScatterSeries";
            for (var i = 0; i < 500; i++)
            {
                _scatterDataSeries.Append(i, Math.Cos(i * 0.1));
            }

            _i = _lineDataSeries.Count;
        }

        void CreateRenderableSeries()
        {
            _lineRenderableSeries = new SCIFastLineRenderableSeries();
            _lineRenderableSeries.DataSeries = _lineDataSeries;
            _lineRenderableSeries.YAxisId = "firstYAxis";

            _scatterRenderableSeries = new SCIXyScatterRenderableSeries();
            _scatterRenderableSeries.DataSeries = _scatterDataSeries;
            _scatterRenderableSeries.YAxisId = "secondaryYAxis";

            _mountainRenderableSeries = new SCIFastMountainRenderableSeries();
            _mountainRenderableSeries.DataSeries = _lineDataSeries;
            _mountainRenderableSeries.YAxisId = "firstYAxis";

            _surfaceTop.RenderableSeries.Add(_lineRenderableSeries);
            _surfaceTop.RenderableSeries.Add(_scatterRenderableSeries);

            _surfaceBottom.RenderableSeries.Add(_mountainRenderableSeries);
        }

        void AddModifiers()
        {
            var xDragModifierSync = new SCIMultiSurfaceModifier(GetClassForType(typeof(SCIXAxisDragModifier)));
            var pinchZoomModifierSync = new SCIMultiSurfaceModifier(GetClassForType(typeof(SCIPinchZoomModifier)));
            var panZoomModifierSync = new SCIMultiSurfaceModifier(GetClassForType(typeof(SCIZoomPanModifier)));

            // retreiving XAxisDragModifier for customization
            var xAxisDragmodifier = ObjCRuntime.Runtime.GetNSObject<SCIXAxisDragModifier>(xDragModifierSync.ModifierForSurface(_surfaceTop).Handle);
            if (xAxisDragmodifier != null)
            {
                xAxisDragmodifier.DragMode = SCIAxisDragMode.Pan;
                xAxisDragmodifier.ClipModeX = SCIClipMode.None;
            }

            var legendCollectionModifier = new SCILegendModifier();

            var groupModifier = new SCIChartModifierCollection();
            groupModifier.Add(xDragModifierSync);
            groupModifier.Add(pinchZoomModifierSync);
            groupModifier.Add(legendCollectionModifier);

            _surfaceTop.ChartModifiers = groupModifier;

            var xAxisDragmodifierBottom = ObjCRuntime.Runtime.GetNSObject<SCIXAxisDragModifier>(xDragModifierSync.ModifierForSurface(_surfaceBottom).Handle);
            if (xAxisDragmodifierBottom != null)
            {
                xAxisDragmodifierBottom.DragMode = SCIAxisDragMode.Pan;
                xAxisDragmodifierBottom.ClipModeX = SCIClipMode.None;
            }

            var pinchZoomModifierBottom = pinchZoomModifierSync.ModifierForSurface(_surfaceBottom);

            var groupModifierBottom = new SCIChartModifierCollection();
            if (xAxisDragmodifierBottom != null) groupModifierBottom.Add(xDragModifierSync);
            if (pinchZoomModifierBottom != null) groupModifierBottom.Add(pinchZoomModifierSync);

            _surfaceBottom.ChartModifiers = groupModifierBottom;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.

        }
    }
}