using System;
using System.Drawing;
using SciChart.iOS.Charting;

namespace Xamarin.Examples.Demo.iOS
{
    public class DimTracePaletteProvider: SCIPaletteProviderBase<SCIXyRenderableSeriesBase>, IISCIStrokePaletteProvider
    {
        private readonly int _startAlpha;
        private readonly int _diffAlpha;

        public DimTracePaletteProvider(int startAlpha = 51)
        {
            _startAlpha = startAlpha;
            _diffAlpha = 255 - startAlpha;

            StrokeColors = new SCIUnsignedIntegerValues();
        }
        
        public SCIUnsignedIntegerValues StrokeColors { get; }

        public override void Update()
        {
            var defaultColor = RenderableSeries.StrokeStyle.Color;
            var size = RenderableSeries.CurrentRenderPassData.PointsCount;

            StrokeColors.Clear();

            for (int i = 0; i < size; i++)
            {
                var alpha = 1 - (_startAlpha + _diffAlpha * i / size);
                var color = defaultColor.Argb(alpha);
                StrokeColors.Add(color);
            }
        }
    }
}
