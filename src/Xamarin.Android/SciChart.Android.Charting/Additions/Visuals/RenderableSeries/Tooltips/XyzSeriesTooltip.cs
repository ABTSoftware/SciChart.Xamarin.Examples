using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries.HitTest;

namespace SciChart.Charting.Visuals.RenderableSeries.Tooltips
{
    public partial class XyzSeriesTooltip
    {
        protected override void InternalUpdate(Object seriesInfo)
        {
            InternalUpdate((XyzSeriesInfo) seriesInfo);
        }
    }
}