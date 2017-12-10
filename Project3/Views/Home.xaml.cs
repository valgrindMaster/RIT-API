using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3.Views
{
    public sealed partial class Home : Page
    {
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
                Quote.Text = "\"" + about.quote + "\"";
                QuoteAuthor.Text = about.quoteAuthor;
            }
        }
    }
}
