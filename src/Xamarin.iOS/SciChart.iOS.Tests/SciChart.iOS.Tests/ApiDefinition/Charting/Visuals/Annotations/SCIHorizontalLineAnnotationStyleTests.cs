using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIHorizontalLineAnnotationStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCIHorizontalLineAnnotationStyle instance = new SCIHorizontalLineAnnotationStyle();
            Assert.True(instance.RespondsToSelector(new Selector("horizontalAlignment")));
            Assert.True(instance.RespondsToSelector(new Selector("setHorizontalAlignment:")));
        }
    }
}
