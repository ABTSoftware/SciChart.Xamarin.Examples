using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS.Components
{
    public class BillionsLabelProvider : SCINumericLabelProvider
    {
        public override string FormatLabel(SCIGenericType dataValue)
        {
            return base.FormatLabel(new SCIGenericType(dataValue.doubleData / Math.Pow(10, 9))) + "B";
        }
    }
}