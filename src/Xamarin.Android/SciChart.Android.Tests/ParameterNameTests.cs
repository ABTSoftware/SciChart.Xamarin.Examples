using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using SciChart.Charting.Visuals;
using SciChart.Core.Model;
using SciChart.Data.Model;
using SciChart.Drawing.Common;

namespace SciChart.Android.Tests
{
    [TestFixture]
    public class ParameterNameTests
    {
        [Test]
        public void ShouldHaveCorrectParameterNamesForMethodsInCoreAssembly()
        {
            AssertThatAssemblyHasValidParameterNames(Assembly.GetAssembly(typeof(DoubleValues)));
        }

        [Test]
        public void ShouldHaveCorrectParameterNamesForMethodsInDataAssembly()
        {
            AssertThatAssemblyHasValidParameterNames(Assembly.GetAssembly(typeof(DoubleRange)));
        }
        
        [Test]
        public void ShouldHaveCorrectParameterNamesForMethodsInDrawingAssembly()
        {
            AssertThatAssemblyHasValidParameterNames(Assembly.GetAssembly(typeof(PenStyle)));
        }
        
        [Test]
        public void ShouldHaveCorrectParameterNamesForMethodsInChartingAssembly()
        {
            AssertThatAssemblyHasValidParameterNames(Assembly.GetAssembly(typeof(SciChartSurface)));
        }

        private static void AssertThatAssemblyHasValidParameterNames(Assembly assembly)
        {
            var hasValidNames = true;

            foreach (var type in assembly.GetTypes().Where(type => type.Namespace != null && type.Namespace.Contains("SciChart")))
            {
                foreach (var method in type.GetMethods())
                {
                    var methodParams = method.GetParameters();
                    for (var i = 0; i < methodParams.Length; i++)
                    {
                        var param = methodParams[i];

                        if (param.Name == $"p{i}")
                        {
                            Console.WriteLine($"Method {type.Name}.{method.Name} has invalid parameter name: {param.Name}");
                            hasValidNames = false;
                        }
                    }
                }
            }

            Assert.That(hasValidNames, Is.True);
        }
    }
}
