using Java.Lang;

namespace SciChart.Charting.Visuals.RenderableSeries.Tooltips
{
    public partial class StackedSeriesTooltip
    {
        public override Object Func(Object arg)
        {
            return (Object) Func((IStackedRenderableSeries) arg);
        }
    }
}