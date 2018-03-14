using Foundation;

namespace SciChart.iOS.Charting
{
    interface ISCIViewportManager { }

    // @interface SCIViewportManager : NSObject <SCIViewportManagerProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIViewportManager : SCIViewportManagerProtocol
    {
        // -(id<SCIRangeProtocol>)onCalculateNewXRange:(id<SCIAxis2DProtocol>)xAxis;
        [Export("onCalculateNewXRange:")]
        ISCIRangeProtocol OnCalculateNewXRange(ISCIAxis2DProtocol xAxis);

        // -(id<SCIRangeProtocol>)onCalculateNewYRange:(id<SCIAxis2DProtocol>)yAxis RenderPassInfo:(SCIRenderPassInfo *)renderPassInfo;
        [Export("onCalculateNewYRange:RenderPassInfo:")]
        ISCIRangeProtocol OnCalculateNewYRange(ISCIAxis2DProtocol yAxis, SCIRenderPassInfo renderPassInfo);
    }
}