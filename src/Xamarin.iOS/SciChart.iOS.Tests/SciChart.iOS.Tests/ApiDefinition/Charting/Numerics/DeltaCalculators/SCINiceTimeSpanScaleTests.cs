using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCINiceTimeSpanScaleTests
    {
        [Test]
        public void TestBindings()
        {
            SCINiceTimeSpanScale instance = new SCINiceTimeSpanScale();
            Assert.True(instance.RespondsToSelector(new Selector("initWithMin:Max:MinorsPerMajor:MaxTicks:")));
            Assert.True(instance.RespondsToSelector(new Selector("tickSpacing")));
            Assert.False(instance.RespondsToSelector(new Selector("setTickSpacing:")));
            Assert.True(instance.RespondsToSelector(new Selector("niceRange")));
            Assert.False(instance.RespondsToSelector(new Selector("setNiceRange:")));
        }
    }
}
