using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIIndexRange : NSObject <SCIRangeProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIIndexRange : SCIRangeProtocol
    {
        // -(id)initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(SCIGenericType min, SCIGenericType max);
    }
}