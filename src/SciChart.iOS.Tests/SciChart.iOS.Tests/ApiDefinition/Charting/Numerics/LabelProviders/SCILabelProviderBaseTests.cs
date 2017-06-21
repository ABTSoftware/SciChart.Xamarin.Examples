using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILabelProviderBaseTests
    {
        [Test]
        public void testBindings()
        {
            SCILabelProviderBase instance = new SCILabelProviderBase();
            Assert.True(instance.RespondsToSelector(new Selector("parentAxis")));
            Assert.True(instance.RespondsToSelector(new Selector("setParentAxis:")));
        }
    }
}
