using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIAnnotationBase : NSObject <SCIAnnotationProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAnnotationBase : SCIAnnotationProtocol
    {
        // @property (copy, nonatomic) NSString * xAxisId;
        [Export("xAxisId")]
        string XAxisId { get; set; }

        // @property (copy, nonatomic) NSString * yAxisId;
        [Export("yAxisId")]
        string YAxisId { get; set; }

        // @property (nonatomic) SCIAnnotationCoordMode coordMode;
        [Export("coordinateMode", ArgumentSemantic.Assign)]
        SCIAnnotationCoordinateMode CoordinateMode { get; set; }

        // -(BOOL)isVertical;
        [Export("isVertical")]
        bool IsVertical { get; }

        // -(CGRect)getBindingArea;
        [Export("getBindingArea")]
        CGRect BindingArea { get; }

        // -(CGPoint)pointInBindingArea:(CGPoint)point;
        [Export("pointInBindingArea:")]
        CGPoint PointInBindingArea(CGPoint point);

        // Bounded in Extras
        // -(CGPoint)getCoordFromDataX:(SCIGenericType)x Y:(SCIGenericType)y;
        
        // Bounded in Extras
        // -(SCIGenericType)getDataXFromCoord:(double)x;

        // Bounded in Extras
        // -(SCIGenericType)getDataYFromCoord:(double)y;
    }
}