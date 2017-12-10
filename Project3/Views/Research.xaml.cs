using Project3.Views;
using System.Collections.Generic;
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
            populateResearchAsync(sender);
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
            TextBlock interestAreaBlock = (TextBlock)((ListView)sender).SelectedItem;
            Wrappers.ByInterestArea area = getResearchByInterestDetail(research.byInterestArea, interestAreaBlock.Text);
            Frame.Navigate(typeof(ResearchDetail), area);
        }

        private void FacultyList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            TextBlock facultyBlock = (TextBlock)((ListView)sender).SelectedItem;
            Wrappers.ByFaculty faculty = getResearchByFacultyDetail(research.byFaculty, facultyBlock.Text);
            Frame.Navigate(typeof(ResearchDetail), faculty);
        }

        private Wrappers.ByInterestArea getResearchByInterestDetail(List<Wrappers.ByInterestArea> area, string title)
        {
            foreach (Wrappers.ByInterestArea a in area)
            {
                if (title.Equals(a.areaName))
                {
                    return a;
                }
            }

            return null;
        }

        private Wrappers.ByFaculty getResearchByFacultyDetail(List<Wrappers.ByFaculty> fac, string title)
        {
            foreach (Wrappers.ByFaculty f in fac)
            {
                if (title.Equals(f.facultyName))
                {
                    return f;
                }
            }

            return null;
        }
    }
}
