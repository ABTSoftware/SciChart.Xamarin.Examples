using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILogarithmicDeltaCalculatorTests
    {
        [Test]
        public void TestBindings()
        {
            // TODO:
            //[Static]
            //[Export("instance")]
            //SCINumericDeltaCalculatorBase Instance { get; }

            SCILogarithmicDeltaCalculator instance = new SCILogarithmicDeltaCalculator();
            Assert.True(instance.RespondsToSelector(new Selector("logarithmicBase")));
            Assert.True(instance.RespondsToSelector(new Selector("setLogarithmicBase:")));
        }
    }
}
