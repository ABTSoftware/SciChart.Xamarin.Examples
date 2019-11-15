using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public class ThousandsLabelProvider : SCILabelProviderBase<IISCINumericAxis>
    {
        public override IISCIString FormatLabel(IISCIComparable dataValue)
        {
            var formattedString = dataValue.ToDouble() / 1000d + "k";
            return formattedString.ToSciString();
        }

        public override IISCIString FormatCursorLabel(IISCIComparable dataValue) => FormatLabel(dataValue);
    }
}