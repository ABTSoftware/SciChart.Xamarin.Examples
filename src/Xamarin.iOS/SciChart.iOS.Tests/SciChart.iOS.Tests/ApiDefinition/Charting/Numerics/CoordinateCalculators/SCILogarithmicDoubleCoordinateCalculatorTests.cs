using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILogarithmicDoubleCoordinateCalculatorTests
    {
        [Test]
        public void TestBindings()
        {
            SCILogarithmicDoubleCoordinateCalculator instance = new SCILogarithmicDoubleCoordinateCalculator();
            Assert.True(instance.RespondsToSelector(new Selector("initWithDimension:Min:Max:LogBase:Direction:FlipCoordinates:")));
            Assert.True(instance.RespondsToSelector(new Selector("initWithDimension:Min:Max:LogBase:IsXAxis:IsHorizontal:FlipCoordinates:")));
        }
    }
}
