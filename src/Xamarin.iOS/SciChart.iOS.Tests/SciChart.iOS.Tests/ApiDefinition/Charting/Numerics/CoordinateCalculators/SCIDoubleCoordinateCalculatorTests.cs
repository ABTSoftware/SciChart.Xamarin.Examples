using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIDoubleCoordinateCalculatorTests
    {
        [Test]
        public void TestBindings()
        {
            SCIDoubleCoordinateCalculator instance = new SCIDoubleCoordinateCalculator();
            Assert.True(instance.RespondsToSelector(new Selector("initWithDimension:Min:Max:Direction:FlipCoordinates:")));
            Assert.True(instance.RespondsToSelector(new Selector("initWithDimension:Min:Max:IsXAxis:IsHorizontal:FlipCoordinates:")));
            Assert.True(instance.RespondsToSelector(new Selector("coordinateConstant")));
            Assert.True(instance.RespondsToSelector(new Selector("setCoordinateConstant:")));
            Assert.True(instance.RespondsToSelector(new Selector("coordinatesOffset")));
            Assert.True(instance.RespondsToSelector(new Selector("setCoordinatesOffset:")));
        }
    }
}
