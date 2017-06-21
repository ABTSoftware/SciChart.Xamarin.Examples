using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCINiceLogScaleTests
    {
        [Test]
        public void TestBindings()
        {
            SCINiceLogScale instance = new SCINiceLogScale();
            Assert.True(instance.RespondsToSelector(new Selector("initWithMin:Max:LogBase:MinorsPerMajor:MaxTicks:")));
        }
    }
}
