using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIChartModifierBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCIChartModifierBase instance = new SCIChartModifierBase();
            Assert.True(instance.RespondsToSelector(new Selector("autoPassAreaCheck")));
            Assert.True(instance.RespondsToSelector(new Selector("setAutoPassAreaCheck")));
        }
    }
}
