using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using scichartshowcase.Showcases.Medical;
using scichartshowcase.TestCases.AudioAnalyzer;
using Xamarin.Forms;

namespace scichartshowcase.ShowcaseListPage
{
    public partial class ShowcaseListPage : ContentPage
    {
        ObservableCollection<Showcase> listViewDataSource = new ObservableCollection<Showcase>();
        public ShowcaseListPage()
        {
            InitializeComponent();
            
            listViewDataSource.Add(new Showcase
            {
                Name = "Audio Analyzer",
                Description = "A brand new way of presenting audio data.",
                ContentPage = typeof(AudioAnalyzer)
            });
            listViewDataSource.Add(new Showcase
            {
                Name = "Heartbeat ECG",
                Description = "And this is a brand new way of presenting some medical data.",
                ContentPage = typeof(Medical)
            }
            );

            ShowcasesListView.ItemTapped += (sender, e) =>
            {
                var viewCell = e.Item as Showcase;
                Navigation.PushAsync((Page)Activator.CreateInstance(viewCell.ContentPage));
            };

            ShowcasesListView.ItemsSource = listViewDataSource;
        }
    }
}
