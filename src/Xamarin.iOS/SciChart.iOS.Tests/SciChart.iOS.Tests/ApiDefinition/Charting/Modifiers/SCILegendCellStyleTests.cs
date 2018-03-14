using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILegendCellStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCILegendCellStyle instance = new SCILegendCellStyle();
            Assert.True(instance.RespondsToSelector(new Selector("seriesNameFont")));
            Assert.True(instance.RespondsToSelector(new Selector("setSeriesNameFont:")));
            Assert.True(instance.RespondsToSelector(new Selector("seriesNameTextColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setSeriesNameTextColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("checkedBoxImage")));
            Assert.True(instance.RespondsToSelector(new Selector("setCheckedBoxImage:")));
            Assert.True(instance.RespondsToSelector(new Selector("uncheckedBoxImage")));
            Assert.True(instance.RespondsToSelector(new Selector("setUncheckedBoxImage:")));
            Assert.True(instance.RespondsToSelector(new Selector("borderWidthMarkerView")));
            Assert.True(instance.RespondsToSelector(new Selector("setBorderWidthMarkerView:")));
            Assert.True(instance.RespondsToSelector(new Selector("borderColorMarkerView")));
            Assert.True(instance.RespondsToSelector(new Selector("setBborderColorMarkerView:")));
            Assert.True(instance.RespondsToSelector(new Selector("cornerRadiusMarkerView")));
            Assert.True(instance.RespondsToSelector(new Selector("setCornerRadiusMarkerView:")));
            Assert.True(instance.RespondsToSelector(new Selector("sizeMarkerView")));
            Assert.True(instance.RespondsToSelector(new Selector("setSizeMarkerView:")));
        }
    }
}
