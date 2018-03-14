using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCIAnnotationProtocol { }

    // @protocol SCIAnnotationProtocol <SCIGestureEventsHandlerProtocol, SCISuspendableProtocol>
    [Protocol, Model]
    interface SCIAnnotationProtocol : SCIGestureEventsHandlerProtocol, SCISuspendableProtocol
    {
        // @required @property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;
        [Abstract]
        [Export("parentSurface", ArgumentSemantic.Weak)]
        ISCIChartSurfaceProtocol ParentSurface { get; set; }

        // @required -(id<SCIAxis2DProtocol>)xAxis;
        [Abstract]
        [Export("xAxis")]
        ISCIAxis2DProtocol XAxis { get; }

        // @required -(id<SCIAxis2DProtocol>)yAxis;
        [Abstract]
        [Export("yAxis")]
        ISCIAxis2DProtocol YAxis { get; }

        // @required -(id<SCIAxis2DProtocol>)getXAxis:(NSString *)axisId;
        [Abstract]
        [Export("getXAxis:")]
        ISCIAxis2DProtocol GetXAxis(string axisId);

        // @required -(id<SCIAxis2DProtocol>)getYAxis:(NSString *)axisId;
        [Abstract]
        [Export("getYAxis:")]
        ISCIAxis2DProtocol GetYAxis(string axisId);

        // @required -(void)draw;
        [Abstract]
        [Export("draw")]
        void Draw();

        // @required -(void)onAttached;
        [Abstract]
        [Export("onAttached")]
        void OnAttached();

        // @required -(void)onDetached;
        [Abstract]
        [Export("onDetached")]
        void OnDetached();

        // @required @property (nonatomic) BOOL isAttached;
        [Abstract]
        [Export("isAttached")]
        bool IsAttached { get; set; }

        // @required @property (nonatomic) BOOL isEditable;
        [Abstract]
        [Export("isEditable")]
        bool IsEditable { get; set; }

        // @required @property (copy, nonatomic) NSString * annotationName;
        [Abstract]
        [Export("annotationName")]
        string AnnotationName { get; set; }

        // @required @property (nonatomic) BOOL isHidden;
        [Abstract]
        [Export("isHidden")]
        bool IsHidden { get; set; }

        // @required @property (nonatomic) BOOL isSelected;
        [Abstract]
        [Export("isSelected")]
        bool IsSelected { get; set; }
    }
}