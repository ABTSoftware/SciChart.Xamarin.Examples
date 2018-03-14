using Foundation;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCICustomRenderableSeries : SCIRenderableSeriesBase
    [BaseType(typeof(SCIRenderableSeriesBase))]
    interface SCICustomRenderableSeries
    {
        // -(SCISeriesInfo *)toSeriesInfoWithHitTest:(SCIHitTestInfo)info;
        [Export("toSeriesInfoWithHitTest:")]
        SCISeriesInfo ToSeriesInfoWithHitTest(SCIHitTestInfo info);

        // -(id<SCIHitTestProviderProtocol>)hitTestProvider;
        [Export("hitTestProvider")]
        ISCIHitTestProviderProtocol HitTestProvider { get; }

        // -(UIColor *)seriesColor;
        [Export("seriesColor")]
        UIColor SeriesColor { get; }

        // -(void)internalDrawWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithData:(id<SCIRenderPassDataProtocol>)renderPassData;
        [Export("internalDrawWithContext:WithData:")]
        void InternalDrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);
    }
}