using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIRelativeZoomModifierBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCIRelativeZoomModifierBase instance = new SCIRelativeZoomModifierBase();
            Assert.True(instance.RespondsToSelector(new Selector("xyDirection")));
            Assert.True(instance.RespondsToSelector(new Selector("setXyDirection:")));
            Assert.True(instance.RespondsToSelector(new Selector("growFactor")));
            Assert.True(instance.RespondsToSelector(new Selector("setGrowFactor:")));
            Assert.True(instance.RespondsToSelector(new Selector("performZoomAt:XValue:YValue:")));
            Assert.True(instance.RespondsToSelector(new Selector("growByFraction:AtPoint:AtAxis:")));
        }
    }
}
