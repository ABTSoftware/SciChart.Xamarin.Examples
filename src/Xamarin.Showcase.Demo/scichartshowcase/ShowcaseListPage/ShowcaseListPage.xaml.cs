using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace scichartshowcase.ShowcaseListPage
{
    public partial class ShowcaseListPage : ContentPage
    {
        public ShowcaseListPage()
        {
            InitializeComponent();
            this.BindingContext = new ShowcaseListPageViewModel(Navigation);
        }
    }
}
