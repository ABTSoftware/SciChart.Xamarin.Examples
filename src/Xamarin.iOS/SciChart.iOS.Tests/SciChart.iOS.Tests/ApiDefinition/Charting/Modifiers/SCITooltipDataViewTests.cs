using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITooltipDataViewTests
    {
        [Test]
        public void TestBindings()
        {
            SCITooltipDataView instance = new SCITooltipDataView();
            Assert.True(instance.RespondsToSelector(new Selector("applyHeadLineStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("applyDataLineStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("setColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("getTransformedViewSize:")));
        }
    }
}
