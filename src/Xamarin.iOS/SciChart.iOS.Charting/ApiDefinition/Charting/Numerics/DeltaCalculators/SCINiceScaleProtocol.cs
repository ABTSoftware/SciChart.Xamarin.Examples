using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCINiceScaleProtocol { }

    // @protocol SCINiceScaleProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCINiceScaleProtocol
    {
        // @required -(SCIDoubleAxisDelta *)tickSpacing;
        [Abstract]
        [Export("tickSpacing")]
        SCIDoubleAxisDelta TickSpacing { get; }

        // @required -(void)calculateDelta;
        [Abstract]
        [Export("calculateDelta")]
        void CalculateDelta();
    }
}