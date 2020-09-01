using Java.Lang;
using SciChart.Charting.Numerics.LabelProviders;
using SciChart.Core.Utility;

namespace Xamarin.Examples.Demo.Droid.Components
{
    public class ThousandsLabelProvider : NumericLabelProvider
    {
        public override ICharSequence FormatLabelFormatted(double dataValue)
        {
            return new String(base.FormatLabelFormatted((Double)(dataValue / 1000d)) + "k");
        }
    }
}