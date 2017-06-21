using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILegendModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCILegendModifier instance = new SCILegendModifier();
            Assert.True(instance.RespondsToSelector(new Selector("collectionView")));
            Assert.False(instance.RespondsToSelector(new Selector("setCollectionView:")));
            Assert.True(instance.RespondsToSelector(new Selector("currentRegisteredReuseIdentifier")));
            Assert.False(instance.RespondsToSelector(new Selector("setCurrentRegisteredReuseIdentifier:")));
            Assert.True(instance.RespondsToSelector(new Selector("cellClass")));
            Assert.False(instance.RespondsToSelector(new Selector("setCellClass:")));
            Assert.True(instance.RespondsToSelector(new Selector("styleOfItemCell")));
            Assert.True(instance.RespondsToSelector(new Selector("setSstyleOfItemCell:")));
            Assert.True(instance.RespondsToSelector(new Selector("registerCellClass:withReuseIdentifier:")));
            Assert.True(instance.RespondsToSelector(new Selector("registerCellNib:withReuseIdentifier:")));
        }
    }
}
