using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCILegendCheckAction)(SCILegendItem *, BOOL);
    delegate void SCILegendCheckAction(SCILegendItem arg0, bool arg1);

    interface ISCILegendCellProtocol { }

    // @protocol ISCILegendCellProtocol <NSObject>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface SCILegendCellProtocol
    {
        // @required +(CGSize)preferredLayoutSizeFittingSize:(CGSize)size forItem:(SCILegendItem *)item;
        //[Static, Abstract]
        //[Export("preferredLayoutSizeFittingSize:forItem:")]
        //CGSize PreferredLayoutSizeFittingSize(CGSize size, SCILegendItem item);

        // @required -(void)setupWithItem:(SCILegendItem *)item;
        [Abstract]
        [Export("setupWithItem:")]
        void SetupWithItem(SCILegendItem item);

        // @optional @property (copy) SCILegendCheckAction checkActionHandler;
        [Export("checkActionHandler", ArgumentSemantic.Copy)]
        SCILegendCheckAction CheckActionHandler { get; set; }
    }
}