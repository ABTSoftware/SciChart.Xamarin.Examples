using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILegendModifierBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCILegendModifierBase instance = new SCILegendModifierBase();
            Assert.True(instance.RespondsToSelector(new Selector("position")));
            Assert.True(instance.RespondsToSelector(new Selector("setPosition:")));
            Assert.True(instance.RespondsToSelector(new Selector("orientation")));
            Assert.True(instance.RespondsToSelector(new Selector("setOrientation:")));
            Assert.True(instance.RespondsToSelector(new Selector("sourceMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setSourceMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("showCheckBoxes")));
            Assert.True(instance.RespondsToSelector(new Selector("setShowCheckBoxes:")));
            Assert.True(instance.RespondsToSelector(new Selector("showSeriesMarkers")));
            Assert.True(instance.RespondsToSelector(new Selector("setShowSeriesMarkers:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataSource")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataSource:")));
            Assert.True(instance.RespondsToSelector(new Selector("holderLegendView")));
            Assert.False(instance.RespondsToSelector(new Selector("setHolderLegendView:")));
            Assert.True(instance.RespondsToSelector(new Selector("preferredMaxSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setPreferredMaxSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("initWithPosition:andOrientation:")));
            Assert.True(instance.RespondsToSelector(new Selector("layoutPositionOfHolderView")));
            Assert.True(instance.RespondsToSelector(new Selector("generateDataSourceAndSetDataSource")));
        }
    }
}
