using System;
using SciChart.iOS.Charting;
namespace Xamarin.Examples.Demo.iOS
{
    public class RightAlignedOuterVerticallyStackedYAxisLayoutStrategy: SCIVerticalAxisLayoutStrategy
    {
        public RightAlignedOuterVerticallyStackedYAxisLayoutStrategy()
        {
        }

        public override void MeasureAxesWithAvailableWidth(nfloat width, nfloat height, SCIChartLayoutState chartLayoutState)
        {

            foreach (IISCIAxis axis in Axes)
            {
                axis.UpdateAxisMeasurements();
                chartLayoutState.RightOuterAreaSize = Math.Max((float)GetRequiredAxisSizeFrom(axis.AxisLayoutState), (float)chartLayoutState.RightOuterAreaSize);
            }
        }

        public override void LayoutWithLeft(nfloat left, nfloat top, nfloat right, nfloat bottom)
        {
            var size = Axes.Count;
            var height = bottom - top;

            var axisHeight = height / size;

            var topPlacement = top;

            foreach (IISCIAxis axis in Axes)
            {
                float bottomPlacement = (float)Math.Round(topPlacement + axisHeight);
                axis.LayoutArea(left, topPlacement, left + GetRequiredAxisSizeFrom(axis.AxisLayoutState), bottomPlacement);
                topPlacement = bottomPlacement;
            }
        }
    }
}
