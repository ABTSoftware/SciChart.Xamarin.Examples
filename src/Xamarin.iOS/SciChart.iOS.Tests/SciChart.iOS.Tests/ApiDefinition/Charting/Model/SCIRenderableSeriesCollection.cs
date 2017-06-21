using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIRenderableSeriesCollectionTests
    {
        [Test]
        public void TestBindings()
        {
            SCIRenderableSeriesCollection instance = new SCIRenderableSeriesCollection();
        	Assert.True(instance.RespondsToSelector(new Selector("count")));
            Assert.True(instance.RespondsToSelector(new Selector("itemAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("add:")));
            Assert.True(instance.RespondsToSelector(new Selector("insert:At:")));
            Assert.True(instance.RespondsToSelector(new Selector("contains:")));
            Assert.True(instance.RespondsToSelector(new Selector("remove:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("clear")));
        }
    }
}
