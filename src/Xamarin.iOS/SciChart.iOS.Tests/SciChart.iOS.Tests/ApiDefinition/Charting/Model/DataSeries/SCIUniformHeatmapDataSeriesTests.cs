using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIUniformHeatmapDataSeriesTests
    {
        [Test]
        public void TestBindings()
        {
            SCIUniformHeatmapDataSeries instance = new SCIUniformHeatmapDataSeries();
            Assert.True(instance.RespondsToSelector(new Selector("initWithTypeX:Y:Z:SizeX:Y:RangeX:Y:")));
        }
    }
}
