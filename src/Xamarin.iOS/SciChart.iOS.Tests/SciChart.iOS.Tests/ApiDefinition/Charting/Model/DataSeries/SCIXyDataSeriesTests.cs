using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIXyDataSeriesTests
    {
        [Test]
        public void TestBindigns()
        {
            SCIXyDataSeries instance = new SCIXyDataSeries();
            Assert.True(instance.RespondsToSelector(new Selector("initWithXType:YType:SeriesType:")));
        }
    }
}
