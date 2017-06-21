using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIBoxAnnotationTests
    {
        [Test]
        public void TestBindings()
        {
            SCIBoxAnnotation instance = new SCIBoxAnnotation();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
        }
    }
}
