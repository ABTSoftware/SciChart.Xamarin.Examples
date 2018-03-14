using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIMultiSurfaceModifierTests
    {
        [Test]
        public void TestBindings()
        {
            SCIMultiSurfaceModifier instance = new SCIMultiSurfaceModifier();
            Assert.True(instance.RespondsToSelector(new Selector("initWithModifierType:")));
            Assert.True(instance.RespondsToSelector(new Selector("modifierForSurface:")));
            Assert.True(instance.RespondsToSelector(new Selector("disconnectSurface:")));
            Assert.True(instance.RespondsToSelector(new Selector("disconnectSurfaces")));
        }
    }
}
