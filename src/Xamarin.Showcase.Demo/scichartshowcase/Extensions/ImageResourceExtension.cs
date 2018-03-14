using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace scichartshowcase.Extensions
{
    // Used custom image source extension to have an ability to set image in XAML
    // https://developer.xamarin.com/guides/xamarin-forms/user-interface/images/#Embedded_Images
    // NOTE for iOS platform: works on device but not on simulator

    //[ContentProperty("Source")]
    //public class ImageSourceExtension : IMarkupExtension
    //{
    //    public string Source
    //    {
    //        get;
    //        set;
    //    }
    //    public object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        if (Source == null)
    //        {
    //            return null;
    //        }
    //        return ImageSource.FromResource(Source);
    //    }
    //}
}
