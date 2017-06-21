using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCITickCoordinatesTests
    {
        [Test]
        public void TestBindings()
        {
            SCITickCoordinates instance = new SCITickCoordinates();
            Assert.True(instance.RespondsToSelector(new Selector("isEmpty")));
            Assert.False(instance.RespondsToSelector(new Selector("setIsEmpty:")));
        }
    }
}
