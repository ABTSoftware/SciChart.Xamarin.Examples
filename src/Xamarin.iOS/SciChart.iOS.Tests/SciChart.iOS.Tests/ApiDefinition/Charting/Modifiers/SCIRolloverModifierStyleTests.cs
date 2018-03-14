using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIRolloverModifierStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCIRolloverModifierStyle instance = new SCIRolloverModifierStyle();
            Assert.True(instance.RespondsToSelector(new Selector("axisTextStyle")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTextStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisTooltipSetup")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTooltipSetup:")));
            Assert.True(instance.RespondsToSelector(new Selector("pointMarker")));
            Assert.True(instance.RespondsToSelector(new Selector("setPointMarker:")));
            Assert.True(instance.RespondsToSelector(new Selector("alignmentMargin")));
            Assert.True(instance.RespondsToSelector(new Selector("setAlignmentMargin:")));
            Assert.True(instance.RespondsToSelector(new Selector("colorMode")));
            Assert.True(instance.RespondsToSelector(new Selector("setColorMode:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisTooltipColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTooltipColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisTooltipBorderColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTooltipBorderColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisTooltipBorderWidth")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTooltipBorderWidth:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisTooltipCornerRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTooltipCornerRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("axisTooltipOpacity")));
            Assert.True(instance.RespondsToSelector(new Selector("setAxisTooltipOpacity:")));
            Assert.True(instance.RespondsToSelector(new Selector("useSeriesColorForMarker")));
            Assert.True(instance.RespondsToSelector(new Selector("setUseSeriesColorForMarker:")));
            Assert.True(instance.RespondsToSelector(new Selector("rolloverPen")));
            Assert.True(instance.RespondsToSelector(new Selector("setRolloverPen:")));
            Assert.True(instance.RespondsToSelector(new Selector("numberFormatter")));
            Assert.True(instance.RespondsToSelector(new Selector("setNumberFormatter:")));
            Assert.True(instance.RespondsToSelector(new Selector("dateTimeFormatter")));
            Assert.True(instance.RespondsToSelector(new Selector("setDateTimeFormatter:")));
        }
    }
}
