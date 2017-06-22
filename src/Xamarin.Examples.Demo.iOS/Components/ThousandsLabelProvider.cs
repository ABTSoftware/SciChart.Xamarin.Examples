using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Components
{
    public class ThousandsLabelProvider : SCINumericLabelProvider
    {
        public override string FormatLabel(IComparable dataValue)
        {
            return base.FormatLabel(ComparableUtil.ToDouble(dataValue) / 1000d) + "k";
        }
    }
}