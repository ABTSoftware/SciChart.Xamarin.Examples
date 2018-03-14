using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCILegendItemViewProtocol { }

    // typedef void (^SCILegendCheckAction)(SCILegendItem *, BOOL);
    delegate void SCILegendCheckAction(SCILegendItem arg0, bool arg1);

    // @protocol SCILegendCellProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCILegendItemViewProtocol
    {
        // @required -(void)setupWithItem:(SCILegendItem *)item;
        [Abstract]
        [Export("setupWithItem:")]
        void SetupWithItem(SCILegendItem item);

        // @optional @property (copy) SCILegendCheckAction checkActionHandler;
        [Export("checkActionHandler", ArgumentSemantic.Copy)]
        SCILegendCheckAction CheckActionHandler { get; set; }

        // -(void)setCustomStyleForCell:(SCILegendCellStyle *)style;
        [Export("setCustomStyleForCell:")]
        void SetCustomStyleForCell(SCILegendCellStyle style);
    }
}