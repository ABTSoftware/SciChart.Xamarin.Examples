using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAnnotationGroupTests
    {
        [Test]
        public void TestBindings()
        {
            SCIAnnotationCollection instance = new SCIAnnotationCollection();
            Assert.True(instance.RespondsToSelector(new Selector("initWithChildAnnotations:")));
            Assert.True(instance.RespondsToSelector(new Selector("addItem:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeItem:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("itemCount")));
            Assert.True(instance.RespondsToSelector(new Selector("itemByName:")));
            Assert.True(instance.RespondsToSelector(new Selector("itemAt:")));
        }
    }
}
