using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIDataSeriesTests
    {
        [Test]
        public void TestBindings()
        {
            SCIDataSeries instance = new SCIDataSeries();
            Assert.True(instance.RespondsToSelector(new Selector("initWithXType:YType:SeriesType:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataDistributionCalculator")));
            Assert.True(instance.RespondsToSelector(new Selector("dataSeriesChanged")));
        }
    }
}
