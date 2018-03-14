using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCINumericDeltaCalculatorBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCINumericDeltaCalculatorBase instance = new SCINumericDeltaCalculatorBase();
            Assert.True(instance.RespondsToSelector(new Selector("getScaleWithMin:Max:MinorsPerMajor:MaxTicks:")));
        }
    }
}
