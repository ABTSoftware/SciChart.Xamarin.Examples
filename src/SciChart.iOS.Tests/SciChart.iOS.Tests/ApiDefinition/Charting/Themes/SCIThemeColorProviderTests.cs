using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIThemeColorProviderTests
    {
        [Test]
        public void TestBindings()
        {
            SCIThemeColorProvider instance = new SCIThemeColorProvider();
            Assert.True(instance.RespondsToSelector(new Selector("initWithThemeKey:")));
        }
    }
}
