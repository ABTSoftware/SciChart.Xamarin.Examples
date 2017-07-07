using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Components
{
    public class ThousandsLabelProvider : SCINumericLabelProvider
    {
        public override string FormatLabel(SCIGenericType dataValue)
        {
            return base.FormatLabel(new SCIGenericType(dataValue.doubleData / 1000d)) + "k";
        }
    }
}