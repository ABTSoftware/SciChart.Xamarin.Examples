using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILineAnnotationLabelTests
    {
        [Test]
        public void TestBindings()
        {
            SCILineAnnotationLabel instance = new SCILineAnnotationLabel();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("applyStyle")));
        }
    }
}
