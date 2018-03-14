using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // TODO Consider to write in extras, so extensions aren't only static methods
    // @interface SCIConvertToHexColorCode (UIColor)
    [Category]
    [BaseType(typeof(UIColor))]
    interface UIColor_SCIConvertToHexColorCode
    {
        // +(UIColor *)fromABGRColorCode:(uint)color;
        [Static]
        [Export("fromABGRColorCode:")]
        UIColor FromABGRColorCode(uint color);

        // +(UIColor *)fromARGBColorCode:(uint)color;
        [Static]
        [Export("fromARGBColorCode:")]
        UIColor FromARGBColorCode(uint color);

        // +(uint)swapBytesFromARGBIntoABGR:(uint)argb;
        [Static]
        [Export("swapBytesFromARGBIntoABGR:")]
        uint SwapBytesFromARGBIntoABGR(uint argb);

        //// -(uint)colorABGRCode;
        //[Export("colorABGRCode")]
        //uint ColorABGRCode { get; }

        //// -(uint)colorARGBCode;
        //[Export("colorARGBCode")]
        //uint ColorARGBCode { get; }
    }
}