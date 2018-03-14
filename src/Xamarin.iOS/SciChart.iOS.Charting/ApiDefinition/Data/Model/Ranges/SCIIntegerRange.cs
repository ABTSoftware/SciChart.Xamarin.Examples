using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIIntegerRange : NSObject <SCIRangeProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIIntegerRange : SCIRangeProtocol
    {
        // -(id)initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(SCIGenericType min, SCIGenericType max);
    }
}