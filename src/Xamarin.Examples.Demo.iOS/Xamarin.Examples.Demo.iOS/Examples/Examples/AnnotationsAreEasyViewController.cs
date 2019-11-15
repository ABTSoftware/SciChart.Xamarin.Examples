using UIKit;
using CoreGraphics;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Annotations are Easy", description: "Demonstrates how to use Annotations", icon: ExampleIcon.Annotations)]
    public class AnnotationsAreEasyViewController : SingleChartViewController<SCIChartSurface>
    {
        protected override void InitExample()
        {
            using (Surface.SuspendUpdates())
            {
                Surface.XAxes.Add(new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(0.0, 10.0) });
                Surface.YAxes.Add(new SCINumericAxis { GrowBy = new SCIDoubleRange(0.1, 0.1), VisibleRange = new SCIDoubleRange(0.0, 10.0) });

                var horizontalLine1 = new SCIHorizontalLineAnnotation
                {
                    X1Value = 5.0,
                    Y1Value = 3.2,
                    HorizontalAlignment = SCIAlignment.Right,
                    Stroke = new SCISolidPenStyle(UIColor.Orange, 2),
                };
                horizontalLine1.AnnotationLabels.Add(new SCIAnnotationLabel
                {
                    LabelPlacement = SCILabelPlacement.TopLeft,
                    Text = "Right Aligned, with text on left",
                });

                var horizontalLine2 = new SCIHorizontalLineAnnotation
                {
                    X1Value = 7.0,
                    Y1Value = 2.8,
                    HorizontalAlignment = SCIAlignment.FillHorizontal,
                    Stroke = new SCISolidPenStyle(UIColor.Orange, 2),
                };
                horizontalLine2.AnnotationLabels.Add(new SCIAnnotationLabel { LabelPlacement = SCILabelPlacement.Axis });

                var verticalLine1 = new SCIVerticalLineAnnotation
                {
                    X1Value = 9.0,
                    Y1Value = 4.0,
                    VerticalAlignment = SCIAlignment.Bottom,
                    Stroke = new SCISolidPenStyle(ColorUtil.Brown.ToUIColor(), 2),
                };
                verticalLine1.AnnotationLabels.Add(new SCIAnnotationLabel { LabelPlacement = SCILabelPlacement.Axis });

                var verticalLine2 = new SCIVerticalLineAnnotation
                {
                    X1Value = 9.5,
                    Y1Value = 3.0,
                    VerticalAlignment = SCIAlignment.FillVertical,
                    Stroke = new SCISolidPenStyle(ColorUtil.Brown.ToUIColor(), 2),
                };
                verticalLine2.AnnotationLabels.Add(new SCIAnnotationLabel { LabelPlacement = SCILabelPlacement.Axis });
                verticalLine2.AnnotationLabels.Add(new SCIAnnotationLabel
                {
                    Text = "Bottom-aligned",
                    LabelPlacement = SCILabelPlacement.TopRight,
                    RotationAngle = -90
                });                

                Surface.Annotations = new SCIAnnotationCollection
                {
                    // Watermark
                    new SCITextAnnotation
                    {
                        X1Value = 0.5,
                        Y1Value = 0.5,
                        CoordinateMode = SCIAnnotationCoordinateMode.Relative,
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Center,
                        
                        FontStyle = new SCIFontStyle(40, 0x22FFFFFF),
                        Text = "Create \nWatermarks",
                    },

                    // Text annotations
                    new SCITextAnnotation
                    {
                        X1Value = 0.3,
                        Y1Value = 9.7,
                        FontStyle = new SCIFontStyle(24, UIColor.White),
                        Text = "Annotations are Easy!",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 1.9,
                        Y1Value = 9.0,
                        FontStyle = new SCIFontStyle(12, UIColor.White),
                        Text = "You can create text",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 1.0,
                        Y1Value = 8.8,
                        CanEditText = true,
                        FontStyle = new SCIFontStyle(12, UIColor.White),
                        Text = "And even edit it ... (tap me)",
                    },

                    // Text with Anchor Points
                    new SCITextAnnotation
                    {
                        X1Value = 5,
                        Y1Value = 8,
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                        FontStyle = new SCIFontStyle(10, UIColor.White),
                        Text = "Anchor Center (X1, Y1)",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 5,
                        Y1Value = 8,
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Right,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Top,
                        FontStyle = new SCIFontStyle(10, UIColor.White),
                        Text = "Anchor Right",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 5,
                        Y1Value = 8,
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Left,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Top,
                        FontStyle = new SCIFontStyle(10, UIColor.White),
                        Text = "or Anchor Left",
                    },

                    // Line and LineArrow annotations
                    new SCITextAnnotation
                    {
                        X1Value = 0.3,
                        Y1Value = 6.1,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                        FontStyle = new SCIFontStyle(10, UIColor.White),
                        Text = "Draw Lines with \nor without arrows",
                    },
                    new SCILineAnnotation
                    {
                        X1Value = 1.0,
                        Y1Value = 4.0,
                        X2Value = 2.0,
                        Y2Value = 6.0,
                        Stroke = new SCISolidPenStyle(0xFF555555, 2f),
                    },
                    new SCILineArrowAnnotation
                    {
                        X1Value = 1.2,
                        Y1Value = 3.8,
                        X2Value = 2.5,
                        Y2Value = 6.0,
                        Stroke = new SCISolidPenStyle(0xFF555555, 2f),
                    },

                    // Boxes
                    new SCITextAnnotation
                    {
                        X1Value = 3.5,
                        Y1Value = 6.1,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                        Text = "Draw Boxes",
                    },
                    new SCIBoxAnnotation
                    {
                        X1Value = 3.5,
                        Y1Value = 4.0,
                        X2Value = 5.0,
                        Y2Value = 5.0,
                        FillBrush = new SCILinearGradientBrushStyle(new CGPoint(0.0, 0.5), new CGPoint(1.0, 0.5), 0x550000FF, 0x55FFFF00),
                        BorderPen = new SCISolidPenStyle(0xFF279B27, 1f),
                    },
                    new SCIBoxAnnotation
                    {
                        X1Value = 4.0,
                        Y1Value = 4.5,
                        X2Value = 5.5,
                        Y2Value = 5.5,
                        FillBrush = new SCISolidBrushStyle(0x55FF1919),
                        BorderPen = new SCISolidPenStyle(0xFFFF1919, 1f),
                    },
                    new SCIBoxAnnotation
                    {
                        X1Value = 4.5,
                        Y1Value = 5.0,
                        X2Value = 6.0,
                        Y2Value = 6.0,
                        FillBrush = new SCISolidBrushStyle(0x55279B27),
                        BorderPen = new SCISolidPenStyle(0xFF279B27, 1f),
                    },

                    // Custom chapes
                    new SCITextAnnotation
                    {
                        X1Value = 7.0,
                        Y1Value = 6.1,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                        FontStyle = new SCIFontStyle(12, UIColor.White),
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
                    horizontalLine1,
                    horizontalLine2,

                    // Vertical Lines
                    verticalLine1,
                    verticalLine2
                };

                Surface.ChartModifiers.Add(CreateDefaultModifiers());
            }
        }
    }
}