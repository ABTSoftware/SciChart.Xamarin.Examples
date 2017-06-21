using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIXAxisDragModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCIXAxisDragModifier instance = new SCIXAxisDragModifier();
            Assert.True(instance.RespondsToSelector(new Selector("clipModeX")));
            Assert.True(instance.RespondsToSelector(new Selector("setClipModeX:")));
        }
    }
}
