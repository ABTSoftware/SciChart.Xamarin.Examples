using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIAnnotationBase : NSObject <SCIAnnotationProtocol, SCIThemeableProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIAnnotationBase : SCIAnnotationProtocol, SCIThemeableProtocol
    {
        // @property (copy, nonatomic) NSString * xAxisId;
        [Export("xAxisId")]
        string XAxisId { get; set; }

        // @property (copy, nonatomic) NSString * yAxisId;
        [Export("yAxisId")]
        string YAxisId { get; set; }

        // @property (nonatomic) SCIAnnotationCoordinateMode coordinateMode;
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

        // -(CGPoint)getCoordFromDataX:(SCIGenericType)x Y:(SCIGenericType)y;
        [Export("getCoordFromDataX:Y:")]
        CGPoint GetCoordFromDataX(SCIGenericType x, SCIGenericType y);

        // -(SCIGenericType)getDataXFromCoord:(double)x;
        [Export("getDataXFromCoord:")]
        SCIGenericType GetDataXFromCoord(double x);

        // -(SCIGenericType)getDataYFromCoord:(double)y;
        [Export("getDataYFromCoord:")]
        SCIGenericType GetDataYFromCoord(double y);

        // -(void)invalidateElement;
        [Export("invalidateElement")]
        void InvalidateElement();
    }
}