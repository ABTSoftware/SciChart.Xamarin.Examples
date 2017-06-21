using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIZoomExtentsModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCIZoomExtentsModifier instance = new SCIZoomExtentsModifier();
            Assert.True(instance.RespondsToSelector(new Selector("isAnimated")));
            Assert.True(instance.RespondsToSelector(new Selector("setIsAnimated:")));
            Assert.True(instance.RespondsToSelector(new Selector("xyDirection")));
            Assert.True(instance.RespondsToSelector(new Selector("setXyDirection:")));
        }
    }
}
