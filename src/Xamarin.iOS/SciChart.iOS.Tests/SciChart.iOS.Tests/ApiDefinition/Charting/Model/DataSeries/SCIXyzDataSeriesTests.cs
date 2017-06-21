using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIXyzDataSeriesTests
    {
        [Test]
        public void TestBindings()
        {
            SCIXyzDataSeries instance = new SCIXyzDataSeries();
            Assert.True(instance.RespondsToSelector(new Selector("initWithXType:YType:ZType:")));
        }
    }
}
