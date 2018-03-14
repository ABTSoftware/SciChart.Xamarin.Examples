using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries.HitTest;

namespace SciChart.Charting.Visuals.RenderableSeries.Tooltips
{
    public partial class HlSeriesTooltip
    {
        protected override void InternalUpdate(Object seriesInfo)
        {
            InternalUpdate((HlSeriesInfo) seriesInfo);
        }
    }
}