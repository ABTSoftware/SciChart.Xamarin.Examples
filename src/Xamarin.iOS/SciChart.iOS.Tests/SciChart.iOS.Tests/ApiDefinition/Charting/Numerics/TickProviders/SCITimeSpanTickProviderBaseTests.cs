using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITimeSpanTickProviderBaseTests
    {
        [Test]
        public void TestBindings()
        {
            SCITimeSpanTickProviderBase instance = new SCITimeSpanTickProviderBase();
            Assert.True(instance.RespondsToSelector(new Selector("roundUp:Delta:")));
            Assert.True(instance.RespondsToSelector(new Selector("isAdditionValid:Delta:")));
            Assert.True(instance.RespondsToSelector(new Selector("addDelta:Delta:")));
            Assert.True(instance.RespondsToSelector(new Selector("isDateDivisible:ByDelta:")));
        }
    }
}
