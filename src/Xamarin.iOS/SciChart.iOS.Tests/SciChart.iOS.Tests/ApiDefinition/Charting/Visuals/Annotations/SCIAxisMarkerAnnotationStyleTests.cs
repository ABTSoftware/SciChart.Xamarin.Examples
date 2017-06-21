using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAxisMarkerAnnotationStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCIAxisMarkerAnnotationStyle instance = new SCIAxisMarkerAnnotationStyle();
            Assert.True(instance.RespondsToSelector(new Selector("textStyle")));
            Assert.True(instance.RespondsToSelector(new Selector("setTextStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("textColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setTextColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("viewSetup")));
            Assert.True(instance.RespondsToSelector(new Selector("setViewSetup:")));
            Assert.True(instance.RespondsToSelector(new Selector("markerLinePen")));
            Assert.True(instance.RespondsToSelector(new Selector("setMarkerLinePen:")));
            Assert.True(instance.RespondsToSelector(new Selector("margin")));
            Assert.True(instance.RespondsToSelector(new Selector("setMargin:")));
            Assert.True(instance.RespondsToSelector(new Selector("backgroundColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setBackgroundColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("borderColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setBorderColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("borderWidth")));
            Assert.True(instance.RespondsToSelector(new Selector("setBorderWidth:")));
            Assert.True(instance.RespondsToSelector(new Selector("arrowSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setArrowSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("opacity")));
            Assert.True(instance.RespondsToSelector(new Selector("setOpacity:")));
            Assert.True(instance.RespondsToSelector(new Selector("styleChanged")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyleChanged:")));
        }
    }
}
