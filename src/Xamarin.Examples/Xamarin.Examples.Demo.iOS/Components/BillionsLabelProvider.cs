using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Components
{
    public class BillionsLabelProvider : SCINumericLabelProvider
    {
        public override string FormatLabel(IComparable dataValue)
        {
            return base.FormatLabel(ComparableUtil.ToDouble(dataValue) / Math.Pow(10, 9)) + "B";
        }
    }
}