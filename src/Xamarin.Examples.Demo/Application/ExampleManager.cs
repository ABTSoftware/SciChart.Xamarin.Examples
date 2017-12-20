using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SciChart.Examples.Demo.Fragments.Base;

namespace SciChart.Examples.Demo.Application
{
    public class ExampleManager
    {
        private static ExampleManager _exampleManager;

        public static ExampleManager Instance => _exampleManager ?? (_exampleManager = new ExampleManager());

        public List<Example> Examples { get; }

        private ExampleManager()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => Attribute.IsDefined(t, typeof(ExampleDefinition)));

            Examples = types.Select(t => new Example(t)).OrderBy(ex => ex.Title).ToList();
        }

        public Example GetExampleByTitle(string exampleTitle)
        {
            return Examples.FirstOrDefault(x => x.Title == exampleTitle);
        }

        public Example GetExampleByType(Type exampleType)
        {
            return Examples.FirstOrDefault(x => x.ExampleType.Equals(exampleType));
        }
    }
}