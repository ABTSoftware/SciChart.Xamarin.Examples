using UIKit;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Annotations are Easy", description: "Demonstrates how to use Annotations", icon: ExampleIcon.Annotations)]
    public class AnnotationsAreEasyView : ExampleBaseView<SingleChartViewLayout>
    {
        private readonly SingleChartViewLayout _exampleViewLayout = SingleChartViewLayout.Create();
        public override SingleChartViewLayout ExampleViewLayout => _exampleViewLayout;

        public SCIChartSurface Surface => ExampleViewLayout.SciChartSurface;

        protected override void UpdateFrame()
        {
            Surface.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint constraintRight = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint constraintLeft = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint constraintTop = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint constraintBottom = NSLayoutConstraint.Create(Surface, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0);

            this.AddConstraint(constraintRight);
            this.AddConstraint(constraintLeft);
            this.AddConstraint(constraintTop);
            this.AddConstraint(constraintBottom);
        }

        protected override void InitExampleInternal()
        {
            var xAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(0.0, 10.0) };
            var yAxis = new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(0.0, 10.0) };

            Surface.XAxes.Add(xAxis);
            Surface.YAxes.Add(yAxis);

            Surface.Annotations = new SCIAnnotationCollection
            {
                // Watermark
                new SCITextAnnotation
                {
                    X1Value = 0.5,
                    Y1Value = 0.5,
                    Text = "Create \n Watermarks",
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.FromRGBA(1.0f,1.0f,1.0f,0.22f),
                        TextStyle = new SCITextFormattingStyle
                        {
                            FontSize = 42
                        }
                    },
                    CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Center
                },

                // Text annotations
                new SCITextAnnotation
                {
                    X1Value = 0.3,
                    Y1Value = 9.7,
                    Text = "Annotations are Easy!",
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White,
                        TextStyle = new SCITextFormattingStyle
                        {
                            FontSize = 24
                        },
                    },
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Left,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Top
                },
                new SCITextAnnotation
                {
                    X1Value = 1.9,
                    Y1Value = 9.0,
                    Text = "You can create text",
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White,
                        TextStyle = new SCITextFormattingStyle
                        {
                            FontSize = 10
                        },
                    }
                },

                // Text with Anchor Points
				new SCITextAnnotation
                {
                    X1Value = 5,
                    Y1Value = 8,
                    Text = "Anchor Center (X1, Y1)",
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White
                    },
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom
                },
                new SCITextAnnotation
                {
                    X1Value = 5,
                    Y1Value = 8,
                    Text = "Anchor Right",
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White
                    },
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Right,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Top
                },
                new SCITextAnnotation
                {
                    X1Value = 5,
                    Y1Value = 8,
                    Text = "or Anchor Left",
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White
                    },
                    HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Left,
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Top
                },

                // Line and TODO LineArrow annotaiton
                new SCITextAnnotation
                {
                    X1Value = 0.3,
                    Y1Value = 6.1,
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White
                    },
                    Text = "Draw Lines with \nor without arrows",
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom
                },
                new SCILineAnnotation
                {
                    X1Value = 1.0,
                    Y1Value = 4.0,
                    X2Value = 2.0,
                    Y2Value = 6.0,
                    Style = new SCILineAnnotationStyle
                    {
                        LinePen = new SCISolidPenStyle(0xFF555555, 2f),
                    }
                },
                new SCILineAnnotation
                {
                    X1Value = 1.2,
                    Y1Value = 3.8,
                    X2Value = 2.5,
                    Y2Value = 6.0,
                    Style = new SCILineAnnotationStyle {LinePen = new SCISolidPenStyle(0xFF555555, 2f) }
                },

                // Boxes
                new SCITextAnnotation
                {
                    X1Value = 3.5,
                    Y1Value = 6.1,
                    Style = new SCITextAnnotationStyle()
                    {
                        TextColor = UIColor.White
                    },
                    Text = "Draw Boxes",
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom
                },
                new SCIBoxAnnotation
                {
                    X1Value = 3.5,
                    Y1Value = 4.0,
                    X2Value = 5.0,
                    Y2Value = 5.0,
                    Style = new SCIBoxAnnotationStyle()
                    {
                        BorderPen = new SCISolidPenStyle(0xFF279B27, 1f),
                        FillBrush = new SCILinearGradientBrushStyle(0x550000FF, 0x55FFFF00, SCILinearGradientDirection.Horizontal)
                    }
                },
                new SCIBoxAnnotation
                {
                    X1Value = 4.0,
                    Y1Value = 4.5,
                    X2Value = 5.5,
                    Y2Value = 5.5,
                    Style = new SCIBoxAnnotationStyle()
                    {
                        BorderPen = new SCISolidPenStyle(0xFFFF1919, 1f),
                        FillBrush = new SCISolidBrushStyle(0x55FF1919)
                    }
                },
                new SCIBoxAnnotation
                {
                    X1Value = 4.5,
                    Y1Value = 5.0,
                    X2Value = 6.0,
                    Y2Value = 6.0,
                    Style = new SCIBoxAnnotationStyle
                    {
                        BorderPen = new SCISolidPenStyle(0xFF279B27, 1f),
                        FillBrush = new SCISolidBrushStyle(0x55279B27)
                    }
                },

                // Custom chapes
                new SCITextAnnotation
                {
                    X1Value = 7.0,
                    Y1Value = 6.1,
                    Style = new SCITextAnnotationStyle
                    {
                        TextColor = UIColor.White
                    },
                    VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                    Text = "Or Custom Shapes"
                },
                new SCICustomAnnotation
                {
                    CustomView = new UIImageView(UIImage.FromBundle("GreenArrow")),
                    X1Value = 8,
                    Y1Value = 5.5
                },
                new SCICustomAnnotation
                {
                    CustomView = new UIImageView(UIImage.FromBundle("RedArrow")),
                    X1Value = 7.5,
                    Y1Value = 5
                },

                // Horizontal Lines
                new SCIHorizontalLineAnnotation
                {
                    X1Value = 5.0,
                    Y1Value = 3.2,
                    HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Right,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(UIColor.Orange, 2f) }
                },
                new SCIHorizontalLineAnnotation
                {
                    X1Value = 7.0,
                    Y1Value = 2.8,
                    HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Right,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(UIColor.Orange, 2f) }
                },

                // Vertical Lines
                new SCIVerticalLineAnnotation
                {
                    X1Value = 9.0,
                    Y1Value = 3.0,
                    VerticalAlignment = SCIVerticalLineAnnotationAlignment.Bottom,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(UIColor.Brown, 2f) }
                },
                new SCIVerticalLineAnnotation
                {
                    X1Value = 9.5,
                    Y1Value = 3.0,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(UIColor.Brown, 2f) }
                }
            };

            Surface.ChartModifiers = new SCIChartModifierCollection(
                new SCIZoomPanModifier(),
                new SCIPinchZoomModifier(),
                new SCIZoomExtentsModifier()
            );
        }
    }
}