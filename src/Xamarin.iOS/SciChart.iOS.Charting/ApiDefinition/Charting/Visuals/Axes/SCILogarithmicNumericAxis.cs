using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILogarithmicNumericAxis : SCINumericAxis <SCILogarithmicAxisProtocol>
    [BaseType(typeof(SCINumericAxis))]
    interface SCILogarithmicNumericAxis : SCILogarithmicAxisProtocol
    {

    }
}