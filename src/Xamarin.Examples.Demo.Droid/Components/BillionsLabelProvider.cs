using Java.Lang;
using SciChart.Charting.Numerics.LabelProviders;
using SciChart.Core.Utility;

namespace Xamarin.Examples.Demo.Droid.Components
{
    public class BillionsLabelProvider : NumericLabelProvider
    {
        public override ICharSequence FormatLabelFormatted(double dataValue)
        {
            return new String(base.FormatLabelFormatted((Double)(dataValue / Math.Pow(10, 9))) + "B");
        }
    }
}