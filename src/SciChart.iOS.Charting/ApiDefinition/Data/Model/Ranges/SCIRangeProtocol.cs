using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIRangeProtocol : SCIRangeProtocol, INSObjectProtocol { }

    // @protocol SCIRangeProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIRangeProtocol
    {
        // @required -(BOOL)isZero;
        [Abstract]
        [Export("isZero")]
        bool IsZero();

        // @required -(SCIDoubleRange*)asDoubleRange;
        [Abstract]
        [Export("asDoubleRange")]
        SCIDoubleRange AsDoubleRange();

        // @required -(id<SCIRangeProtocol>)clipTo:(id<SCIRangeProtocol>)maximumRange;
        [Abstract]
        [Export("clipTo:")]
        ISCIRangeProtocol ClipToRange(ISCIRangeProtocol maximumRange);

        // @required -(BOOL)isDefined;
        [Abstract]
        [Export("isDefined")]
        bool IsDefined();

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
    }
}