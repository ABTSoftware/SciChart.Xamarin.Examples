using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCINumericTickProviderTests
    {
        [Test]
        public void testBindings()
        {
            SCINumericTickProvider instance = new SCINumericTickProvider();
            Assert.True(instance.RespondsToSelector(new Selector("calculateMajorTicksWithRange:Delta:")));
            Assert.True(instance.RespondsToSelector(new Selector("calculateMinorTicksWithRange:Delta:")));
        }
    }
}
