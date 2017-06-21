using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAxisPinchZoomModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCIAxisPinchZoomModifier instance = new SCIAxisPinchZoomModifier();
            Assert.True(instance.RespondsToSelector(new Selector("axisId")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisId:")));
            Assert.True(instance.RespondsToSelector(new Selector("gestureLocked")));
            Assert.False(instance.RespondsToSelector(new Selector("setGestureLocked")));
        }
    }
}
