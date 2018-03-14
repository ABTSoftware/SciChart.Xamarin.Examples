namespace SciChart.Charting.Modifiers
{
    public partial class PieChartModifierBase
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