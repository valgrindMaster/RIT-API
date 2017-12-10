using Project3.Views;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class Degrees : Page
    {
        private const string API_DEGREES = "http://ist.rit.edu/api/degrees/";
        static HttpClient client = new HttpClient();
        Wrappers.Degrees degrees;

        public Degrees()
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
            HttpResponseMessage response = await client.GetAsync(API_DEGREES);
            if (response.IsSuccessStatusCode)
            {
                degrees = await response.Content.ReadAsAsync<Wrappers.Degrees>();

                TextBlock gradItem;
                foreach (Wrappers.Graduate entry in degrees.graduate)
                {
                    gradItem = new TextBlock();
                    gradItem.Padding = new Windows.UI.Xaml.Thickness(10);
                    gradItem.Text = entry.degreeName.ToUpper() + " - " + entry.title;
                    gradItem.TextWrapping = Windows.UI.Xaml.TextWrapping.WrapWholeWords;
                    GraduateList.Items.Add(gradItem);
                    GraduateList.SelectionChanged += GradList_SelectionChangedAsync;
                }

                TextBlock undergradItem;
                foreach (Wrappers.Undergraduate entry in degrees.undergraduate)
                {
                    undergradItem = new TextBlock();
                    undergradItem.Padding = new Windows.UI.Xaml.Thickness(10);
                    undergradItem.Text = entry.degreeName.ToUpper() + " - "  + entry.title;
                    undergradItem.TextWrapping = Windows.UI.Xaml.TextWrapping.WrapWholeWords;
                    UndergraduateList.Items.Add(undergradItem);
                    UndergraduateList.SelectionChanged += UndergradList_SelectionChangedAsync;
                }
            }
        }

        private void GradList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            TextBlock gradBlock = (TextBlock)((ListView)sender).SelectedItem;
            Wrappers.Graduate grad = getGradDegreesDetail(degrees.graduate, gradBlock.Text);
            Frame.Navigate(typeof(DegreesDetail), grad);
        }

        private void UndergradList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            TextBlock undergradBlock = (TextBlock)((ListView)sender).SelectedItem;
            Wrappers.Undergraduate undergrad = getUndergradDegreeDetail(degrees.undergraduate, undergradBlock.Text);
            Frame.Navigate(typeof(DegreesDetail), undergrad);
        }

        private Wrappers.Graduate getGradDegreesDetail(List<Wrappers.Graduate> grad, string title)
        {
            foreach (Wrappers.Graduate g in grad)
            {
                if (title.Contains(g.title))
                {
                    return g;
                }
            }

            return null;
        }

        private Wrappers.Undergraduate getUndergradDegreeDetail(List<Wrappers.Undergraduate> undergrad, string title)
        {
            foreach (Wrappers.Undergraduate u in undergrad)
            {
                if (title.Contains(u.title))
                {
                    return u;
                }
            }

            return null;
        }
    }
}
