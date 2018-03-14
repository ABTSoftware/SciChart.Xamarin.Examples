using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    interface ISCILogarithmicCoordinateCalculatorProtocol { }

    // @protocol SCILogarithmicCoordinateCalculatorProtocol <SCICoordinateCalculatorProtocol>
    [Protocol, Model]
    interface SCILogarithmicCoordinateCalculatorProtocol : SCICoordinateCalculatorProtocol
    {
        // @required -(double)logarithmicBase;
        [Abstract]
        [Export("logarithmicBase")]
        double LogarithmicBase { get; }
    }
}