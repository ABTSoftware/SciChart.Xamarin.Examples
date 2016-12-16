using System;

namespace SciChart.Examples.Demo.Fragments.Base
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExampleDefinition : Attribute
    {
        public string Title { get; set; }

        public ExampleDefinition(string title)
        {
            Title = title;
        }
    }
}