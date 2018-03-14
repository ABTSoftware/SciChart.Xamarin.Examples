using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILegendItemTests
    {
        [Test]
        public void TestBindings()
        {
            SCILegendItem instance = new SCILegendItem();
            Assert.True(instance.RespondsToSelector(new Selector("markerColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setMarkerColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("isVisible")));
            Assert.True(instance.RespondsToSelector(new Selector("setIsVisible:")));
            Assert.True(instance.RespondsToSelector(new Selector("showMarker")));
            Assert.True(instance.RespondsToSelector(new Selector("setShowMarker:")));
            Assert.True(instance.RespondsToSelector(new Selector("showCheckBoxes")));
            Assert.True(instance.RespondsToSelector(new Selector("setShowCheckBoxes:")));
            Assert.True(instance.RespondsToSelector(new Selector("seriesName")));
            Assert.True(instance.RespondsToSelector(new Selector("setSeriesName:")));
            Assert.True(instance.RespondsToSelector(new Selector("renderebleSeries")));
            Assert.False(instance.RespondsToSelector(new Selector("setRenderebleSeries:")));
            Assert.True(instance.RespondsToSelector(new Selector("initWithRenderebleSeries:")));
        }
    }
}
