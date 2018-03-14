using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIRangeProtocol { }

    // @protocol SCIRangeProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIRangeProtocol
    {
        // @required -(SCIRangeType)rangeType;
        [Abstract]
        [Export("rangeType")]
        SCIRangeType RangeType { get; }

        // @required @property (nonatomic) SCIGenericType min;
        [Abstract]
        [Export("min", ArgumentSemantic.Assign)]
        SCIGenericType Min_native { get; set; }

        // @required @property (nonatomic) SCIGenericType max;
        [Abstract]
        [Export("max", ArgumentSemantic.Assign)]
        SCIGenericType Max_native { get; set; }

        // @required -(SCIGenericType)diff;
        [Abstract]
        [Export("diff")]
        SCIGenericType Diff_native { get; }

        // @required -(BOOL)isZero;
        [Abstract]
        [Export("isZero")]
        bool IsZero { get; }

        // @required -(SCIDoubleRange *)asDoubleRange;
        [Abstract]
        [Export("asDoubleRange")]
        SCIDoubleRange AsDoubleRange();

        // @required -(void)setMinTo:(SCIGenericType)min MaxTo:(SCIGenericType)max;
        [Abstract]
        [Export("setMinTo:MaxTo:")]
        void SetMinMax(SCIGenericType min, SCIGenericType max);

        // @required -(void)setMinTo:(SCIGenericType)min MaxTo:(SCIGenericType)max WithLimits:(id<SCIRangeProtocol>)limits;
        [Abstract]
        [Export("setMinTo:MaxTo:WithLimits:")]
        void SetMinMax(SCIGenericType min, SCIGenericType max, SCIRangeProtocol limits);

        // @required -(id<SCIRangeProtocol>)growMinBy:(SCIGenericType)min MaxBy:(SCIGenericType)max;
        [Abstract]
        [Export("growMinBy:MaxBy:")]
        ISCIRangeProtocol GrowMinMax(SCIGenericType min, SCIGenericType max);

        // @required -(id<SCIRangeProtocol>)clipTo:(id<SCIRangeProtocol>)maximumRange;
        [Abstract]
        [Export("clipTo:")]
        ISCIRangeProtocol ClipTo(ISCIRangeProtocol maximumRange);

        // @required -(BOOL)isValueWithinTheRange:(SCIGenericType)value;
        [Abstract]
        [Export("isValueWithinTheRange:")]
        bool IsValueWithinTheRange(SCIGenericType value);

        // @required -(BOOL)isDefined;
        [Abstract]
        [Export("isDefined")]
        bool IsDefined { get; }

        // @required -(BOOL)equals:(id<SCIRangeProtocol>)otherRange;
        [Abstract]
        [Export("equals:")]
        bool Equals(ISCIRangeProtocol otherRange);

        // @required -(id<SCIRangeProtocol>)unionWith:(id<SCIRangeProtocol>)range;
        [Abstract]
        [Export("unionWith:")]
        ISCIRangeProtocol UnionWith(ISCIRangeProtocol range);

        // @required -(id<SCIRangeProtocol>)clone;
        [Abstract]
        [Export("clone")]
        ISCIRangeProtocol Clone();

        // @required -(void)assertMinLessOrEqualToThanMax;
        [Abstract]
        [Export("assertMinLessOrEqualToThanMax")]
        void AssertMinLessOrEqualToThanMax();

        // @required -(id<SCIRangeProtocol>)growMinBy:(SCIGenericType)minFraction MaxBy:(SCIGenericType)maxFraction isLogarithmic:(BOOL)isLogarithmic LogBase:(double)logBase;
        [Abstract]
        [Export("growMinBy:MaxBy:isLogarithmic:LogBase:")]
        ISCIRangeProtocol GrowMinMaxBy(SCIGenericType minFraction, SCIGenericType maxFraction, bool isLogarithmic, double logBase);
    }
}