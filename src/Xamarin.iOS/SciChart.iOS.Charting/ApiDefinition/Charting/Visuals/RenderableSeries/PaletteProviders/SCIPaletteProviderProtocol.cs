using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIPaletteProviderProtocol { }

    // @protocol SCIPaletteProviderProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIPaletteProviderProtocol
    {
        // @required -(void)updateData:(id<SCIRenderPassDataProtocol>)data;
        [Abstract]
        [Export("updateData:")]
        void UpdateData(ISCIRenderPassDataProtocol data);

        // @required -(id<SCIStyleProtocol>)styleForX:(double)x Y:(double)y Index:(int)index;
        [Abstract]
        [Export("styleForX:Y:Index:")]
        ISCIStyleProtocol StyleForPoint(double x, double y, int index);
    }
}