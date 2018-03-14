using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    [Native]
    public enum SCIAnimationCurve: long
    {
        EaseInOut,
        EaseIn,
        EaseOut,
        Linear,
        EaseInElastic,
        EaseOutElastic
    }

    public enum SCIDataType : int
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

    public enum SCIGenericEquationResult : long
    {
        NotEqual,
        Equal,
        Lesser,
        Greater
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

    public enum SCIDirection2D
    {
        XDirection,
        YDirection,
        XYDirection
    }

    public enum SCIPieSeriesSizingMode
    {
        Relative,
        Absolute
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
        inMax,
        ax,
        @in
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

    public enum CoordinateCalculatorOptions
    {
        XAxis = 1,
        YAxis = 2,
        CategoryAxis = 4,
        LogarithmicAxis = 8,
        HorizontalAxis = 16,
        Flipped = 32
    }

    public enum SCIResamplingMode
    {
        None,
        MinMax,
        Mid,
        Max,
        Min,
        MinMaxWithUnevenSpacing,
        Auto
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
    public enum SCIAnnotationSurfaceEnum : long
    {
        AboveChart,
        BelowChart,
        XAxis,
        YAxis
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
    public enum SCISelectionModifierSelectionMode : long
    {
        SingleSelectDeselectOnMiss,
        SingleSelectDeselectOnDoubleTap,
        MultiSelectDeselectOnMiss,
        MultiSelectDeselectOnDoubleTap
    }

    [Native]
    public enum SCIPieSelectionModifierSelectionMode : long
    {
        SingleSelectDeselectOnMiss,
        SingleSelectDeselectOnDoubleTap,
        MultiSelectDeselectOnMiss,
        MultiSelectDeselectOnDoubleTap
    }

    [Native]
    public enum SCICollectionChangedAction : long
    {
        Add,
        Remove,
        Replace,
        Reset
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
}