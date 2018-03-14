using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using scichartshowcase.TestCases.AudioAnalyzer;
using scichartshowcase.Showcases.Medical;

namespace scichartshowcase.ShowcaseListPage
{
    public class ShowcaseListPageViewModel : ViewModelBase
    {
		public ObservableCollection<Showcase> Showcases { get; set; }
		public RelayCommand<Showcase> NavigateToTestCaseCommand { get; set; }

        INavigation navigator;

        public ShowcaseListPageViewModel(INavigation navigator)
        {
            this.navigator = navigator;

            Showcases = new ObservableCollection<Showcase>
            {
                new Showcase
                {
                    Name = "Audio Analyzer",
                    Description = "A brand new way of presenting audio data.",
                    Icon = ImageSource.FromResource(""),
                    ContentPage = typeof(AudioAnalyzer)
                },
				new Showcase
				{
					Name = "Heartbeat ECG",
					Description = "And this is a brand new way of presenting some medical data.",
					Icon = ImageSource.FromResource(""),
					ContentPage = typeof(Medical)
				}
            };

            NavigateToTestCaseCommand = new RelayCommand<Showcase>(NavigateToTestCase);
        }

        void NavigateToTestCase(Showcase selectedItem)
        { 
            navigator.PushAsync((Page)Activator.CreateInstance(selectedItem.ContentPage)); 
        }
    }
}
