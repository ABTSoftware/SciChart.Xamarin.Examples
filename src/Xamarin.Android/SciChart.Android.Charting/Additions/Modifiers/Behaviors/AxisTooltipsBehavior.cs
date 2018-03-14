using Java.Lang;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;

namespace SciChart.Charting.Modifiers.Behaviors
{
    public partial class AxisTooltipsBehavior
    {
        public override Object Func(Object axis)
        {
            return (Object) Func((IAxis)axis);
        }
    }
}