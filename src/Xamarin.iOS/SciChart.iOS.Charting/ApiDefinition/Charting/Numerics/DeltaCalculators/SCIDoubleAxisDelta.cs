using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDoubleAxisDelta : NSObject <SCIAxisDeltaProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDoubleAxisDelta : SCIAxisDeltaProtocol
    {
        // -(id)initWithMin:(double)min Max:(double)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(double min, double max);

        // -(SCIDoubleAxisDelta *)clone;
        [Export("clone")]
        SCIDoubleAxisDelta Clone();

        // -(BOOL)equals:(id)object;
        [Export("equals:")]
        bool Equals(NSObject @object);
    }
}