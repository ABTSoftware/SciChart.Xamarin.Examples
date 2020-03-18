using ObjCRuntime;
using System.Drawing;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public class FFTPaletteProvider : SCIPaletteProviderBase<SCIFastColumnRenderableSeries>, IISCIFillPaletteProvider, IISCIStrokePaletteProvider
    {
        private readonly SCIUnsignedIntegerValues _colors = new SCIUnsignedIntegerValues();

        SCIUnsignedIntegerValues IISCIFillPaletteProvider.FillColors => _colors;
        SCIUnsignedIntegerValues IISCIStrokePaletteProvider.StrokeColors => _colors;

        private readonly byte _minRed, _minGreen, _minBlue;
        private readonly int _diffRed, _diffGreen, _diffBlue;

        public FFTPaletteProvider() : this(Color.Green, Color.Red) { }

        public FFTPaletteProvider(Color minColor, Color maxColor)
        {
            _minRed = minColor.R;
            _minGreen = minColor.G;
            _minBlue = minColor.B;

            _diffRed = (int)maxColor.R - (int)minColor.R;
            _diffGreen = (int)maxColor.G - minColor.G;
            _diffBlue = (int)maxColor.B - minColor.B;
        }

        public override void Update()
        {
            var xyRenderPassData = Runtime.GetNSObject<SCIXyRenderPassData>(RenderableSeries.CurrentRenderPassData.Handle);

            var yCalc = xyRenderPassData.YCoordinateCalculator;
            var min = yCalc.MinAsDouble;
            var max = yCalc.MaxAsDouble;
            var diff = max - min;

            var yValues = xyRenderPassData.YValues;
            var size = xyRenderPassData.PointsCount;

            _colors.Clear();
            for (int i = 0; i < size; i++)
            {
                var yValue = yValues.GetValueAt(i);
                var fraction = (yValue - min) / diff;

                var red = Lerp(_minRed, _diffRed, fraction);
                var green = Lerp(_minGreen, _diffGreen, fraction);
                var blue = Lerp(_minBlue, _diffBlue, fraction);

                var color = (uint)Color.FromArgb(red, green, blue).ToArgb();

                _colors.Add(color);
            }
        }

        private static byte Lerp(byte minColor, int diffColor, double fraction)
        {
            var interpolatedValue = minColor + fraction * diffColor;
            var value = interpolatedValue < 0 ? 0 : interpolatedValue > 255 ? 255 : interpolatedValue;
            return (byte)value;
        }
    }
}
