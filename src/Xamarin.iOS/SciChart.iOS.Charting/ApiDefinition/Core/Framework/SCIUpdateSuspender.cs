using System;
using Foundation;

namespace SciChart.iOS.Charting
{
    // typedef void (^SCIRunnableBlock)();
    delegate void SCIRunnableBlock();

    // @interface SCIUpdateSuspender : SCIDisposableBase <SCIUpdateSuspenderProtocol>
    [BaseType(typeof(SCIDisposableBase))]
    interface SCIUpdateSuspender : SCIUpdateSuspenderProtocol
    {
        // -(instancetype _Nonnull)initWithTarget:(id<SCISuspendableProtocol> _Nonnull)target;
        [Export("initWithTarget:")]
        IntPtr Constructor(ISCISuspendableProtocol target);

        // TODO Uncomment this, when Xamarin will support NSMapTable
        //// +(NSMapTable<id<SCISuspendableProtocol>,NSNumber *> * _Nonnull)suspendedInstances;
        //[Static]
        //[Export("suspendedInstances")]
        //NSMapTable<ISCISuspendableProtocol, NSNumber> SuspendedInstances { get; }

        // +(void)usingWithSuspendable:(id<SCISuspendableProtocol> _Nonnull)suspendable withBlock:(SCIRunnableBlock _Nonnull)block;
        [Static]
        [Export("usingWithSuspendable:withBlock:")]
        void UsingWithSuspendable(ISCISuspendableProtocol suspendable, SCIRunnableBlock block);

        // +(BOOL)isTargetSuspended:(id<SCISuspendableProtocol> _Nonnull)target;
        [Static]
        [Export("isTargetSuspended:")]
        bool IsTargetSuspended(ISCISuspendableProtocol target);
    }
}