namespace SciChart.Charting.Modifiers
{
    public partial class ChartModifierBase
    {
        bool IChartModifierBase.IsEnabled
        {
            get { return IsEnabled; }
            set
            {
                SetIsEnabled(value);
            }
        }
    }
}