using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCICollectionObserver : NSObject
    [BaseType(typeof(NSObject))]
    interface SCICollectionObserver
    {
        // -(instancetype _Nonnull)initWithCollectionChangedBlock:(SCICollectionChangedCallback _Nonnull)block;
        [Export("initWithCollectionChangedBlock:")]
        IntPtr Constructor(SCICollectionChangedCallback block);

        // @property (copy, nonatomic) SCICollectionChangedCallback _Nonnull onCollectionChanged;
        [Export("onCollectionChanged", ArgumentSemantic.Copy)]
        SCICollectionChangedCallback OnCollectionChanged { get; set; }
    }
}