using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAnnotationBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCIAnnotationBase instance = new SCIAnnotationBase();
            Assert.True(instance.RespondsToSelector(new Selector("xAxisId")));
            Assert.True(instance.RespondsToSelector(new Selector("setXAxisId:")));
            Assert.True(instance.RespondsToSelector(new Selector("yAxisId")));
            Assert.True(instance.RespondsToSelector(new Selector("setYAxisId:")));
            Assert.True(instance.RespondsToSelector(new Selector("coordinateMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setCoordinateMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("isVertical")));
            Assert.False(instance.RespondsToSelector(new Selector("setIsVertical:")));
            Assert.True(instance.RespondsToSelector(new Selector("getBindingArea")));
            Assert.True(instance.RespondsToSelector(new Selector("pointInBindingArea:")));
        }
    }
}
