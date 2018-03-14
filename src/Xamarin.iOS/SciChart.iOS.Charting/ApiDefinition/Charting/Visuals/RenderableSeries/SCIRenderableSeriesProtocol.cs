using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    interface ISCIRenderableSeriesProtocol { }

	// @protocol SCIRenderableSeriesProtocol <NSObject, SCIDrawableProtocol, SCISuspendableProtocol>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SCIRenderableSeriesProtocol : SCIDrawableProtocol, SCISuspendableProtocol
    {
        // @required @property (nonatomic) id<SCIPenStyleProtocol> strokeStyle;
        [Abstract]
        [Export("strokeStyle", ArgumentSemantic.Assign)]
        ISCIPenStyleProtocol StrokeStyle { get; set; }

        // @required @property (nonatomic) id<SCIPointMarkerProtocol> pointMarker;
        [Abstract]
        [Export("pointMarker", ArgumentSemantic.Assign)]
        ISCIPointMarkerProtocol PointMarker { get; set; }

        // @required @property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;
        [Abstract]
        [Export("parentSurface", ArgumentSemantic.Weak)]
        ISCIChartSurfaceProtocol ParentSurface { get; set; }

        // @required @property (nonatomic) BOOL isVisible;
        [Abstract]
        [Export("isVisible")]
        bool IsVisible { get; set; }

        // @required @property (nonatomic) BOOL isSelected;
        [Abstract]
        [Export("isSelected")]
        bool IsSelected { get; set; }

        // @required @property (nonatomic) SCIResamplingMode resamplingMode;
        [Abstract]
        [Export("resamplingMode", ArgumentSemantic.Assign)]
        SCIResamplingMode ResamplingMode { get; set; }

        // @required @property (nonatomic, strong) id<SCIDataSeriesProtocol> dataSeries;
        [Abstract]
        [Export("dataSeries", ArgumentSemantic.Strong)]
        ISCIDataSeriesProtocol DataSeries { get; set; }

        // @required @property (nonatomic, weak) id<SCIAxis2DProtocol> xAxis;
        [Abstract]
        [Export("xAxis", ArgumentSemantic.Weak)]
        ISCIAxis2DProtocol XAxis { get; set; }

        // @required @property (nonatomic, weak) id<SCIAxis2DProtocol> yAxis;
        [Abstract]
        [Export("yAxis", ArgumentSemantic.Weak)]
        ISCIAxis2DProtocol YAxis { get; set; }

        // @required @property (copy, nonatomic) NSString * xAxisId;
        [Abstract]
        [Export("xAxisId")]
        string XAxisId { get; set; }

        // @required @property (copy, nonatomic) NSString * yAxisId;
        [Abstract]
        [Export("yAxisId")]
        string YAxisId { get; set; }

        // @required @property (nonatomic, strong) id<SCIRenderPassDataProtocol> currentRenderPassData;
        [Abstract]
        [Export("currentRenderPassData", ArgumentSemantic.Strong)]
        ISCIRenderPassDataProtocol CurrentRenderPassData { get; set; }

        // @required @property (nonatomic) double zeroLineY;
        [Abstract]
        [Export("zeroLineY")]
        double ZeroLineY { get; set; }

        // @required -(double)getYZeroCoord;
        [Abstract]
        [Export("getYZeroCoord")]
        double YZeroCoord { get; }

        // @required -(UIColor *)seriesColor;
        [Abstract]
        [Export("seriesColor")]
        UIColor SeriesColor { get; }

        // @required -(id<SCIRangeProtocol>)getXRange;
        [Abstract]
        [Export("getXRange")]
        ISCIRangeProtocol XRange { get; }

        // @required -(id<SCIRangeProtocol>)getYRange:(id<SCIRangeProtocol>)xRange;
        [Abstract]
        [Export("getYRange:")]
        ISCIRangeProtocol GetYRange(SCIRangeProtocol xRange);

        // @required -(id<SCIRangeProtocol>)getYRange:(id<SCIRangeProtocol>)xRange Positive:(BOOL)getPositiveRange;
        [Abstract]
        [Export("getYRange:Positive:")]
        ISCIRangeProtocol GetYRange(SCIRangeProtocol xRange, bool getPositiveRange);

        // @required -(id<SCIHitTestProviderProtocol>)hitTestProvider;
        [Abstract]
        [Export("hitTestProvider")]
        ISCIHitTestProviderProtocol HitTestProvider { get; }

        // @required -(SCISeriesInfo *)toSeriesInfoWithHitTest:(SCIHitTestInfo)info;
        [Abstract]
        [Export("toSeriesInfoWithHitTest:")]
        SCISeriesInfo ToSeriesInfoWithHitTest(SCIHitTestInfo info);

        // @required @property (nonatomic, strong) id<SCIPaletteProviderProtocol> paletteProvider;
        [Abstract]
        [Export("paletteProvider", ArgumentSemantic.Strong)]
        ISCIPaletteProviderProtocol PaletteProvider { get; set; }

        // @required @property (nonatomic) SCIGenericType dataAggregation;
        [Abstract]
        [Export("dataAggregation", ArgumentSemantic.Assign)]
        SCIGenericType DataAggregation { get; set; }

        // @required @property (nonatomic) int pixelAggregation;
        [Abstract]
        [Export("pixelAggregation")]
        int PixelAggregation { get; set; }

        // @required - (id<SCIPointSeriesProtocol>)performAnimation:(id<SCIBaseRenderableSeriesAnimationProtocol>)animation withPointSeries:(id<SCIPointSeriesProtocol>)pointSeries;
        [Abstract]
        [Export("performAnimation:withPointSeries:")]
        SCIPointSeriesProtocol PerformAnimation(ISCIBaseRenderableSeriesAnimationProtocol animation, ISCIPointSeriesProtocol pointSeries);


        // @required - (void)addAnimation:(id<SCIBaseRenderableSeriesAnimationProtocol>)animation;
        [Abstract]
        [Export("addAnimation:")]
        void AddAnimation(ISCIBaseRenderableSeriesAnimationProtocol animation);

        // @required - (void)addAnimation:(id<SCIBaseRenderableSeriesAnimationProtocol>)animation;
        [Abstract]
        [Export("removeAnimation:")]
        void RemoveAnimation(ISCIBaseRenderableSeriesAnimationProtocol animation);
    }
}