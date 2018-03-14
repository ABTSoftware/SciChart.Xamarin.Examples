using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCINiceTimeSpanScale : NSObject
    [BaseType(typeof(NSObject))]
    interface SCINiceTimeSpanScale
    {
        // -(instancetype)initWithMin:(NSTimeInterval)min Max:(NSTimeInterval)max MinorsPerMajor:(int)minorsPerMajor MaxTicks:(uint)maxTicks;
        [Export("initWithMin:Max:MinorsPerMajor:MaxTicks:")]
        IntPtr Constructor(double min, double max, int minorsPerMajor, uint maxTicks);

        // -(SCIDoubleRange *)tickSpacing;
        [Export("tickSpacing")]
        SCIDoubleRange TickSpacing { get; }

        // -(SCIDoubleRange *)niceRange;
        [Export("niceRange")]
        SCIDoubleRange NiceRange { get; }
    }
}