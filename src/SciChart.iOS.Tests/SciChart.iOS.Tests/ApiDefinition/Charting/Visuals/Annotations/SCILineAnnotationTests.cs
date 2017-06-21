using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILineAnnotationTests
    {
        [Test]
        public void TestBindings()
        {
            SCILineAnnotation instance = new SCILineAnnotation();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
        }
    }
}
