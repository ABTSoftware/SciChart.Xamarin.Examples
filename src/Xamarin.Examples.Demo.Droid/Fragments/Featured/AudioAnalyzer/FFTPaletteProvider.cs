using System.Drawing;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;
using SciChart.Charting.Visuals.RenderableSeries.PaletteProviders;
using SciChart.Core.Model;
using SciChart.Core.Utility;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.AudioAnalyzer
{
    public class FFTPaletteProvider : PaletteProviderBase<FastColumnRenderableSeries>, IFillPaletteProvider, IStrokePaletteProvider {
        private readonly IntegerValues _colors = new IntegerValues();

        public IntegerValues FillColors => _colors;
        public IntegerValues StrokeColors => _colors;

        private readonly byte _minRed, _minGreen, _minBlue;
        private readonly byte _diffRed, _diffGreen, _diffBlue;

        public FFTPaletteProvider() : this(Color.Green, Color.Red)
        {

        }

        public FFTPaletteProvider(Color minColor, Color maxColor)
        {
            _minRed = minColor.R;
            _minGreen = minColor.G;
            _minBlue = minColor.B;

            _diffRed = (byte) (maxColor.R - minColor.R);
            _diffGreen = (byte)(maxColor.G - minColor.G);
            _diffBlue = (byte)(maxColor.B - minColor.B);
        }

        public override void Update()
        {
            var xyRenderPassData = (XyRenderPassData)RenderableSeries.CurrentRenderPassData;

            var yCalc = xyRenderPassData.YCoordinateCalculator;
            var min = yCalc.MinAsDouble;
            var max = yCalc.MaxAsDouble;
            var diff = max - min;

            var yValues = xyRenderPassData.YValues;
            var size = xyRenderPassData.PointsCount();

            _colors.Clear();
            for (int i = 0; i < size; i++)
            {
                var yValue = yValues.Get(i);
                var fraction = (yValue - min) / diff;

                var red = Lerp(_minRed, _diffRed, fraction);
                var green = Lerp(_minGreen, _diffGreen, fraction);
                var blue = Lerp(_minBlue, _diffBlue, fraction);

                var color = Color.FromArgb(red, green, blue).ToArgb();

                _colors.Add(color);
            }
        }


        private static byte Lerp(byte minColor, byte diffColor, double fraction)
        {
            var interpolatedValue = minColor + fraction * diffColor;
            return (byte)NumberUtil.Constrain(interpolatedValue, 0, 255);
        }
    }
}