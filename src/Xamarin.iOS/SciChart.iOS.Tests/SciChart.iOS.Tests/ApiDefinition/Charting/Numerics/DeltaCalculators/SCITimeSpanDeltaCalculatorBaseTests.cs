using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITimeSpanDeltaCalculatorBaseTests
    {
        [Test]
        public void testBindings()
        {
            SCITimeSpanDeltaCalculatorBase instance = new SCITimeSpanDeltaCalculatorBase();
            Assert.True(instance.RespondsToSelector(new Selector("getTicks:")));
        }
    }
}
