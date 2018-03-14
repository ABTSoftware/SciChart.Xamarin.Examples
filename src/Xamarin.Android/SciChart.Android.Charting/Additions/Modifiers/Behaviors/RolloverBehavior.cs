using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Tooltips;
using Java.Lang;

namespace SciChart.Charting.Modifiers.Behaviors
{
    public partial class RolloverBehavior
    {
        public override Object Func(Object renderableSeries)
        {
            return (Object) Func((IRenderableSeries) renderableSeries);
        }
    }
}