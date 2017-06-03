using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using SciChart.Charting.Model;
using SciChart.Charting.Modifiers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Drawing.Common;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.Droid.Extensions;
using Xamarin.Examples.Demo.Droid.Fragments.Base;

namespace Xamarin.Examples.Demo.Droid.Fragments.Examples
{
    [ExampleDefinition("Annotations are Easy", description: "Demonstrates how to use Annotations", icon: ExampleIcon.Annotations)]
    public class AnnotationsAreEasyFragment : ExampleBaseFragment
    {
        public override int ExampleLayoutId => Resource.Layout.Example_Single_Chart_Fragment;

        private SciChartSurface Surface => View.FindViewById<SciChartSurface>(Resource.Id.chart);

        protected override void InitExample()
        {
            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(new NumericAxis(Activity)
                {
                    VisibleRange = new DoubleRange(0, 10),
                    GrowBy = new DoubleRange(0.1, 0.1),
                    TextFormatting = "0.0#"
                });

                Surface.YAxes.Add(new NumericAxis(Activity)
                {
                    VisibleRange = new DoubleRange(0, 10),
                    GrowBy = new DoubleRange(0.1, 0.1),
                    TextFormatting = "0.0#"
                });

                var customAnnotation1 = new CustomAnnotation(Activity)
                {
                    X1Value = 8d,
                    Y1Value = 5.5,
                };

                customAnnotation1.SetContentId(Resource.Layout.Example_Custom_Annotation_View);

                var customAnnotation2 = new CustomAnnotation(Activity)
                {
                    X1Value = 7.5,
                    Y1Value = 5d,
                };

                customAnnotation2.SetContentView(new CustomView2(Activity));

                Surface.Annotations = new AnnotationCollection()
                {
                    // Watermark
                    new TextAnnotation(Activity)
                    {
                        X1Value = 0.5,
                        Y1Value = 0.5,
                        FontStyle = new FontStyle(Activity, Typeface.DefaultBold, 42, Color.Argb(0x22, 0xFF, 0xFF, 0xFF))
                    },

                    // Text annotations
                    new TextAnnotation(Activity)
                    {
                        X1Value = 0.3,
                        Y1Value = 9.7,
                        FontStyle = new FontStyle(Activity, 24, Color.White),
                        Text = "Annotations are Easy!"
                    },
                    new TextAnnotation(Activity)
                    {
                        X1Value = 1.9,
                        Y1Value = 9.0,
                        FontStyle = new FontStyle(Activity, 10, Color.White),
                        Text = "You can create text"
                    },
                    
                    // Text with Anchor Points
                    new TextAnnotation(Activity)
                    {
                        X1Value = 5d,
                        Y1Value = 8d,
                        HorizontalAnchorPoint = HorizontalAnchorPoint.Center,
                        VerticalAnchorPoint = VerticalAnchorPoint.Bottom,
                        Text = "Anchor Center (X1, Y1)"
                    },
                    new TextAnnotation(Activity)
                    {
                        X1Value = 5d,
                        Y1Value = 8d,
                        HorizontalAnchorPoint = HorizontalAnchorPoint.Right,
                        VerticalAnchorPoint = VerticalAnchorPoint.Top,
                        Text = "Anchor Right"
                    },
                    new TextAnnotation(Activity)
                    {
                        X1Value = 5d,
                        Y1Value = 8d,
                        HorizontalAnchorPoint = HorizontalAnchorPoint.Left,
                        VerticalAnchorPoint = VerticalAnchorPoint.Top,
                        Text = "or Anchor Left"
                    },

                    // Line and LineArrow annotation
                    new TextAnnotation(Activity)
                    {
                        X1Value = 0.3,
                        Y1Value = 6.1,
                        FontStyle = new FontStyle(Activity, 12, Color.White),
                        VerticalAnchorPoint = VerticalAnchorPoint.Bottom,
                        Text = "Draw Lines with \nor without arrows"
                    },
                    new LineAnnotation(Activity)
                    {
                        X1Value = 1d,
                        Y1Value = 4d,
                        X2Value = 2d,
                        Y2Value = 6d,
                        Stroke = new SolidPenStyle(Activity, Color.Argb(0xFF, 0x55, 0x55, 0x55), thickness: 2)
                    },
                    new LineArrowAnnotation(Activity)
                    {
                        X1Value = 1.2,
                        Y1Value = 3.8,
                        X2Value = 2.5,
                        Y2Value = 6d,
                        Stroke = new SolidPenStyle(Activity, Color.Argb(0xFF, 0x55, 0x55, 0x55), thickness: 2)
                    },

                    // Boxes
                    new TextAnnotation(Activity)
                    {
                        X1Value = 3.5,
                        Y1Value = 6.1,
                        Text = "Draw Boxes",
                        VerticalAnchorPoint = VerticalAnchorPoint.Bottom
                    },
                    new BoxAnnotation(Activity)
                    {
                        X1Value = 3.5,
                        Y1Value = 4d,
                        X2Value = 5d,
                        Y2Value = 5d,
                        Background = Activity.GetDrawableCompat(Resource.Drawable.example_box_annotation_background_1)
                    },
                    new BoxAnnotation(Activity)
                    {
                        X1Value = 4d,
                        Y1Value = 4.5,
                        X2Value = 5.5,
                        Y2Value = 5.5,
                        Background = Activity.GetDrawableCompat(Resource.Drawable.example_box_annotation_background_2)
                    },
                    new BoxAnnotation(Activity)
                    {
                        X1Value = 4.5,
                        Y1Value = 5d,
                        X2Value = 6d,
                        Y2Value = 6d,
                        Background = Activity.GetDrawableCompat(Resource.Drawable.example_box_annotation_background_3)
                    },

                    // Custom Shapes
                    new TextAnnotation(Activity)
                    {
                        X1Value = 7d,
                        Y1Value = 6.1,
                        FontStyle = new FontStyle(Activity, 12, Color.White),
                        VerticalAnchorPoint = VerticalAnchorPoint.Bottom,
                        Text = "Or Custom Shapes"
                    },
                    customAnnotation1,
                    customAnnotation2,

                    // Horizontal Lines
                    new HorizontalLineAnnotation(Activity)
                    {
                        X1Value = 5d,
                        Y1Value = 3.2,
                        HorizontalGravity = GravityFlags.Right,
                        Stroke = new SolidPenStyle(Activity, Color.Orange, thickness: 2),

                        AnnotationLabels = new AnnotationLabelCollection()
                        {
                            new AnnotationLabel(Activity)
                            {
                                LabelPlacement = LabelPlacement.TopLeft,
                                Text = "Right Aligned, with text on left"
                            }
                        }
                    },
                    new HorizontalLineAnnotation(Activity)
                    {
                        X1Value = 7d,
                        Y1Value = 2.8,
                        Stroke = new SolidPenStyle(Activity, Color.Orange, thickness: 2),

                        AnnotationLabels = new AnnotationLabelCollection()
                        {
                            new AnnotationLabel(Activity)
                            {
                                LabelPlacement = LabelPlacement.Axis
                            }
                        }
                    },

                    // Vertical Lines
                    new VerticalLineAnnotation(Activity)
                    {
                        X1Value = 9d,
                        Y1Value = 4d,
                        VerticalGravity = GravityFlags.Bottom,
                        Stroke = new SolidPenStyle(Activity, Color.Brown, thickness: 2),

                        AnnotationLabels = new AnnotationLabelCollection()
                        {
                            new AnnotationLabel(Activity)
                        }
                    },
                    new VerticalLineAnnotation(Activity)
                    {
                        X1Value = 9.5d,
                        Y1Value = 3d,
                        Stroke = new SolidPenStyle(Activity, Color.Brown, thickness: 2),

                        AnnotationLabels = new AnnotationLabelCollection()
                        {
                            new AnnotationLabel(Activity),
                            new AnnotationLabel(Activity)
                            {
                                LabelPlacement = LabelPlacement.TopRight,
                                Text = "Bottom-aligned",
                                RotationAngle = 90
                            }
                        }
                    }
                };

                Surface.ChartModifiers = new ChartModifierCollection
                {
                    new ZoomPanModifier(),
                    new PinchZoomModifier(),
                    new ZoomExtentsModifier(),
                };

            }
        }
    }

    public class CustomView1 : View
    {
        private readonly Path _path = new Path();
        private readonly Paint _paintFill = new Paint();
        private readonly Paint _paintStroke = new Paint();

        public CustomView1(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public CustomView1(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        public CustomView1(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init();
        }

        private void Init()
        {
            _paintFill.SetStyle(Paint.Style.Fill);
            _paintFill.SetARGB(0x57, 0x1C, 0xB6, 0x1C);

            _paintStroke.SetStyle(Paint.Style.Stroke);
            _paintStroke.SetARGB(0xFF, 0x00, 0xB4, 0x00);

            _path.MoveTo(0, 15);
            _path.LineTo(15, 0);
            _path.LineTo(30, 15);
            _path.LineTo(20, 15);
            _path.LineTo(20, 30);
            _path.LineTo(10, 30);
            _path.LineTo(10, 15);
            _path.LineTo(0, 15);

            SetMinimumHeight(50);
            SetMinimumWidth(50);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawPath(_path, _paintFill);
            canvas.DrawPath(_path, _paintStroke);
        }
    }

    public class CustomView2 : View
    {
        private readonly Path _path = new Path();
        private readonly Paint _paintFill = new Paint();
        private readonly Paint _paintStroke = new Paint();

        public CustomView2(Context context) : base(context)
        {
            _paintFill.SetStyle(Paint.Style.Fill);
            _paintFill.SetARGB(0x57, 0xB2, 0x20, 0x20);

            _paintStroke.SetStyle(Paint.Style.Stroke);
            _paintStroke.SetARGB(0xFF, 0x99, 0x00, 0x00);

            _path.MoveTo(0, 15);
            _path.LineTo(10, 15);
            _path.LineTo(10, 0);
            _path.LineTo(20, 0);
            _path.LineTo(20, 15);
            _path.LineTo(30, 15);
            _path.LineTo(15, 30);
            _path.LineTo(0, 15);

            SetMinimumHeight(50);
            SetMinimumWidth(50);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawPath(_path, _paintFill);
            canvas.DrawPath(_path, _paintStroke);
        }
    }
}