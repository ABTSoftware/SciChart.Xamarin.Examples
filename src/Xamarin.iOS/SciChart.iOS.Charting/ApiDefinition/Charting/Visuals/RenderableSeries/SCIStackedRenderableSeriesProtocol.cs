using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIStackedSeriesRenderDataRequest)(id<SCIRenderableSeriesProtocol,SCIStackedRenderableSeriesProtocol>, id<SCIRenderPassDataProtocol>);
    delegate void SCIStackedSeriesRenderDataRequest(ISCIRenderableSeriesProtocol arg0, ISCIRenderPassDataProtocol arg1);

    interface ISCIStackedRenderableSeriesProtocol { }

    // @protocol SCIStackedRenderableSeriesProtocol <SCIRenderableSeriesProtocol>
    [Protocol, Model]
    interface SCIStackedRenderableSeriesProtocol : SCIRenderableSeriesProtocol
    {
        // @required @property (copy, nonatomic) SCIStackedSeriesRenderDataRequest updateRenderData;
        [Abstract]
        [Export("updateRenderData", ArgumentSemantic.Copy)]
        SCIStackedSeriesRenderDataRequest UpdateRenderData { get; set; }

        // @required -(void)drawWithContext:(id<SCIRenderContext2DProtocol>)renderContext WithStackedData:(id<SCIRenderPassDataProtocol>)renderPassData;
        [Abstract]
        [Export("drawWithContext:WithStackedData:")]
        void DrawWithContext(ISCIRenderContext2DProtocol renderContext, ISCIRenderPassDataProtocol renderPassData);

        // @required @property (weak) SCIStackedSeriesCollectionBase * parentStackedGroupSeries;
        [Abstract]
        [Export("parentStackedGroupSeries", ArgumentSemantic.Weak)]
        SCIStackedSeriesCollectionBase ParentStackedGroupSeries { get; set; }

        // @optional -(void)shiftOrderNumber:(NSMutableArray<NSNumber *> *)currentNumber andCountDataSeries:(NSMutableArray<NSNumber *> *)coundDataSeries;
        [Export("shiftOrderNumber:andCountDataSeries:")]
        void ShiftOrderNumber(NSMutableArray<NSNumber> currentNumber, NSMutableArray<NSNumber> coundDataSeries);
    }
}