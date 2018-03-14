using CoreGraphics;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIHitTestProviderBase : NSObject <SCIHitTestProviderProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIHitTestProviderBase : SCIHitTestProviderProtocol
    {
        // -(int)getClosestPointToCoordX:(double)x Y:(double)y From:(id<SCIRenderPassDataProtocol>)data;
        [Export("getClosestPointToCoordX:Y:From:")]
        int GetClosestPointToCoordX(double x, double y, ISCIRenderPassDataProtocol data);

        // -(CGPoint)getClosestPointOnSegmentToCoordX:(double)x Y:(double)y From:(id<SCIRenderPassDataProtocol>)data;
        [Export("getClosestPointOnSegmentToCoordX:Y:From:")]
        CGPoint GetClosestPointOnSegmentToCoordX(double x, double y, ISCIRenderPassDataProtocol data);

        // -(int)getClosestIndexWithXValue:(double)xValue andYValue:(double)yValue andXData:(SCIArrayController *)xData andYData:(SCIArrayController *)yData;
        [Export("getClosestIndexWithXValue:andYValue:andXData:andYData:")]
        int GetClosestIndexWithXValue(double xValue, double yValue, SCIArrayController xData, SCIArrayController yData);
    }
}