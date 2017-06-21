using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIChartSurfaceTests
    {
        [Test]
        public void TestBindings()
        {
            SCIChartSurface instance = new SCIChartSurface();
            Assert.True(instance.RespondsToSelector(new Selector("initWithView:")));
            Assert.True(instance.RespondsToSelector(new Selector("xAxis")));
            Assert.True(instance.RespondsToSelector(new Selector("setXAxis:")));
            Assert.True(instance.RespondsToSelector(new Selector("yAxis")));
            Assert.True(instance.RespondsToSelector(new Selector("setYAxis:")));
            Assert.True(instance.RespondsToSelector(new Selector("clipUnderlayAnnotations")));
            Assert.True(instance.RespondsToSelector(new Selector("setClipUnderlayAnnotations:")));
            Assert.True(instance.RespondsToSelector(new Selector("clipOverlayAnnotations")));
            Assert.True(instance.RespondsToSelector(new Selector("setClipOverlayAnnotations:")));
        }
    }
}
