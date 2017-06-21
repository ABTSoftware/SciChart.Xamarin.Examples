using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCIChartModifierCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIChartModifierCollection
    {
        // -(nonnull instancetype) initWithChildModifiers:(NSArray<id<SCIChartModifierProtocol>>* _Nonnull)childModifiers;
        [Export("initWithChildModifiers:")]
        IntPtr Constructor([Params]ISCIChartModifierProtocol[] childModifiers);

        // -(id<SCIChartModifierProtocol> _Nullable) itemByName:(NSString *_Nonnull)name;
        [Export("itemByName:")]
        ISCIChartModifierProtocol ItemByName(string name);

        // -(void) add:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("add:")]
        void Add(ISCIChartModifierProtocol item);

        // -(BOOL) remove:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("remove:")]
        bool Remove(ISCIChartModifierProtocol item);

        // -(id<SCIChartModifierProtocol> _Nullable) itemAt:(int)index;
        [Export("itemAt:")]
        ISCIChartModifierProtocol ItemAt(int index);

        // - (void)insert:(id<SCIChartModifierProtocol> _Nonnull)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIChartModifierProtocol item, int index);

        // - (id<SCIChartModifierProtocol> _Nullable)firstObject;
        [Export("firstObject")]
        ISCIChartModifierProtocol FirstObject { get; }

        // - (BOOL)contains:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("contains:")]
        bool Contains(ISCIChartModifierProtocol item);

        // - (int)indexOf:(id <SCIChartModifierProtocol>)item;
        [Export("indexOf:")]
        int IndexOf(ISCIChartModifierProtocol item);

        // - (void)setModifier:(id <SCIChartModifierProtocol> _Nonnull)modifier atIndex(unsigned int)index;
        [Export("setModifier:atIndex:")]
        void SetModifier(ISCIChartModifierProtocol modifier, int index);

        // @property (nonatomic) BOOL handleGestureFirstOnly;
        [Export("handleGestureFirstOnly")]
        bool HandleGestureFirstOnly { get; set; }
    }
}