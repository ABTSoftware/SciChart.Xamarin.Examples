using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCICursorModifierStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCICursorModifierStyle instance = new SCICursorModifierStyle();
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTextStyle")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTextStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTextStyle")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTextStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTooltipSetup")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTooltipSetup:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTooltipSetup")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTooltipSetup:")));
            Assert.True(instance.RespondsToSelector(new Selector("alignmentMargin")));
            Assert.True(instance.RespondsToSelector(new Selector("setAlignmentMargin:")));
            Assert.True(instance.RespondsToSelector(new Selector("colorMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setColorMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("cursorPen")));
            Assert.True(instance.RespondsToSelector(new Selector("setCursorPen:")));
            Assert.True(instance.RespondsToSelector(new Selector("targetOffsetMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setTargetOffsetMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("targetOffsetValue")));
            Assert.True(instance.RespondsToSelector(new Selector("setTargetOffsetValue:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTooltipColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTooltipColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTooltipBorderColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTooltipBorderColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTooltipBorderWidth")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTooltipBorderWidth:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTooltipCornerRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTooltipCornerRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTooltipColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTooltipColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTooltipBorderColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTooltipBorderColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTooltipBorderWidth")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTooltipBorderWidth:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTooltipCornerRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTooltipCornerRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisHorizontalTooltipOpacity")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisHorizontalTooltipOpacity:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisVerticalTooltipOpacity")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisVerticalTooltipOpacity:")));
            Assert.True(instance.RespondsToSelector(new Selector("numberFormatter")));
            Assert.True(instance.RespondsToSelector(new Selector("setNumberFormatter:")));
            Assert.True(instance.RespondsToSelector(new Selector("dateTimeFormatter")));
            Assert.True(instance.RespondsToSelector(new Selector("setDateTimeFormatter:")));
        }
    }
}
