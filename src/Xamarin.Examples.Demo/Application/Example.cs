using System;
using System.Linq;
using System.Reflection;
using SciChart.Examples.Demo.Fragments.Base;

namespace SciChart.Examples.Demo.Application
{
    public class Example
    {
        public Type ExampleType { get; }
        public string Title { get; }
        public string Description { get; }

        public Example(Type exampleType)
        {
            ExampleType = exampleType;

            var attribute = exampleType.GetCustomAttributes<ExampleDefinition>().Single();

            Title = attribute.Title;
            Description = attribute.Description;
        }
    }
}