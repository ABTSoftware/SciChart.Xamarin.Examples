using System;
using Foundation;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Components
{
    public class BillionsLabelProvider : SCINumericLabelProvider
    {
		public override NSAttributedString FormatLabel(SCIGenericType dataValue)
        {
			var formattedString = base.FormatLabel(new SCIGenericType(dataValue.doubleData / Math.Pow(10, 9))).Value + "B";
			return new NSAttributedString(formattedString);
        }
    }
}