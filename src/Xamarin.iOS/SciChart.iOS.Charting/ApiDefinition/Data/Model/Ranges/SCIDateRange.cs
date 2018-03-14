using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDateRange : NSObject <SCIRangeProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDateRange : SCIRangeProtocol
    {
        // -(id)initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(SCIGenericType min, SCIGenericType max);

        // -(id)initWithDateMin:(NSDate *)min Max:(NSDate *)max;
        [Export("initWithDateMin:Max:")]
        IntPtr Constructor(NSDate min, NSDate max);
    }
}