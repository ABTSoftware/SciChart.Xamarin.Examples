using CoreGraphics;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIRenderPassInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIRenderPassInfo
    {
        // @property (nonatomic) CGSize viewportSize;
        [Export("viewportSize")]
        CGSize ViewportSize { get; set; }

        // @property (nonatomic) CGPoint viewportOrigin;
        [Export("viewportOrigin")]
        CGPoint ViewportOrigin { get; set; }

        // -(SCIRenderPassData*)renderPassDataAt:(int)index;
        [Export("renderPassDataAt:")]
        SCIRenderPassData RenderPassDataAt(int index);

        // -(void)addRenderPassData:(SCIRenderPassData*)data;
        [Export("addRenderPassData:")]
        void AddRenderPassData(SCIRenderPassData data);

        // -(void)setRenderPassData:(SCIRenderPassData*)data At:(int)index;
        [Export("setRenderPassData:At:")]
        SCIRenderPassData SetRenderPassDataAt(SCIRenderPassData data, int index);

        // -(int)renderPassDataCount;
        [Export("renderPassDataCount")]
        int RenderPassDataCount { get; }
    }
}