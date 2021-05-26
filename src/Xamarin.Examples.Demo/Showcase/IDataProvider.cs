using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Examples.Demo.Showcase
{
    public interface IDataProvider<T>
    {
        IObservable<T> Data { get; }
    }
}
