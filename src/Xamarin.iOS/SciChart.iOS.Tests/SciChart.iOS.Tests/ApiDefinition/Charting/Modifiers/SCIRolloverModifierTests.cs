using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIRolloverModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCIRolloverModifier instance = new SCIRolloverModifier();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setSstyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setHitTestRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestWithProvider:Location:Radius:onData:hitTestMode:")));
        }
    }
}
