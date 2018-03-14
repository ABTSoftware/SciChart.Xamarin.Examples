using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIZoomPanModifierBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCIZoomPanModifierBase instance = new SCIZoomPanModifierBase();
            Assert.True(instance.RespondsToSelector(new Selector("xyDirection")));
            Assert.True(instance.RespondsToSelector(new Selector("setXyDirection:")));
            Assert.True(instance.RespondsToSelector(new Selector("clipModeX")));
            Assert.True(instance.RespondsToSelector(new Selector("setClipModeX:")));
            Assert.True(instance.RespondsToSelector(new Selector("zoomExtentsY")));
            Assert.True(instance.RespondsToSelector(new Selector("setZoomExtentsY:")));
            Assert.True(instance.RespondsToSelector(new Selector("gestureLocked")));
            Assert.False(instance.RespondsToSelector(new Selector("setGestureLocked:")));
            Assert.True(instance.RespondsToSelector(new Selector("panFrom:To:Start:")));
        }
    }
}
