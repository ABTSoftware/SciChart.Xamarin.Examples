using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries;

namespace SciChart.Charting.Modifiers.Behaviors
{
    public partial class PieChartTooltipBehavior
    {
        public override Object Func(Object renderableSeries)
        {
            return (Object)Func((IPieRenderableSeries)renderableSeries);
        }
    }
}