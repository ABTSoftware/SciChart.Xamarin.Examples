using SciChart.iOS.Charting;
using ObjCRuntime;

namespace Xamarin.Examples.Demo.iOS
{
    public class RoundedColumnRenderableSeries: SCIFastColumnRenderableSeries
    {
        private readonly SCIFloatValues topEllipsesBuffer = new SCIFloatValues();
        private readonly SCIFloatValues rectsBuffer = new SCIFloatValues();
        private readonly SCIFloatValues bottomEllipsesBuffer = new SCIFloatValues();

        public RoundedColumnRenderableSeries() : base(new SCIColumnRenderPassData(), new SCIColumnHitProvider(), new SCINearestColumnPointProvider())
        {
        }

        protected override void DisposeCachedData()
        {
            base.DisposeCachedData();

            topEllipsesBuffer.Dispose();
            rectsBuffer.Dispose();
            bottomEllipsesBuffer.Dispose();
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
            renderContext.FillRects(rectsBuffer.ItemsArray, 0, rectsBuffer.Count, brush);
            renderContext.FillEllipses(topEllipsesBuffer.ItemsArray, 0, topEllipsesBuffer.Count, brush);
            renderContext.FillEllipses(bottomEllipsesBuffer.ItemsArray, 0, bottomEllipsesBuffer.Count, brush);
        }

        void updateDrawingBuffersWithData(SCIColumnRenderPassData renderPassData, float columnPixelWidth, float zeroLine)
        {
            float halfWidth = columnPixelWidth / 2;

            topEllipsesBuffer.Count = renderPassData.PointsCount * 4;
            rectsBuffer.Count = renderPassData.PointsCount * 4;
            bottomEllipsesBuffer.Count = renderPassData.PointsCount * 4;

            for (var i = 0; i < renderPassData.PointsCount; i++)
            {
                float x = renderPassData.XCoords.GetValueAt(i);
                float y = renderPassData.YCoords.GetValueAt(i);

                topEllipsesBuffer.Set(x - halfWidth, i * 4);
                topEllipsesBuffer.Set(y, i * 4 + 1);
                topEllipsesBuffer.Set(x + halfWidth, i * 4 + 2);
                topEllipsesBuffer.Set(y - columnPixelWidth, i * 4 + 3);

                rectsBuffer.Set(x - halfWidth, i * 4);
                rectsBuffer.Set(y - halfWidth, i * 4 + 1);
                rectsBuffer.Set(x + halfWidth, i * 4 + 2);
                rectsBuffer.Set(zeroLine + halfWidth, i * 4 + 3);

                bottomEllipsesBuffer.Set(x - halfWidth, i * 4);
                bottomEllipsesBuffer.Set(zeroLine + columnPixelWidth, i * 4 + 1);
                bottomEllipsesBuffer.Set(x + halfWidth, i * 4 + 2);
                bottomEllipsesBuffer.Set(zeroLine, i * 4 + 3);
            }
        }
    }
}
