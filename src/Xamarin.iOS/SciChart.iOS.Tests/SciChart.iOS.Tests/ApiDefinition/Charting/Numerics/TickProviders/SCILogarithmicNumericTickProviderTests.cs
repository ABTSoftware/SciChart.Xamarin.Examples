using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCILogarithmicNumericTickProviderTests
    {
        [Test]
        public void TestBindings()
        {
            SCILogarithmicNumericTickProvider instance = new SCILogarithmicNumericTickProvider();
            Assert.True(instance.RespondsToSelector(new Selector("logarithmicBase")));
            Assert.True(instance.RespondsToSelector(new Selector("setLogarithmicBase:")));
        }
    }
}
