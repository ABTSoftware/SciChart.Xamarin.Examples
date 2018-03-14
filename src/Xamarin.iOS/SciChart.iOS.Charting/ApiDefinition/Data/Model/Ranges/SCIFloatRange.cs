using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIFloatRange : NSObject <SCIRangeProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIFloatRange : SCIRangeProtocol
    {
        // -(id)initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(SCIGenericType min, SCIGenericType max);
    }
}