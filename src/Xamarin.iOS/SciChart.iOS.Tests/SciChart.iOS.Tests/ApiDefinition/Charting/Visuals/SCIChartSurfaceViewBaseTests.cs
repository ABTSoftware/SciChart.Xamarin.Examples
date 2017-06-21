using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIChartSurfaceViewBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCIChartSurfaceViewBase instance = new SCIChartSurfaceViewBase();
            Assert.True(instance.RespondsToSelector(new Selector("renderSurface")));
            Assert.True(instance.RespondsToSelector(new Selector("setRenderSurface:")));
            Assert.True(instance.RespondsToSelector(new Selector("renderSurfaceSizeView")));
            Assert.True(instance.RespondsToSelector(new Selector("setRenderSurfaceSizeView:")));
            Assert.True(instance.RespondsToSelector(new Selector("leftAxesArea")));
            Assert.True(instance.RespondsToSelector(new Selector("setLeftAxesArea:")));
            Assert.True(instance.RespondsToSelector(new Selector("rightAxesArea")));
            Assert.True(instance.RespondsToSelector(new Selector("setRightAxesArea:")));
            Assert.True(instance.RespondsToSelector(new Selector("topAxesArea")));
            Assert.True(instance.RespondsToSelector(new Selector("setTopAxesArea:")));
            Assert.True(instance.RespondsToSelector(new Selector("bottomAxesArea")));
            Assert.True(instance.RespondsToSelector(new Selector("setBottomAxesArea:")));

            Assert.True(instance.RespondsToSelector(new Selector("chartTitleLabel")));
            Assert.True(instance.RespondsToSelector(new Selector("setChartTitleLabel:")));
            Assert.True(instance.RespondsToSelector(new Selector("chartTitleHolderView")));
            Assert.True(instance.RespondsToSelector(new Selector("setChartTitleHolderView:")));

            Assert.True(instance.RespondsToSelector(new Selector("leftAxisAreaSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setLeftAxisAreaSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("rightAxisAreaSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setRightAxisAreaSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("topAxisAreaSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setTopAxisAreaSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("bottomAxisAreaSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setBottomAxisAreaSize:")));

            Assert.True(instance.RespondsToSelector(new Selector("leftAxisAreaForcedSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setLeftAxisAreaForcedSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("rightAxisAreaForcedSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setRightAxisAreaForcedSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("topAxisAreaForcedSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setTopAxisAreaForcedSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("bottomAxisAreaForcedSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setBottomAxisAreaForcedSize:")));

            Assert.True(instance.RespondsToSelector(new Selector("onLayoutSubviews")));
            Assert.True(instance.RespondsToSelector(new Selector("setOnLayoutSubviews:")));

            Assert.True(instance.RespondsToSelector(new Selector("leftPanelSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setLeftPanelSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("leftPanelSizeLimit")));
            Assert.True(instance.RespondsToSelector(new Selector("setLeftPanelSizeLimit:")));

            Assert.True(instance.RespondsToSelector(new Selector("rightPanelSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setRightPanelSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("rightPanelSizeLimit")));
            Assert.True(instance.RespondsToSelector(new Selector("setRightPanelSizeLimit:")));

            Assert.True(instance.RespondsToSelector(new Selector("topPanelSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setTopPanelSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("topPanelSizeLimit")));
            Assert.True(instance.RespondsToSelector(new Selector("setTopPanelSizeLimit:")));

            Assert.True(instance.RespondsToSelector(new Selector("bottomPanelSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setBottomPanelSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("bottomPanelSizeLimit")));
            Assert.True(instance.RespondsToSelector(new Selector("setBottomPanelSizeLimit:")));

            Assert.True(instance.RespondsToSelector(new Selector("axisAreasNeedResizing")));
            Assert.True(instance.RespondsToSelector(new Selector("setChartTitleLabelInsets:")));
        }
    }
}
