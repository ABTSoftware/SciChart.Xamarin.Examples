using System;
using Xamarin.Forms;

namespace scichartshowcase
{
    public partial class scichartshowcasePage : ContentPage
    {
        public scichartshowcasePage()
        {
            InitializeComponent();

            LogoImage.Source = ImageSource.FromFile("scichart-logo-ret1.png");
            BannerImage.Source = ImageSource.FromFile("Banner.png");

            SkipButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ShowcaseListPage.ShowcaseListPage());
                Navigation.RemovePage(this);
            };
        }
    }
}