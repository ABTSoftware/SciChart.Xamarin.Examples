using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries;

namespace SciChart.Charting.Modifiers.Behaviors
{
    public partial class TooltipBehavior
    {
        public override Object Func(Object renderableSeries)
        {
            return (Object) Func((IRenderableSeries) renderableSeries);
        }
    }
}