using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIVerticalLineAnnotationStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCIVerticalLineAnnotationStyle instance = new SCIVerticalLineAnnotationStyle();
            Assert.True(instance.RespondsToSelector(new Selector("verticalAlignment")));
            Assert.True(instance.RespondsToSelector(new Selector("setVerticalAlignment:")));
        }
    }
}
