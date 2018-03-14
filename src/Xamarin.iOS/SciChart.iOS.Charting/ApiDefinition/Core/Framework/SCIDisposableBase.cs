using Foundation;

namespace SciChart.iOS.Charting
{
    // @interface SCIDisposableBase : NSObject <SCIDisposableProtocol>
    [BaseType(typeof(NSObject))]
    interface SCIDisposableBase : SCIDisposableProtocol
    {
        // +(void)tryToDispose:(id<SCIDisposableProtocol> _Nonnull)disposable;
        [Static]
        [Export("tryToDispose:")]
        void TryToDispose(ISCIDisposableProtocol disposable);

        // +(void)tryToDisposeArray:(NSArray<id<SCIDisposableProtocol>> * _Nonnull)array;
        [Static]
        [Export("tryToDisposeArray:")]
        void TryToDisposeArray(ISCIDisposableProtocol[] array);
    }
}