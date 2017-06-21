using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIDoubleAxisDeltaTests
    {
        [Test]
        public void TestBindings()
        {
            SCIDoubleAxisDelta instance = new SCIDoubleAxisDelta();
            Assert.True(instance.RespondsToSelector(new Selector("initWithMin:Max:")));
            Assert.True(instance.RespondsToSelector(new Selector("clone")));
            Assert.False(instance.RespondsToSelector(new Selector("setClone:")));
            Assert.True(instance.RespondsToSelector(new Selector("equals:")));
        }
    }
}
