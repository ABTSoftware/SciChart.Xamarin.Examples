using Foundation;

namespace SciChart.iOS.Charting
{
    interface ISCIDisposableProtocol { }

    // @protocol SCIDisposableProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SCIDisposableProtocol
    {
        // @required -(void)dispose;
        [Abstract]
        [Export("dispose")]
        void Dispose();
    }
}