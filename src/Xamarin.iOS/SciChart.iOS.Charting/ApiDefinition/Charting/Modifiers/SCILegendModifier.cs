using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Runtime.InteropServices;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendModifier : SCILegendModifierBase
    [BaseType(typeof(SCILegendModifierBase))]
    interface SCILegendModifier
    {
        // @property (readonly, nonatomic) UICollectionView * collectionView;
        [Export("collectionView")]
        UICollectionView CollectionView { get; }

        // @property (readonly, nonatomic) NSString * currentRegisteredReuseIdentifier;
        [Export("currentRegisteredReuseIdentifier")]
        string CurrentRegisteredReuseIdentifier { get; }

        // @property (readonly, nonatomic) Class<ISCILegendCellProtocol> cellClass;
        [Export("cellClass")]
        ISCILegendCellProtocol CellClass { get; }

        // @property (nonatomic) SCILegendCellStyle * styleOfItemCell;
        [Export("styleOfItemCell", ArgumentSemantic.Assign)]
        SCILegendCellStyle StyleOfItemCell { get; set; }

        // -(void)registerCellClass:(Class<ISCILegendCellProtocol>)cellClass withReuseIdentifier:(NSString *)identifier;
        [Export("registerCellClass:withReuseIdentifier:")]
        void RegisterCellClass(ISCILegendCellProtocol cellClass, string identifier);

        // -(void)registerCellNib:(UINib *)cellNib withReuseIdentifier:(NSString *)identifier;
        [Export("registerCellNib:withReuseIdentifier:")]
        void RegisterCellNib(UINib cellNib, string identifier);
    }
}