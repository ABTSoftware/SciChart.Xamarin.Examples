using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCILogarithmicAxisProtocol { }

    // @protocol SCILogarithmicAxisProtocol <SCIAxis2DProtocol>
    [Protocol, Model]
    interface SCILogarithmicAxisProtocol : SCIAxis2DProtocol
    {
        // @required @property (nonatomic) double logarithmicBase;
        [Abstract]
        [Export("logarithmicBase")]
        double LogarithmicBase { get; set; }
    }
}