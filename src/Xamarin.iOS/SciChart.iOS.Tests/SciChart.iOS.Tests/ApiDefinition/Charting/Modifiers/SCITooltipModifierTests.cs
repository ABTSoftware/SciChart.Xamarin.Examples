using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITooltipModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCITooltipModifier instance = new SCITooltipModifier();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setHitTestRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestWithProvider:Location:Radius:onData:hitTestMode:")));
        }
    }
}
