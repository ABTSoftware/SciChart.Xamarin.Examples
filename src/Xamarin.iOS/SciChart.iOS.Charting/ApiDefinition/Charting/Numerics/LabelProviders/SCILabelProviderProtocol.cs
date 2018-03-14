using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCILabelProviderProtocol { }

    // @protocol SCILabelProviderProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCILabelProviderProtocol
    {
        // @required -(void)setAxis:(id<SCIAxisCoreProtocol>)parentAxis;
        [Abstract]
        [Export("setAxis:")]
        void SetAxis(ISCIAxisCoreProtocol parentAxis);

        // @required -(void)onBeginAxisDraw;
        [Abstract]
        [Export("onBeginAxisDraw")]
        void OnBeginAxisDraw();

        // @required -(id<SCITickLabelProtocol>)updateDataContextWithContext:(SCIDefaultTickLabel *)label Data:(SCIGenericType)dataValue Style:(SCITextFormattingStyle *)style;
        [Abstract]
        [Export("updateDataContextWithContext:Data:Style:")]
        ISCITickLabelProtocol UpdateDataContextWithContext(SCIDefaultTickLabel label, SCIGenericType dataValue, SCITextFormattingStyle style);

        // @required -(NSString *)formatLabel:(SCIGenericType)dataValue;
        [Abstract]
        [Export("formatLabel:")]
        string FormatLabel(SCIGenericType dataValue);

        // @required -(NSString *)formatCursorLabel:(SCIGenericType)dataValue;
        [Abstract]
        [Export("formatCursorLabel:")]
        string FormatCursorLabel(SCIGenericType dataValue);
    }
}