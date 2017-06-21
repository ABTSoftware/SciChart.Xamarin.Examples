using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAnnotationLabelStyleTests
    {
        [Test]
        public void TestBindings()
        {
            SCIAnnotationLabelStyle instance = new SCIAnnotationLabelStyle();
            Assert.True(instance.RespondsToSelector(new Selector("borderWidth")));
            Assert.True(instance.RespondsToSelector(new Selector("setBorderWidth:")));
            Assert.True(instance.RespondsToSelector(new Selector("cornerRadius")));
            Assert.True(instance.RespondsToSelector(new Selector("setCornerRadius:")));
            Assert.True(instance.RespondsToSelector(new Selector("backgroundOpacity")));
            Assert.True(instance.RespondsToSelector(new Selector("setBackgroundOpacity:")));
            Assert.True(instance.RespondsToSelector(new Selector("contentPadding")));
            Assert.True(instance.RespondsToSelector(new Selector("setContentPadding:")));
            Assert.True(instance.RespondsToSelector(new Selector("alignmentMargin")));
            Assert.True(instance.RespondsToSelector(new Selector("setAlignmentMargin:")));
            Assert.True(instance.RespondsToSelector(new Selector("backgroundColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setBackgroundColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("borderColor")));
            Assert.True(instance.RespondsToSelector(new Selector("setBorderColor:")));
            Assert.True(instance.RespondsToSelector(new Selector("labelSetup")));
            Assert.True(instance.RespondsToSelector(new Selector("setLabelSetup:")));
            Assert.True(instance.RespondsToSelector(new Selector("textStyle")));
            Assert.True(instance.RespondsToSelector(new Selector("setTextStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("labelPlacement")));
            Assert.True(instance.RespondsToSelector(new Selector("setLabelPlacement:")));
        }
    }
}
