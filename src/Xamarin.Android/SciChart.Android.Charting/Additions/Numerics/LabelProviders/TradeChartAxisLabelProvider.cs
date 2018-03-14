using Java.Lang;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Data.Numerics.Math;

namespace SciChart.Charting.Numerics.LabelProviders
{
    public partial class TradeChartAxisLabelProvider
    {
        protected override double UpdateBarTimeFrame(Object axis, ISmartList baseXValues, IMath math)
        {
            return UpdateBarTimeFrame((CategoryDateAxis) axis, baseXValues, math);
        }
    }
}