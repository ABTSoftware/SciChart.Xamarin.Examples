using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIRangeFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface SCIRangeFactory
    {
        // +(id<SCIRangeProtocol>)clone:(id<SCIRangeProtocol>)originalRange WithMin:(SCIGenericType)min Max:(SCIGenericType)max Limit:(id<SCIRangeProtocol>)rangeLimit;
        [Static]
        [Export("clone:WithMin:Max:Limit:")]
        ISCIRangeProtocol Clone(ISCIRangeProtocol originalRange, SCIGenericType min, SCIGenericType max, ISCIRangeProtocol rangeLimit);

        // +(id<SCIRangeProtocol>)clone:(id<SCIRangeProtocol>)originalRange WithMin:(SCIGenericType)min Max:(SCIGenericType)max;
        [Static]
        [Export("clone:WithMin:Max:")]
        ISCIRangeProtocol Clone(ISCIRangeProtocol originalRange, SCIGenericType min, SCIGenericType max);

        // +(id<SCIRangeProtocol>)getRangeOfType:(SCIDataType)type Min:(SCIGenericType)min Max:(SCIGenericType)max;
        [Static]
        [Export("getRangeOfType:Min:Max:")]
        ISCIRangeProtocol GetRangeOfType(SCIDataType type, SCIGenericType min, SCIGenericType max);

        // +(id<SCIRangeProtocol>)getRangeWithRangeType:(Class)type Min:(SCIGenericType)min Max:(SCIGenericType)max;
        [Static]
        [Export("getRangeWithRangeType:Min:Max:")]
        ISCIRangeProtocol GetRangeWithRangeType(Class type, SCIGenericType min, SCIGenericType max);
    }
}