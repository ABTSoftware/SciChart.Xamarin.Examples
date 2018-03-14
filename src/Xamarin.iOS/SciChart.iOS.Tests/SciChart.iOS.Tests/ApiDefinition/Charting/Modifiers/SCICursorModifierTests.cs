using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCICursorModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCICursorModifier instance = new SCICursorModifier();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setHitTestRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestWithProvider:Location:Radius:onData:hitTestMode:")));
        }
    }
}
