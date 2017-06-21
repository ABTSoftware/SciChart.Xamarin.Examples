using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCINiceDoubleScaleTests
    {
        [Test]
        public void TestBindings()
        {
            SCINiceDoubleScale instance = new SCINiceDoubleScale();
            Assert.True(instance.RespondsToSelector(new Selector("initWithMin:Max:MinorsPerMajor:MaxTicks:")));
            Assert.True(instance.RespondsToSelector(new Selector("niceRange")));
            Assert.True(instance.RespondsToSelector(new Selector("niceNumWithRange:Round:")));
        }
    }
}
