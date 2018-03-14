using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIXySeriesDataViewTests
    {
        [Test]
        public void TestBindings()
        {
// TODO: find a way to test it
//[Static]
//[Export("createInstance")]
//SCITooltipDataView CreateInstance { get; }
            SCIXySeriesDataView instance = new SCIXySeriesDataView();
            Assert.True(instance.RespondsToSelector(new Selector("setData:")));
            Assert.True(instance.RespondsToSelector(new Selector("nameLabel")));
            Assert.True(instance.RespondsToSelector(new Selector("setNameLabel:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataLabel")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataLabel:")));
            Assert.True(instance.RespondsToSelector(new Selector("nameHeightConstraint")));
            Assert.True(instance.RespondsToSelector(new Selector("setNameHeightConstraint:")));
            Assert.True(instance.RespondsToSelector(new Selector("nameWidthConstraint")));
            Assert.True(instance.RespondsToSelector(new Selector("setNameWidthConstraint:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataHeightConstraint")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataHeightConstraint:")));
            Assert.True(instance.RespondsToSelector(new Selector("dataWidthConstraint")));
            Assert.True(instance.RespondsToSelector(new Selector("setDataWidthConstraint:")));
        }
    }
}
