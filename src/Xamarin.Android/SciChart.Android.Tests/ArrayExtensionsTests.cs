using NUnit.Framework;
using SciChart.Core.Utility;

namespace SciChart.Android.Tests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void TestCopy()
        {
            var source = new double[,]
            {
                {1, 2, 3, 4, 5},
                {5, 4, 3, 2, 1},
            };

            Assert.That(source.CopyToOneDimArray(), Is.EqualTo(new double[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }));
        }
    }
}
