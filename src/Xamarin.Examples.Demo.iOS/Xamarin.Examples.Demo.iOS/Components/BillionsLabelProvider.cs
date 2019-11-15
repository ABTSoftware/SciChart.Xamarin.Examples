using System;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public class BillionsLabelProvider : SCILabelProviderBase<IISCINumericAxis>
    {
        public override IISCIString FormatLabel(IISCIComparable dataValue)
        {
            var formattedString = dataValue.ToDouble() / Math.Pow(10, 9) + "B";
            return formattedString.ToSciString();
        }

        public override IISCIString FormatCursorLabel(IISCIComparable dataValue) => FormatLabel(dataValue);
    }
}