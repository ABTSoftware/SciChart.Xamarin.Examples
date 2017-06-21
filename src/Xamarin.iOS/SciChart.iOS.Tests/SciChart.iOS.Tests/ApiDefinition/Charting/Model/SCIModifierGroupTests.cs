using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;

namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIModifierGroupTests
    {
        [Test]
        public void TestBindings()
        {
            // TODO update methods
            SCIChartModifierCollection instance = new SCIChartModifierCollection();
        	Assert.True(instance.RespondsToSelector(new Selector("initWithChildModifiers:")));
            Assert.True(instance.RespondsToSelector(new Selector("addItem:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeItem:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("itemCount")));
            Assert.True(instance.RespondsToSelector(new Selector("itemByName:")));
        }
    }
}
