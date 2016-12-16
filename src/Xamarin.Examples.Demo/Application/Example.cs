
using System;
using System.Linq;
using System.Reflection;
using SciChart.Examples.Demo.Fragments.Base;

namespace SciChart.Examples.Demo.Application
{
    public class Example
    {
        public Type FragmentType { get; }
        public string Title { get; }

        public Example(Type fragmentType)
        {
            FragmentType = fragmentType;

            var attribute = fragmentType.GetCustomAttributes<ExampleDefinition>().Single();

            Title = attribute.Title;
        }
    }
}