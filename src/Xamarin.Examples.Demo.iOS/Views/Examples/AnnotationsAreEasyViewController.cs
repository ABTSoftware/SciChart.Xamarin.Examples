using UIKit;
using SciChart.Examples.Demo.Fragments.Base;
using Xamarin.Examples.Demo.iOS.Views.Base;
using Xamarin.Examples.Demo.iOS.Resources.Layout;
using SciChart.iOS.Charting;
using Xamarin.Examples.Demo.Utils;
using System;

namespace Xamarin.Examples.Demo.iOS
{
    [ExampleDefinition("Annotations are Easy", description: "Demonstrates how to use Annotations", icon: ExampleIcon.Annotations)]
    public class AnnotationsAreEasyViewController : ExampleBaseViewController
    {
        public override Type ExampleViewType => typeof(SingleChartViewLayout);

        public SCIChartSurface Surface => ((SingleChartViewLayout)View).SciChartSurface;

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
                    HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Right,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(UIColor.Orange, 2f) },
                };
                horizontalLine1.AddLabel(new SCILineAnnotationLabel
                {
                    Text = "Right Aligned, with text on left",
                    Style =
                    {
                        TextStyle = new SCITextFormattingStyle {Color = UIColor.Orange},
                        LabelPlacement = SCILabelPlacement.TopLeft,
                        BackgroundColor = UIColor.Clear
                    }
                });

                var horizontalLine2 = new SCIHorizontalLineAnnotation
                {
                    X1Value = 7.0,
                    Y1Value = 2.8,
                    HorizontalAlignment = SCIHorizontalLineAnnotationAlignment.Stretch,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(UIColor.Orange, 2f) }
                };
                horizontalLine2.AddLabel(new SCILineAnnotationLabel
                {
                    Style =
                    {
                        TextStyle = new SCITextFormattingStyle {Color = UIColor.Black},
                        LabelPlacement = SCILabelPlacement.Axis,
                        BackgroundColor = UIColor.Orange
                    }
                });

                var verticalLine1 = new SCIVerticalLineAnnotation
                {
                    X1Value = 9.0,
                    Y1Value = 4.0,
                    VerticalAlignment = SCIVerticalLineAnnotationAlignment.Bottom,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(ColorUtil.Brown.ToColor(), 2f) }
                };
                verticalLine1.AddLabel(new SCILineAnnotationLabel
                {
                    TextColor = UIColor.White,
                    Style =
                    {
                        LabelPlacement = SCILabelPlacement.Axis,
                        BackgroundColor = ColorUtil.Brown.ToColor()
                    }
                });

                var verticalLine2 = new SCIVerticalLineAnnotation
                {
                    X1Value = 9.5,
                    Y1Value = 3.0,
                    VerticalAlignment = SCIVerticalLineAnnotationAlignment.Stretch,
                    Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(ColorUtil.Brown.ToColor(), 2f) }
                };
                verticalLine2.AddLabel(new SCILineAnnotationLabel
                {
                    TextColor = UIColor.White,
                    Style =
                    {
                        LabelPlacement = SCILabelPlacement.Axis,
                        BackgroundColor = ColorUtil.Brown.ToColor()
                    }
                });
                verticalLine2.AddLabel(new SCILineAnnotationLabel
                {
                    Text = "Bottom-aligned",
                    Style =
                    {
                        TextStyle = new SCITextFormattingStyle {Color = ColorUtil.Brown.ToColor()},
                        LabelPlacement = SCILabelPlacement.TopRight,
                        BackgroundColor = UIColor.Clear
                    }
                });

                Surface.Annotations = new SCIAnnotationCollection
                {
                    // Watermark
                    new SCITextAnnotation
                    {
                        X1Value = 0.5,
                        Y1Value = 0.5,
                        Text = "Create \nWatermarks",
                        Style = new SCITextAnnotationStyle
                        {
                            TextColor = 0x22FFFFFF.ToColor(),
                            TextStyle = new SCITextFormattingStyle {FontSize = 42 }
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
                        Style = new SCITextAnnotationStyle
                        {
                            TextColor = UIColor.White,
                            TextStyle = new SCITextFormattingStyle { FontSize = 24 },
                        },
                        Text = "Annotations are Easy!",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 1.9,
                        Y1Value = 9.0,
                        Style = new SCITextAnnotationStyle
                        {
                            TextColor = UIColor.White,
                            TextStyle = new SCITextFormattingStyle { FontSize = 10 },
                        },
                        Text = "You can create text",
                    },

                    // Text with Anchor Points
                    new SCITextAnnotation
                    {
                        X1Value = 5,
                        Y1Value = 8,
                        Style = new SCITextAnnotationStyle { TextColor = UIColor.White },
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Center,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                        Text = "Anchor Center (X1, Y1)",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 5,
                        Y1Value = 8,
                        Style = new SCITextAnnotationStyle { TextColor = UIColor.White },
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Right,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Top,
                        Text = "Anchor Right",
                    },
                    new SCITextAnnotation
                    {
                        X1Value = 5,
                        Y1Value = 8,
                        Style = new SCITextAnnotationStyle { TextColor = UIColor.White },
                        HorizontalAnchorPoint = SCIHorizontalAnchorPoint.Left,
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Top,
                        Text = "or Anchor Left",
                    },

                    // Line and TODO LineArrow annotaiton
                    new SCITextAnnotation
                    {
                        X1Value = 0.3,
                        Y1Value = 6.1,
                        Style = new SCITextAnnotationStyle { TextColor = UIColor.White },
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom,
                        Text = "Draw Lines with \nor without arrows",
                    },
                    new SCILineAnnotation
                    {
                        X1Value = 1.0,
                        Y1Value = 4.0,
                        X2Value = 2.0,
                        Y2Value = 6.0,
                        Style = new SCILineAnnotationStyle { LinePen = new SCISolidPenStyle(0xFF555555, 2f) }
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
                        Text = "Draw Boxes",
                        Style = new SCITextAnnotationStyle { TextColor = UIColor.White },
                        VerticalAnchorPoint = SCIVerticalAnchorPoint.Bottom
                    },
                    new SCIBoxAnnotation
                    {
                        X1Value = 3.5,
                        Y1Value = 4.0,
                        X2Value = 5.0,
                        Y2Value = 5.0,
                        Style = new SCIBoxAnnotationStyle
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
                        Style = new SCIBoxAnnotationStyle
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
                        Style = new SCITextAnnotationStyle { TextColor = UIColor.White },
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
                    horizontalLine1,
                    horizontalLine2,

                    // Vertical Lines
                    verticalLine1,
                    verticalLine2
                };

                Surface.ChartModifiers = new SCIChartModifierCollection
                {
                    new SCIZoomPanModifier(),
                    new SCIPinchZoomModifier(),
                    new SCIZoomExtentsModifier()
                };
            }
        }
    }
}