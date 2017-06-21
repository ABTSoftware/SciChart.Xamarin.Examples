using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIXyyDataSeriesTests
    {
        [Test]
        public void TestBindings()
        {
            SCIXyyDataSeries instance = new SCIXyyDataSeries();
            Assert.True(instance.RespondsToSelector(new Selector("initWithXType:YType:SeriesType:")));
        }
    }
}
