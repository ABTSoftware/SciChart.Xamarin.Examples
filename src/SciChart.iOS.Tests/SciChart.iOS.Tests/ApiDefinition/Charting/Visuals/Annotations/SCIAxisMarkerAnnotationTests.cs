using System;
using NUnit.Framework;
using SciChart.iOS.Charting;
using Foundation;
using ObjCRuntime;
namespace SciChart.iOS.Tests
{
    public class SCIAxisMarkerAnnotationTests
    {
        public SCIAxisMarkerAnnotationTests()
        {
            SCIAxisMarkerAnnotation instance = new SCIAxisMarkerAnnotation();
            Assert.True(instance.RespondsToSelector(new Selector("style")));
            Assert.True(instance.RespondsToSelector(new Selector("setStyle:")));
            Assert.True(instance.RespondsToSelector(new Selector("formattedValue")));
            Assert.True(instance.RespondsToSelector(new Selector("setFormattedValue:")));
        }
    }
}
