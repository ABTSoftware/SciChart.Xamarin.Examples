using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITextAnnotationTests
    {
        [Test]
        public void TestBindings()
        {
            SCITextAnnotation instance = new SCITextAnnotation();
            Assert.True(instance.RespondsToSelector(new Selector("text")));
            Assert.True(instance.RespondsToSelector(new Selector("setText:")));
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
        }
    }
}
