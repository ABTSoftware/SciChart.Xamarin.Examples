using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    public enum CoordinateCalculatorOptions
    {
        XAxis = 1,
        YAxis = 2,
        CategoryAxis = 4,
        LogarithmicAxis = 8,
        HorizontalAxis = 16,
        Flipped = 32
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCIHitTestInfo
    {
        public bool match;

        public int index;

        public double x;

        public double y;

        //public SCIGenericType xValue;

        //public SCIGenericType yValue;

        //public SCIGenericType xValueInterpolated;

        //public SCIGenericType yValueInterpolated;

        //public SCIGenericType y2Value;

        //public SCIGenericType y2ValueInterpolated;

        //public SCIGenericType zValue;

        //public SCIGenericType zValueInterpolated;

        //public SCIGenericType openValue;

        //public SCIGenericType highValue;

        //public SCIGenericType lowValue;

        //public SCIGenericType closeValue;

        public double radius;
    }

    public enum SCIResamplingMode
    {
        None,
        MinMax,
        Mid,
        Max,
        Min,
        MinMaxWithUnevenSpacing,  Auto
    }

    [Native]
    public enum SCICollectionChangedAction : long
    {
        Add,
        Remove,
        Replace,
        Reset
    }

    public enum SCIHitTestMode
    {
        Default,
        Point,
        Vertical,
        Interpolate,
        VerticalInterpolate
    }

    public enum SCIDataSeriesType
    {
        Xy,
        Ohlc,
        Hlc,
        HeatMap,
        Xyy,
        Xyz
    }

    public enum SCIStackPanelOrientation
    {
        Vertical,
        Horizontal
    }

    public enum SCILinearGradientDirection
    {
        Vertical,
        Horizontal
    }

    [Native]
    public enum SCIAxisLabelClippingMode : long
    {
        None,
        Axis,
        Surface
    }

    [Native]
    public enum SCILabelAlignmentHorizontalMode : long
    {
        Default,
        Center,
        Left,
        Right
    }

    [Native]
    public enum SCILabelAlignmentVerticalMode : long
    {
        Default,
        Center,
        Top,
        Bottom
    }

    [Native]
    public enum SCITooltipTargetOffsetMode : long
    {
        None,
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight
    }

    [Native]
    public enum SCITooltipViewAlignmentMode : long
    {
        TopRight,
        TopLeft,
        BottomRight,
        BottomLeft
    }

    [Native]
    public enum SCITooltipColorMode : long
    {
        Default,
        SeriesColor,
        SeriesColorToDataView
    }

    [Native]
    public enum SCIAnnotationLayerMode : long
    {
        Overlay,
        Underlay
    }

    public enum SCIAxisSizeSyncMode
    {
        Left = 1 << 0,
        Right = 1 << 1,
        Top = 1 << 2,
        Bottom = 1 << 3
    }

    public enum SCIOrientation
    {
        Horizontal,
        Vertical
    }

    [Native]
    public enum SCILegendPosition : long
    {
        None = 0,
        Left = 1 << 0,
        Right = 1 << 1,
        Top = 1 << 2,
        Bottom = 1 << 3,
        Center = 1 << 4
    }

    [Native]
    public enum SCISourceMode : long
    {
        AllSeries = 0,
        AllVisibleSeries,
        SelectedSeries,
        UnselectedSeries
    }

    [Native]
    public enum SCIErrorBarType : long
    {
        Absolute,
        Relative
    }

    [Native]
    public enum SCIErrorBarDirection : long
    {
        Horizontal,
        Vertical
    }

    [Native]
    public enum SCIErrorBarMode : long
    {
        High,
        Low,
        Both
    }

    [Native]
    public enum SCIThemeKey : long
    {
        BlackSteelTheme,
        BrightSparkTheme,
        ChromeTheme,
        ChartV4DarkTheme,
        ElectricTheme,
        ExpressionDarkTheme,
        ExpressionLightTheme,
        OscilloscopeTheme
    }

    [Native]
    public enum SCISelectionModifierSelectionMode : long
    {
        SingleSelectDeselectOnMiss,
        SingleSelectDeselectOnDoubleTap,
        MultiSelectDeselectOnMiss,
        MultiSelectDeselectOnDoubleTap
    }

    [Native]
    public enum SCILabelPlacement : long
    {
        Left,
        TopLeft,
        BottomLeft,
        Right,
        TopRight,
        BottomRight,
        Bottom,
        Top,
        Axis,
        Auto
    }

    [Native]
    public enum SCIVerticalLineAnnotationAlignment : long
    {
        Stretch,
        Bottom,
        Top,
        Center
    }

    [Native]
    public enum SCIHorizontalLineAnnotationAlignment : long
    {
        Stretch,
        Left,
        Right,
        Center
    }

    [Native]
    public enum SCIAnnotationCoordinateMode : long
    {
        Absolute,
        Relative,
        RelativeX,
        RelativeY
    }

    [Native]
    public enum SCIHorizontalAnchorPoint : long
    {
        Left,
        Center,
        Right
    }

    [Native]
    public enum SCIVerticalAnchorPoint : long
    {
        Top,
        Center,
        Bottom
    }

    public enum SCIArraySearchMode
    {
        Exact,
        Nearest,
        RoundDown,
        RoundUp
    }

    public enum SCIXYDirection
    {
        XDirection,
        YDirection,
        XYDirection
    }

    public enum SCIAxisDragMode
    {
        Scale,
        Pan
    }

    public enum SCIClipMode
    {
        None,
        StretchAtExtents,
        ClipAtMin,
        ClipAtMax,
        ClipAtExtents
    }

    public enum SCIAutoRange
    {
        Once,
        Always,
        Never
    }

    public enum SCIRangeClipMode
    {
        MinMax,
        Max,
        Min
    }

    public enum SCIRangeType
    {
        Numeric,
        Date,
        Index
    }

    public enum SCIAxisAlignment
    {
        Default,
        Left,
        Top,
        Right,
        Bottom
    }

    public enum SCIGenericEquationResult
    {
        NotEqual,
        Equal,
        Lesser,
        Greater
    }

    public enum SCIDataType
    {
        None,

        Int16,
        Int32,
        Int64,
        Byte,
        Float,
        Double,
        DateTime,
        SwiftDateTime,

        VoidPtr,
        CharPtr,
        Int16Ptr,
        Int32Ptr,
        Int64Ptr,
        FloatPtr,
        DoublePtr,

        Array,
        Object
    }
}