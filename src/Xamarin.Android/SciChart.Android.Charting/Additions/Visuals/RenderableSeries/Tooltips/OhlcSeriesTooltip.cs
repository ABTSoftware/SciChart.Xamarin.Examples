﻿using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries.HitTest;

namespace SciChart.Charting.Visuals.RenderableSeries.Tooltips
{
    public partial class OhlcSeriesTooltip
    {
        protected override void InternalUpdate(Object seriesInfo)
        {
            InternalUpdate((OhlcSeriesInfo) seriesInfo);
        }
    }
}