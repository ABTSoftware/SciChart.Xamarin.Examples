using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCISeriesSelectionModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCISeriesSelectionModifier instance = new SCISeriesSelectionModifier();
            Assert.True(instance.RespondsToSelector(new Selector("hitTestMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setHitTestMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("hitTestRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setHitTestRadius:")));
        }
    }
}
