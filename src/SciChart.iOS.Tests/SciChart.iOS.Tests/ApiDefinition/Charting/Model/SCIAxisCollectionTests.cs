using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    [TestFixture]
    public class SCIAxisCollectionTests
    {
        [Test]
        public void TestBindings()
        {
            // TODO: no constructor bound, default one returns nil
            SCIAxisCollection instance = new SCIAxisCollection();
            Assert.True(instance.RespondsToSelector(new Selector("count")));
            Assert.True(instance.RespondsToSelector(new Selector("getAxisById:")));
            Assert.True(instance.RespondsToSelector(new Selector("getAxisById:AssertAxisExist:")));
            Assert.True(instance.RespondsToSelector(new Selector("itemAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("add:")));
            Assert.True(instance.RespondsToSelector(new Selector("insert:At:")));
            Assert.True(instance.RespondsToSelector(new Selector("contains:")));
            Assert.True(instance.RespondsToSelector(new Selector("remove:")));
            Assert.True(instance.RespondsToSelector(new Selector("removeAt:")));
            Assert.True(instance.RespondsToSelector(new Selector("clear")));
            Assert.True(instance.RespondsToSelector(new Selector("hasPrimaryAxis")));
            Assert.True(instance.RespondsToSelector(new Selector("defaultAxis")));
        }
    }
}
