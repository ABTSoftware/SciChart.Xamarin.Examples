using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCITickCoordinatesProviderProtocol { }

    // @protocol SCITickCoordinatesProviderProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCITickCoordinatesProviderProtocol
    {
        // @required @property (nonatomic, weak) id<SCIAxisCoreProtocol> parentAxis;
        [Abstract]
        [Export("parentAxis", ArgumentSemantic.Weak)]
        ISCIAxisCoreProtocol ParentAxis { get; set; }

        // @required -(void)setAxis:(id<SCIAxisCoreProtocol>)parentAxis;
        [Abstract]
        [Export("setAxis:")]
        void SetAxis(ISCIAxisCoreProtocol parentAxis);

        //// @required -(SCITickCoordinates *)getTickCoordinatesWithMinorTicks:(double *)minorTicks Count:(int)minorCount MajorTicks:(double *)majorTicks Count:(int)majorCount;
        //[Abstract]
        //[Export("getTickCoordinatesWithMinorTicks:Count:MajorTicks:Count:")]
        //// TODO discuss with Andrii
        //unsafe SCITickCoordinates GetTickCoordinatesWithMinorTicks(double* minorTicks, int minorCount, double* majorTicks, int majorCount);
    }
}