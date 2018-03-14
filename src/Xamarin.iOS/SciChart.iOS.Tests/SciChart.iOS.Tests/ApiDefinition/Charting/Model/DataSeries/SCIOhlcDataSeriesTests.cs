using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIOhlcDataSeriesTests
    {
        [Test]
        public void TestBindings()
        {
            SCIOhlcDataSeries instance = new SCIOhlcDataSeries();
            Assert.True(instance.RespondsToSelector(new Selector("initWithXType:YType:SeriesType:")));
        }
    }
}
