using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILineAnnotationStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCILineAnnotationStyle instance = new SCILineAnnotationStyle();
            Assert.True(instance.RespondsToSelector(new Selector("resizeMarker")));
            Assert.True(instance.RespondsToSelector(new Selector("setResizeMarker:")));
            Assert.True(instance.RespondsToSelector(new Selector("linePen")));
            Assert.True(instance.RespondsToSelector(new Selector("setLinePen:")));
            Assert.True(instance.RespondsToSelector(new Selector("selectRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setSelectRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("resizeRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setResizeRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("layer")));
            Assert.True(instance.RespondsToSelector(new Selector("setLayer:")));
            Assert.True(instance.RespondsToSelector(new Selector("styleChanged")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyleChanged:")));
        }
    }
}
