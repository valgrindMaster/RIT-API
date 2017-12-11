using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3.Views
{
    public sealed partial class Courses : Page
    {
        private const string API_COURSES = "http://ist.rit.edu/api/courses/";
        static HttpClient client = new HttpClient();
        List<Wrappers.Courses> cContainer;

        public Courses()
        {
            DataContext = this;
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (DegreesList.Items.Count == 0)
            {
                populateMinorsAsync(sender);
            }
        }

        private async void populateMinorsAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_COURSES);
            if (response.IsSuccessStatusCode)
            {
                cContainer = await response.Content.ReadAsAsync<List<Wrappers.Courses>>();
                StackPanel sp;
                TextBlock degreeItem;
                TextBlock semesterItem;
                foreach (Wrappers.Courses entry in cContainer)
                {
                    sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;
                    Thickness padding = new Thickness(5);

                    degreeItem = new TextBlock();
                    degreeItem.Text = entry.degreeName + ": ";
                    degreeItem.Padding = padding;

                    semesterItem = new TextBlock();
                    semesterItem.Text = entry.semester;
                    semesterItem.Padding = padding;

                    sp.Children.Add(degreeItem);
                    sp.Children.Add(semesterItem);

                    DegreesList.Items.Add(sp);
                    DegreesList.SelectionChanged += DegreesList_SelectionChangedAsync;
                }
            }
        }

        private void DegreesList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.Courses courses = cContainer.ElementAt(((ListView)sender).SelectedIndex);
            if (courses != null)
            {
                clearCoursesList();
                foreach (string c in courses.courses)
                {
                    CoursesList.Items.Add(c);
                }
            }
        }

        private void clearCoursesList()
        {
            for (int i = 0; i < CoursesList.Items.Count; i++)
            {
                CoursesList.Items.RemoveAt(i);
            }
        }
    }
}
