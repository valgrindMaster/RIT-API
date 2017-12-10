using Project3.Views;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class Research : Page
    {
        private const string API_RESEARCH = "http://ist.rit.edu/api/research/";
        static HttpClient client = new HttpClient();
        Wrappers.Research research;

        public Research()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ByInterestList.Items.Count == 0 && ByFacultyList.Items.Count == 0)
            {
                populateResearchAsync(sender);
            }
        }

        private async void populateResearchAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_RESEARCH);
            if (response.IsSuccessStatusCode)
            {
                research = await response.Content.ReadAsAsync<Wrappers.Research>();

                TextBlock interestAreaItem;
                foreach (Wrappers.ByInterestArea entry in research.byInterestArea)
                {
                    interestAreaItem = new TextBlock();
                    interestAreaItem.Padding = new Windows.UI.Xaml.Thickness(10);
                    interestAreaItem.Text = entry.areaName;
                    ByInterestList.Items.Add(interestAreaItem);
                    ByInterestList.SelectionChanged += InterestList_SelectionChangedAsync;
                }

                TextBlock facultyItem;
                foreach (Wrappers.ByFaculty entry in research.byFaculty)
                {
                    facultyItem = new TextBlock();
                    facultyItem.Padding = new Windows.UI.Xaml.Thickness(10);
                    facultyItem.Text = entry.facultyName;
                    ByFacultyList.Items.Add(facultyItem);
                    ByFacultyList.SelectionChanged += FacultyList_SelectionChangedAsync;
                }
            }
        }

        private void InterestList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.ByInterestArea area = research.byInterestArea.ElementAt(((ListView)sender).SelectedIndex);
            if (area != null)
            {
                Frame.Navigate(typeof(ResearchDetail), area);
            }
        }

        private void FacultyList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.ByFaculty faculty = research.byFaculty.ElementAt(((ListView)sender).SelectedIndex);
            if (faculty != null)
            {
                Frame.Navigate(typeof(ResearchDetail), faculty);
            }
        }
    }
}
