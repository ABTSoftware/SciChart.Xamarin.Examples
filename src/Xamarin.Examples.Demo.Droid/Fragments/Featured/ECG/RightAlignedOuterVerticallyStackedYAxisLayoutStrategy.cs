using Java.Lang;
using SciChart.Charting.LayoutManagers;
using SciChart.Charting.Visuals.Axes;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.ECG
{
    public class RightAlignedOuterVerticallyStackedYAxisLayoutStrategy : VerticalAxisLayoutStrategy
    {
        public override void MeasureAxes(int availableWidth, int availableHeight, ChartLayoutState chartLayoutState)
        {
            for (int i = 0, size = Axes.Count; i < size; i++)
            {
                var axis = (IAxis)Axes[i];

                axis.UpdateAxisMeasurements();

                var axisLayoutState = axis.AxisLayoutState;

                chartLayoutState.RightOuterAreaSize = Math.Max(GetRequiredAxisSize(axisLayoutState), chartLayoutState.RightOuterAreaSize);
            }
        }

        public override void LayoutAxes(int left, int top, int right, int bottom)
        {
            var size = Axes.Count;
            var height = bottom - top;

            var axisHeight = height / size;

            var topPlacement = top;

            for (int i = 0; i < size; i++)
            {
                var axis = (IAxis)Axes[i];

                var axisLayoutState = axis.AxisLayoutState;

                var bottomPlacement = Math.Round(topPlacement + axisHeight);

                axis.LayoutArea(left, topPlacement, left + GetRequiredAxisSize(axisLayoutState), bottomPlacement);

                topPlacement = bottomPlacement;
            }
        }
    }
}