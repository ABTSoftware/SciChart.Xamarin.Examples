using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITooltipModifierStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCITooltipModifier instance = new SCITooltipModifier();
            Assert.True(instance.RespondsToSelector(new Selector("targetMarker")));
            Assert.True(instance.RespondsToSelector(new Selector("setTargetMarker:")));
            Assert.True(instance.RespondsToSelector(new Selector("alignmentMargin")));
            Assert.True(instance.RespondsToSelector(new Selector("setAlignmentMargin:")));
            Assert.True(instance.RespondsToSelector(new Selector("targetOffsetMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setTargetOffsetMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("targetOffsetValue")));
            Assert.True(instance.RespondsToSelector(new Selector("setTargetOffsetValue:")));
            Assert.True(instance.RespondsToSelector(new Selector("targetCustomOffset")));
            Assert.True(instance.RespondsToSelector(new Selector("setTargetCustomOffset:")));
            Assert.True(instance.RespondsToSelector(new Selector("colorMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setColorMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("numberFormatter")));
            Assert.True(instance.RespondsToSelector(new Selector("setNumberFormatter:")));
            Assert.True(instance.RespondsToSelector(new Selector("dateTimeFormatter")));
            Assert.True(instance.RespondsToSelector(new Selector("setDateTimeFormatter:")));
        }
    }
}
