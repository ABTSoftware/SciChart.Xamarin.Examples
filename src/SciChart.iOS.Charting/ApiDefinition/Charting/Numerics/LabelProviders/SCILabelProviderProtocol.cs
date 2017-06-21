using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    interface ISCILabelProviderProtocol : INSObjectProtocol { }

    // @protocol SCILabelProviderProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCILabelProviderProtocol
    {
        // -(void)setAxis:(id<SCIAxisCoreProtocol>)parentAxis;
        [Abstract]
        [Export("setAxis:")]
        void SetAxis(ISCIAxisCoreProtocol parentAxis);

        // -(void)onBeginAxisDraw;
        [Abstract]
        [Export("onBeginAxisDraw")]
        void OnBeginAxisDraw();

        // Bounded in Extras
        // -(id<SCITickLabelProtocol>)updateDataContextWithContext:(SCIDefaultTickLabel *)label Data:(SCIGenericType)dataValue Style:(SCITextFormattingStyle *)style;

        // Bounded in Extras
        // -(NSString *)formatLabel:(id)dataValue;

        // Bounded in Extras
        // -(NSString *)formatCursorLabel:(id)dataValue;
    }
}