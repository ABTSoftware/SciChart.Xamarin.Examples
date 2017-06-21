using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITextAnnotationStyleTests
    {
        [Test]
        public void testBindings()
        {
            SCITextAnnotationStyle instance = new SCITextAnnotationStyle();
            Assert.True(instance.RespondsToSelector(new Selector("textStyle")));
            Assert.True(instance.RespondsToSelector(new Selector("setTextStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("textColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setTextColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("backgroundColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setBackgroundColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("viewSetup")));
            Assert.True(instance.RespondsToSelector(new Selector("setViewSetup:")));
            Assert.True(instance.RespondsToSelector(new Selector("styleChanged")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyleChanged:")));
        }
    }
}
