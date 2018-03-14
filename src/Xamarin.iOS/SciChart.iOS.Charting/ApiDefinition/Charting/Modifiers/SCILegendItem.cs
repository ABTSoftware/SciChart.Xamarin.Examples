using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendItem : NSObject
    [BaseType(typeof(NSObject))]
    interface SCILegendItem
    {
        // @property (nonatomic) UIColor * _Nullable markerColor;
        [NullAllowed, Export("markerColor", ArgumentSemantic.Assign)]
        UIColor MarkerColor { get; set; }

        // @property (nonatomic) BOOL isVisible;
        [Export("isVisible")]
        bool IsVisible { get; set; }

        // @property (nonatomic) BOOL isSelected;
        [Export("isSelected")]
        bool IsSelected { get; set; }

        // @property (nonatomic) BOOL showMarker;
        [Export("showMarker")]
        bool ShowMarker { get; set; }

        // @property (nonatomic) BOOL showCheckBoxes;
        [Export("showCheckBoxes")]
        bool ShowCheckBoxes { get; set; }

        // @property (nonatomic) NSString * _Nullable seriesName;
        [NullAllowed, Export("seriesName")]
        string SeriesName { get; set; }

        // @property (readonly) id<SCIRenderableSeriesProtocol> _Nonnull renderebleSeries;
        [Export("renderebleSeries")]
        ISCIRenderableSeriesProtocol RenderebleSeries { get; }

        // -(instancetype _Nonnull)initWithRenderebleSeries:(id<SCIRenderableSeriesProtocol> _Nonnull)series;
        [Export("initWithRenderebleSeries:")]
        IntPtr Constructor(ISCIRenderableSeriesProtocol series);
    }
}