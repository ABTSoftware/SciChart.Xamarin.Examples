using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAxisDragModifierBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCIAxisDragModifierBase instance = new SCIAxisDragModifierBase();
            Assert.True(instance.RespondsToSelector(new Selector("axisId")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisId:")));
            Assert.True(instance.RespondsToSelector(new Selector("dragMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setDragMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("gestureLocked")));
            Assert.False(instance.RespondsToSelector(new Selector("setGestureLocked")));
            Assert.True(instance.RespondsToSelector(new Selector("getIsSecondHalfPoint:Frame:IsHorizontal:")));
            Assert.True(instance.RespondsToSelector(new Selector("getCurrentAxis")));
            Assert.True(instance.RespondsToSelector(new Selector("performPanFrom:To:")));
            Assert.True(instance.RespondsToSelector(new Selector("performScaleFrom:To:IsSecondHalf:")));
        }
    }
}
