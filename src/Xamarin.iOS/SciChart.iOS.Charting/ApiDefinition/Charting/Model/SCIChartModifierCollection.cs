using System;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Charting
{
    // @interface SCIChartModifierCollection : SCIObservableCollection
    [BaseType(typeof(SCIObservableCollection))]
    interface SCIChartModifierCollection
    {
        // -(instancetype _Nonnull)initWithChildModifiers:(NSArray<id<SCIChartModifierProtocol>> * _Nonnull)childModifiers;
        [Export("initWithChildModifiers:")]
        IntPtr Constructor([Params]ISCIChartModifierProtocol[] childModifiers);

        // -(id<SCIChartModifierProtocol> _Nullable)itemByName:(NSString * _Nonnull)name;
        [Export("itemByName:")]
        [return: NullAllowed]
        ISCIChartModifierProtocol ItemByName(string name);

        // -(void)add:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("add:")]
        void Add(ISCIChartModifierProtocol item);

        // -(BOOL)remove:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("remove:")]
        bool Remove(ISCIChartModifierProtocol item);

        // -(id<SCIChartModifierProtocol> _Nullable)itemAt:(int)index;
        [Export("itemAt:")]
        [return: NullAllowed]
        ISCIChartModifierProtocol ItemAt(int index);

        // -(void)insert:(id<SCIChartModifierProtocol> _Nonnull)item At:(int)index;
        [Export("insert:At:")]
        void Insert(ISCIChartModifierProtocol item, int index);

        // -(id<SCIChartModifierProtocol> _Nullable)firstObject;
        [NullAllowed, Export("firstObject")]
        ISCIChartModifierProtocol FirstObject { get; }

        // -(BOOL)contains:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("contains:")]
        bool Contains(ISCIChartModifierProtocol item);

        // -(int)indexOf:(id<SCIChartModifierProtocol> _Nonnull)item;
        [Export("indexOf:")]
        int IndexOf(ISCIChartModifierProtocol item);

        // -(void)setModifier:(id<SCIChartModifierProtocol> _Nonnull)modifier atIndex:(unsigned int)index;
        [Export("setModifier:atIndex:")]
        void SetModifier(ISCIChartModifierProtocol modifier, uint index);

        // @property (nonatomic) BOOL handleGestureFirstOnly;
        [Export("handleGestureFirstOnly")]
        bool HandleGestureFirstOnly { get; set; }
    }

    // @interface Indexing (SCIChartModifierCollection)
    [Category]
    [BaseType(typeof(SCIChartModifierCollection))]
    interface SCIChartModifierCollection_Indexing
    {
        // -(id<SCIChartModifierProtocol> _Nullable)objectAtIndexedSubscript:(unsigned int)idx;
        [Export("objectAtIndexedSubscript:")]
        [return: NullAllowed]
        ISCIChartModifierProtocol ObjectAtIndexedSubscript(uint idx);

        // -(void)setObject:(id<SCIChartModifierProtocol> _Nonnull)obj atIndexedSubscript:(unsigned int)idx;
        [Export("setObject:atIndexedSubscript:")]
        void SetObject(ISCIChartModifierProtocol obj, uint idx);
    }
}