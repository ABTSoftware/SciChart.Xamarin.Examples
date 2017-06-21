using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIStackedSeriesRenderDataRequest)(id<ISCIRenderableSeriesProtocol>, id<ISCIRenderPassDataProtocol>);
    delegate void SCIStackedSeriesRenderDataRequest(ISCIRenderableSeriesProtocol arg0, ISCIRenderPassDataProtocol arg1);

    interface ISCIStackedRenderableSeriesProtocol : ISCIRenderableSeriesProtocol { }

    // @protocol ISCIStackedRenderableSeriesProtocol <ISCIRenderableSeriesProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIStackedRenderableSeriesProtocol : SCIRenderableSeriesProtocol
    {
        // @required @property (copy, nonatomic) SCIStackedSeriesRenderDataRequest updateRenderData;
        [Abstract]
        [Export("updateRenderData", ArgumentSemantic.Copy)]
        SCIStackedSeriesRenderDataRequest UpdateRenderData { get; set; }

        // @required -(void)modifyPointSeries:(id<ISCIPointSeriesProtocol>)points1 With:(id<ISCIPointSeriesProtocol>)points2;
        [Abstract]
        [Export("modifyPointSeries:With:")]
        void ModifyPointSeries(ISCIPointSeriesProtocol points1, ISCIPointSeriesProtocol points2);

        // @required -(void)drawWithContext:(id<ISCIRenderContext2DProtocol>)renderContext WithStackedData:(id<ISCIRenderPassDataProtocol>)renderPassData;
        [Abstract]
        [Export("drawWithContext:WithStackedData:")]
        void DrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);

        // @required -(id<ISCIPointSeriesProtocol>)getStackedPointSeriesFromPoints1:(id<ISCIPointSeriesProtocol>)points1 Points2:(id<ISCIPointSeriesProtocol>)points2;
        [Abstract]
        [Export("getStackedPointSeriesFromPoints1:Points2:")]
        ISCIPointSeriesProtocol GetStackedPointSeriesFromPoints1(ISCIPointSeriesProtocol points1, ISCIPointSeriesProtocol points2);
    }
}