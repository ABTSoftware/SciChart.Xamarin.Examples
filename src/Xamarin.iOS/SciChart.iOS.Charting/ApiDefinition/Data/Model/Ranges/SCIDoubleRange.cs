using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDoubleRange : NSObject <SCIRangeProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDoubleRange : SCIRangeProtocol
    {
        // -(id)initWithMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Export("initWithMin:Max:")]
        IntPtr Constructor(SCIGenericType min, SCIGenericType max);
    }
}