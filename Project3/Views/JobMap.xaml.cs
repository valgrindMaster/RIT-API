using System.Net.Http;
using Windows.UI.Xaml.Controls;

namespace Project3.Views
{
    public sealed partial class JobMap : Page
    {
        private const string API_MAP = "http://ist.rit.edu/api/map/";
        static HttpClient client = new HttpClient();

        public JobMap()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MapView.NavigateToString(string.Format(Constants.MAP_STR, API_MAP));
        }
    }
}
