using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries.HitTest;

namespace SciChart.Charting.Visuals.RenderableSeries.Tooltips
{
    public partial class BandSeriesTooltip
    {
        protected override void InternalUpdate(Object seriesInfo)
        {
            InternalUpdate((BandSeriesInfo) seriesInfo);
        }
    }
}