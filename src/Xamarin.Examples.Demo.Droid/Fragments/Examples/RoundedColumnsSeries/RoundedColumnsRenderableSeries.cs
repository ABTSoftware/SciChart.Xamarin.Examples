using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Charting.Visuals.RenderableSeries.Data;
using SciChart.Charting.Visuals.RenderableSeries.HitTest;
using SciChart.Core.Model;
using SciChart.Drawing.Common;

namespace Xamarin.Examples.Demo.Droid
{
    public class RoundedColumnsRenderableSeries: FastColumnRenderableSeries
    {
        private FloatValues topEllipsesBuffer = new FloatValues();
        private FloatValues rectsBuffer = new FloatValues();
        private FloatValues bottomEllipsesBuffer = new FloatValues();

        public RoundedColumnsRenderableSeries() : base(new ColumnRenderPassData(), new ColumnHitProvider(), new NearestColumnPointProvider())
        {
        }

        protected override void DisposeCachedData()
        {
            base.DisposeCachedData();

            topEllipsesBuffer.DisposeItems();
            rectsBuffer.DisposeItems();
            bottomEllipsesBuffer.DisposeItems();
        }

        protected override void InternalDraw(IRenderContext2D renderContext, IAssetManager2D assetManager, ISeriesRenderPassData renderPassData)
        {
            // Don't draw transparent series
            if (Opacity == 0) return;

            if (FillBrushStyle == null || !FillBrushStyle.IsVisible) return;

            ColumnRenderPassData rpd = (ColumnRenderPassData)renderPassData;
            float diameter = rpd.ColumnPixelWidth;
            updateDrawingBuffers(rpd, diameter, rpd.ZeroLineCoord);

            IBrush2D brush = assetManager.CreateBrush(FillBrushStyle);
            renderContext.FillRects(rectsBuffer.GetItemsArray(), 0, rectsBuffer.Size(), brush);
            renderContext.DrawEllipses(topEllipsesBuffer.GetItemsArray(), 0, topEllipsesBuffer.Size(), diameter, diameter, brush);
            renderContext.DrawEllipses(bottomEllipsesBuffer.GetItemsArray(), 0, bottomEllipsesBuffer.Size(), diameter, diameter, brush);
        }

        void updateDrawingBuffers(ColumnRenderPassData renderPassData, float columnPixelWidth, float zeroLine)
        {
            float halfWidth = columnPixelWidth / 2;

            topEllipsesBuffer.SetSize(renderPassData.PointsCount() * 2);
            rectsBuffer.SetSize(renderPassData.PointsCount() * 4);
            bottomEllipsesBuffer.SetSize(renderPassData.PointsCount() * 2);

            float[] xCoordsArray = renderPassData.XCoords.GetItemsArray();
            float[] yCoordsArray = renderPassData.YCoords.GetItemsArray();
            for (int i = 0, count = renderPassData.PointsCount(); i < count; i++)
            {
                float x = xCoordsArray[i];
                float y = yCoordsArray[i];

                topEllipsesBuffer.Set(i * 2, x);
                topEllipsesBuffer.Set(i * 2 + 1, y - halfWidth);

                rectsBuffer.Set(i * 4, x - halfWidth);
                rectsBuffer.Set(i * 4 + 1, y - halfWidth);
                rectsBuffer.Set(i * 4 + 2, x + halfWidth);
                rectsBuffer.Set(i * 4 + 3, zeroLine + halfWidth);

                bottomEllipsesBuffer.Set(i * 2, x);
                bottomEllipsesBuffer.Set(i * 2 + 1, zeroLine + halfWidth);
            }
        }
    }
}
