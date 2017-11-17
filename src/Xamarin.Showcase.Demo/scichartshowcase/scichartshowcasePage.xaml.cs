using System;
using Xamarin.Forms;

namespace scichartshowcase
{
    public partial class scichartshowcasePage : ContentPage
    {
        public scichartshowcasePage()
        {
            InitializeComponent();
        }

        async void SkipIntroPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowcaseListPage.ShowcaseListPage());
            Navigation.RemovePage(this);
        }
    }
}