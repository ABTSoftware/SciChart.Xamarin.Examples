using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCIAxisMarkerAnnotationBase : SCIAnnotationBase
    [BaseType(typeof(SCIAnnotationBase))]
    interface SCIAxisMarkerAnnotationBase
    {
        // @property (copy, nonatomic) SCIAxisMarkerAnnotationStyle * style;
        [Export("style", ArgumentSemantic.Copy)]
        SCIAxisMarkerAnnotationStyle Style { get; set; }

        // @property (copy, nonatomic) NSString * formattedValue;
        [Export("formattedValue")]
        string FormattedValue { get; set; }

        // -(NSString *)formatValue:(SCIGenericType)value;
        [Export("formatValue:")]
        string FormatValue(SCIGenericType value);

        // -(UITextField *)axisLabel;
        [Export("axisLabel")]
        UITextField AxisLabel { get; }

        // -(id<SCIAxis2DProtocol>)currentAxis;
        [Export("currentAxis")]
        SCIAxis2DProtocol CurrentAxis { get; }

        // -(void)resetAxis;
        [Export("resetAxis")]
        void ResetAxis();

        // -(SCIGenericType)positionOnAxis;
        [Export("positionOnAxis")]
        SCIGenericType PositionOnAxis { get; }
    }
}