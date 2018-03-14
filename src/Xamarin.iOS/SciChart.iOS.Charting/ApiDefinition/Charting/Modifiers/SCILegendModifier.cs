using Foundation;
using ObjCRuntime;
using UIKit;

namespace SciChart.iOS.Charting
{
    // @interface SCILegendModifier : SCILegendModifierBase
    [BaseType(typeof(SCILegendModifierBase))]
    interface SCILegendModifier
    {
        // @property (readonly, nonatomic) Class<SCILegendCellProtocol> cellClass;
        [Export("cellClass")]
        ISCILegendItemViewProtocol CellClass { get; }

        // @property (nonatomic) SCILegendCellStyle * styleOfItemCell;
        [Export("styleOfItemCell", ArgumentSemantic.Assign)]
        SCILegendCellStyle StyleOfItemCell { get; set; }
    }
}