using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIDrawableProtocol { }

    // @protocol SCIDrawableProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIDrawableProtocol
    {
        // @required -(void)onDrawWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithData:(id<SCIRenderPassDataProtocol>)renderPassData;
        [Abstract]
        [Export("onDrawWithContext:WithData:")]
        void OnDrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);

        // @required -(void)prepareForDrawing;
        [Abstract]
        [Export("prepareForDrawing")]
        void PrepareForDrawing();
    }
}