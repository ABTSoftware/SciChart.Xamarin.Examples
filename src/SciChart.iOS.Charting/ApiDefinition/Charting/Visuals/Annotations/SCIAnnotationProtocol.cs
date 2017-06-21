using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIAnnotationProtocol : ISCIGestureEventsHandlerProtocol { }

    interface ISCIAnnotation : ISCIAnnotationProtocol, ISCIGestureEventsHandler { }

    // @protocol SCIAnnotationProtocol <SCIGestureEventsHandlerProtocol>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIAnnotationProtocol : SCIGestureEventsHandlerProtocol
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

        // -(id<SCIAxis2DProtocol>) getXAxis:(NSString*)axisId;
        [Abstract]
        [Export("getXAxis:")]
        ISCIAxis2DProtocol GetXAxis(string axisId);

        // -(id<SCIAxis2DProtocol>) getYAxis:(NSString*)axisId;
        [Abstract]
        [Export("getYAxis:")]
        ISCIAxis2DProtocol GetYAxis(string axisId);

        // -(void)draw;
        [Abstract]
        [Export("draw")]
        void Draw();

        // -(void)onAttached;
        [Abstract]
        [Export("onAttached")]
        void OnAttached();

        // -(void)onDetached;
        [Abstract]
        [Export("onDetached")]
        void OnDetached();

        // @property (nonatomic) BOOL isAttached;
        [Abstract]
        [Export("isAttached")]
        bool IsAttached { get; set; }

        // @property(nonatomic) BOOL isEditable;
        [Export("isEditable")]
        bool IsEditable { get; set; }

        // @property (copy, nonatomic) NSString * annotationName;
        [Abstract]
        [Export("annotationName")]
        string AnnotationName { get; set; }
    }
}