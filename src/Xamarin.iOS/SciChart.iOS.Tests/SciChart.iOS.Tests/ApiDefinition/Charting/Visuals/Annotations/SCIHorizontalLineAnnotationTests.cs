using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIHorizontalLineAnnotationTests
    {
        [Test]
        public void TestBindings()
        {
            SCIHorizontalLineAnnotation instance = new SCIHorizontalLineAnnotation();
            Assert.True(instance.RespondsToSelector(new Selector("formattedValue")));
            Assert.True(instance.RespondsToSelector(new Selector("setFormattedValue:")));
            Assert.True(instance.RespondsToSelector(new Selector("addLabel:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeLabel:")));
            Assert.True(instance.RespondsToSelector(new Selector("labelAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeLabelAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
        }
    }
}
