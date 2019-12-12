using System;
using System.Linq;
using System.Reflection;

namespace Xamarin.Examples.Demo
{
    public class Example
    {
        public Type ExampleType { get; }
        public string Title { get; }
        public string Description { get; }
        public ExampleIcon? Icon { get; }

        public bool IsExample3D { get; }

        public Example(Type exampleType)
        {
            ExampleType = exampleType;

            var attribute = exampleType.GetCustomAttributes<ExampleDefinitionBase>().Single();

            IsExample3D = attribute.IsExample3D;
            Title = attribute.Title;
            Description = attribute.Description;
            Icon = attribute.Icon;
        }
    }
}