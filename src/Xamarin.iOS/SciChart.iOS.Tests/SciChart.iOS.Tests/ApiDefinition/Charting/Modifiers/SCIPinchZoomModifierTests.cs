using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIPinchZoomModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCIPinchZoomModifier instance = new SCIPinchZoomModifier();
            Assert.True(instance.RespondsToSelector(new Selector("gestureLocked")));
            Assert.False(instance.RespondsToSelector(new Selector("setGestureLocked:")));
        }
    }
}
