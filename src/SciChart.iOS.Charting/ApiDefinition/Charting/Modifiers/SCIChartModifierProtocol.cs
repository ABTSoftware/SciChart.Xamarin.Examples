using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCIChartModifierProtocol { }

    //interface ISCIChartModifier : ISCIChartModifierProtocol { }

    // @protocol SCIChartModifierProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCIChartModifierProtocol
    {
        // @required @property (nonatomic, weak) id<SCIChartSurfaceProtocol> parentSurface;
        [Abstract]
        [Export("parentSurface", ArgumentSemantic.Weak)]
        ISCIChartSurfaceProtocol ParentSurface { get; set; }

        // @required @property (nonatomic) BOOL isAttached;
        [Abstract]
        [Export("isAttached")]
        bool IsAttached { get; set; }

        // @required @property (nonatomic) BOOL isEnabled;
        [Abstract]
        [Export("isEnabled")]
        bool IsEnabled { get; set; }

        // @required @property (copy, nonatomic) NSString * modifierName;
        [Abstract]
        [Export("modifierName")]
        string ModifierName { get; set; }

        // @required -(id<SCIAxis2DProtocol>)xAxis;
        [Abstract]
        [Export("xAxis")]
        ISCIAxis2DProtocol XAxis { get; }

        // @required -(id<SCIAxis2DProtocol>)yAxis;
        [Abstract]
        [Export("yAxis")]
        ISCIAxis2DProtocol YAxis { get; }

        // @required -(SCIAxisCollection *)xAxes;
        [Abstract]
        [Export("xAxes")]
        SCIAxisCollection XAxes { get; }

        // @required -(SCIAxisCollection *)yAxes;
        [Abstract]
        [Export("yAxes")]
        SCIAxisCollection YAxes { get; }

        // @required -(id<SCIAxis2DProtocol>)getXAxis:(NSString *)axisName;
        [Abstract]
        [Export("getXAxis:")]
        ISCIAxis2DProtocol GetXAxisById(string axisName);

        // @required -(id<SCIAxis2DProtocol>)getYAxis:(NSString *)axisId;
        [Abstract]
        [Export("getYAxis:")]
        ISCIAxis2DProtocol GetYAxisById(string axisId);

        // @required -(void)resetInertia;
        [Abstract]
        [Export("resetInertia")]
        void ResetInertia();

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
    }
}