using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class Home : Page
    {
        private const string API_MAP = "http://ist.rit.edu/api/map/";
        private const string API_ABOUT = "http://ist.rit.edu/api/about/";
        static HttpClient client = new HttpClient();

        public Home()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            populateAboutAsync(sender);
            Map.NavigateToString(String.Format(Project3.Constants.MAP_STR, API_MAP));
        }

        private async void populateAboutAsync(object sender)
        {
            Project3.Wrappers.About about = null;
            HttpResponseMessage response = await client.GetAsync(API_ABOUT);
            if (response.IsSuccessStatusCode)
            {
                about = await response.Content.ReadAsAsync<Project3.Wrappers.About>();
                Title.Text = about.title;
                Description.Text = about.description;
                Quote.NavigateToString(String.Format(Project3.Constants.QUOTATION_STR, about.quote, about.quoteAuthor));
            }
        }
    }
}
