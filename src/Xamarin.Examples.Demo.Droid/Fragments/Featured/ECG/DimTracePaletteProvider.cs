using System.Drawing;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.PaletteProviders;
using SciChart.Core.Model;

namespace Xamarin.Examples.Demo.Droid.Fragments.Featured.ECG
{
    public class DimTracePaletteProvider : PaletteProviderBase<XyRenderableSeriesBase>, IStrokePaletteProvider
    {
        private readonly int _startAlpha;
        private readonly int _diffAlpha;

        public DimTracePaletteProvider(int startAlpha = 51)
        {
            _startAlpha = startAlpha;
            _diffAlpha = 255 - startAlpha;

            StrokeColors = new IntegerValues();
        }
        public IntegerValues StrokeColors { get; }

        public override void Update()
        {
            var defaultColor = Color.FromArgb(RenderableSeries.StrokeStyle.Color);
            var size = RenderableSeries.CurrentRenderPassData.PointsCount();

            StrokeColors.Clear();

            for (int i = 0; i < size; i++)
            {
                var alpha = _startAlpha + _diffAlpha * i / size;

                StrokeColors.Add(Color.FromArgb(alpha, defaultColor).ToArgb());
            }
        }

    }
}