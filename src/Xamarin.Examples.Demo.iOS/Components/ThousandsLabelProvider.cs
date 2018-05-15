using Foundation;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Components
{
    public class ThousandsLabelProvider : SCINumericLabelProvider
    {
		public override NSAttributedString FormatLabel(SCIGenericType dataValue)
        {
			var formattedString = base.FormatLabel(new SCIGenericType(dataValue.doubleData / 1000d)).Value + "k";
            return new NSAttributedString(formattedString);
        }
    }
}