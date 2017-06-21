using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCICoordinateCalculatorBaseTests
    {
        [Test]
        public void TestBindings()
        {
            // TODO:
            //[Static]
            //[Export("flip:Coords:WithViewPortDimension:")]

            SCICoordinateCalculatorBase instance = new SCICoordinateCalculatorBase();
            Assert.True(instance.RespondsToSelector(new Selector("setCoordinatesOffset:")));
        }
    }
}
