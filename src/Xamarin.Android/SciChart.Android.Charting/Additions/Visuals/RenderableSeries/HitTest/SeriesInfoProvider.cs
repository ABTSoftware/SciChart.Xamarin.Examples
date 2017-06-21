using Android.Content;
using Java.Lang;
using SciChart.Charting.Visuals.RenderableSeries.Tooltips;

namespace SciChart.Charting.Visuals.RenderableSeries.HitTest
{
    public partial class DefaultBandSeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (BandSeriesInfo) seriesInfo, modifierType);
        }
    }

    public partial class DefaultErrorBarsSeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (ErrorBarsSeriesInfo) seriesInfo, modifierType);
        }
    }


    public partial class DefaultFixedErrorBarsSeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (FixedErrorBarsSeriesInfo) seriesInfo, modifierType);
        }
    }

    public partial class DefaultOhlcSeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (OhlcSeriesInfo) seriesInfo, modifierType);
        }
    }

    public partial class DefaultUniformHeatmapSeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (UniformHeatmapSeriesInfo) seriesInfo, modifierType);
        }
    }

    public partial class DefaultXySeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (XySeriesInfo) seriesInfo, modifierType);
        }
    }

    public partial class StackedSeriesCollectionInfoProviderBase
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (StackedSeriesInfo) seriesInfo, modifierType);
        }
    }

    public partial class DefaultXyzSeriesInfoProvider
    {
        protected override Object RawSeriesInfoInternal
        {
            get { return SeriesInfoInternal; }
        }

        protected override ISeriesTooltip GetSeriesTooltipInternal(Context context, Object seriesInfo, Class modifierType)
        {
            return GetSeriesTooltipInternal(context, (XyzSeriesInfo) seriesInfo, modifierType);
        }
    }
}