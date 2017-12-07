using Project3.Wrappers;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class People : Page
    {
        private const string API_PEOPLE = "http://ist.rit.edu/api/people/";
        static HttpClient client = new HttpClient();

        public People()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            populateEmploymentAsync(sender);
        }

        private async void populateEmploymentAsync(object sender)
        {
            Project3.Wrappers.People people = null;
            HttpResponseMessage response = await client.GetAsync(API_PEOPLE);
            if (response.IsSuccessStatusCode)
            {
                people = await response.Content.ReadAsAsync<Project3.Wrappers.People>();
                H1People.Text = people.title;
                H2People.Text = people.subTitle;
                populateFacultyView(people.faculty);
                //Description.Text = about.description;
                //Quote.NavigateToString();
            }
        }

        private void populateFacultyView(List<Faculty> fac)
        {
            WebView wv;
            foreach (Faculty f in fac)
            {
                wv = new WebView();
                wv.NavigateToString("");
                FacultyList.Items.Add(wv);
            }
        }
    }
}
