using SciChart.iOS.Charting;
using ObjCRuntime;

namespace Xamarin.Examples.Demo.iOS
{
    public class RoundedColumnRenderableSeries: SCIFastColumnRenderableSeries
    {
        private const double cornerRadius = 20.0;
        private readonly SCIFloatValues rectsBuffer = new SCIFloatValues();

        public RoundedColumnRenderableSeries() : base(new SCIColumnRenderPassData(), new SCIColumnHitProvider(), new SCINearestColumnPointProvider())
        {
        }

        protected override void DisposeCachedData()
        {
            base.DisposeCachedData();

            rectsBuffer.Dispose();
        }

        protected override void InternalDraw(IISCIRenderContext2D renderContext, IISCIAssetManager2D assetManager, IISCISeriesRenderPassData renderPassData)
        {
            // Don't draw transparent series
            if (Opacity == 0) return;

            SCIBrushStyle fillStyle = FillBrushStyle;
            if (fillStyle == null || !fillStyle.IsVisible) return;

            SCIColumnRenderPassData rpd = Runtime.GetNSObject<SCIColumnRenderPassData>(renderPassData.Handle);
            updateDrawingBuffersWithData(rpd, rpd.ColumnPixelWidth, rpd.ZeroLineCoord);

            IISCIBrush2D brush = assetManager.BrushWithStyle(fillStyle);
            renderContext.DrawRoundedRects(rectsBuffer.ItemsArray, 0, rectsBuffer.Count, null, brush, cornerRadius, cornerRadius);
        }

        void updateDrawingBuffersWithData(SCIColumnRenderPassData renderPassData, float columnPixelWidth, float zeroLine)
        {
            float halfWidth = columnPixelWidth / 2;

            rectsBuffer.Count = renderPassData.PointsCount * 4;

            for (var i = 0; i < renderPassData.PointsCount; i++)
            {
                float x = renderPassData.XCoords.GetValueAt(i);
                float y = renderPassData.YCoords.GetValueAt(i);

                rectsBuffer.Set(x - halfWidth, i * 4);
                rectsBuffer.Set(y - halfWidth, i * 4 + 1);
                rectsBuffer.Set(x + halfWidth, i * 4 + 2);
                rectsBuffer.Set(zeroLine + halfWidth, i * 4 + 3);
            }
        }
    }
}
