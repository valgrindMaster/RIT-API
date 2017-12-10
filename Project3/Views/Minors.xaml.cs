using Project3.Views;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class Minors : Page
    {
        private const string API_MINORS = "http://ist.rit.edu/api/minors/";
        static HttpClient client = new HttpClient();
        Wrappers.Minors minors;

        public Minors()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (MinorsList.Items.Count == 0)
            {
                populateMinorsAsync(sender);
            }
        }

        private async void populateMinorsAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_MINORS);
            if (response.IsSuccessStatusCode)
            {
                minors = await response.Content.ReadAsAsync<Wrappers.Minors>();
                StackPanel sp;
                TextBlock nameItem;
                TextBlock titleItem;
                foreach (Wrappers.UgMinors entry in minors.ugMinors)
                {
                    sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;
                    Thickness padding = new Thickness(5);

                    nameItem = new TextBlock();
                    nameItem.Text = entry.name + ": ";
                    nameItem.Padding = padding;

                    titleItem = new TextBlock();
                    titleItem.Text = entry.title;
                    titleItem.Padding = padding;

                    sp.Children.Add(nameItem);
                    sp.Children.Add(titleItem);

                    MinorsList.Items.Add(sp);
                    MinorsList.SelectionChanged += MinorsList_SelectionChangedAsync;
                }
            }
        }

        private void MinorsList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.UgMinors minor = minors.ugMinors.ElementAt(((ListView)sender).SelectedIndex);
            if (minor != null)
            {
                Frame.Navigate(typeof(MinorsDetail), minor);
            }
        }
    }
}
