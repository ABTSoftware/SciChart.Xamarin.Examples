using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITooltipViewTests
    {
        [Test]
        public void TestBindings()
        {
            // TODO: add test
            //[Static]
            //[Export("createInstance")]

            SCITooltipView instance = new SCITooltipView();
            Assert.True(instance.RespondsToSelector(new Selector("dataView")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataView:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataViewWidth")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataViewWidth:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataViewHeight")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataViewHeight:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataViewLeftBorder")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataViewLeftBorder:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataViewTopBorder")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataViewTopBorder:")));
            Assert.True(instance.RespondsToSelector(new Selector("fixedSize")));
            Assert.True(instance.RespondsToSelector(new Selector("setFixedSize:")));
            Assert.True(instance.RespondsToSelector(new Selector("contentPadding")));
            Assert.True(instance.RespondsToSelector(new Selector("setContentPadding:")));
            Assert.True(instance.RespondsToSelector(new Selector("addDataView")));
            Assert.True(instance.RespondsToSelector(new Selector("removeAll")));
        }
    }
}
