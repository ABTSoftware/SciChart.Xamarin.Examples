using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILegendCellTests
    {
        [Test]
        public void TestBindings()
        {
            SCILegendCell instance = new SCILegendCell();
            Assert.True(instance.RespondsToSelector(new Selector("checkBoxButton")));
            Assert.True(instance.RespondsToSelector(new Selector("setCheckBoxButton:")));
            Assert.True(instance.RespondsToSelector(new Selector("markerView")));
            Assert.True(instance.RespondsToSelector(new Selector("setMarkerView:")));
            Assert.True(instance.RespondsToSelector(new Selector("seriesNameLabel")));
            Assert.True(instance.RespondsToSelector(new Selector("setSeriesNameLabel:")));
            Assert.True(instance.RespondsToSelector(new Selector("setCustomStyleForCell:")));
        }
    }
}
