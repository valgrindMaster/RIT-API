using Project3.Views;
using Project3.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Project3
{
    public sealed partial class People : Page
    {
        private const string API_PEOPLE = "http://ist.rit.edu/api/people/";
        static HttpClient client = new HttpClient();
        Wrappers.People people;

        public People()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (FacultyList.Items.Count == 0 && StaffList.Items.Count == 0)
            {
                populatePeopleAsync(sender);
            }
        }

        private async void populatePeopleAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_PEOPLE);
            if (response.IsSuccessStatusCode)
            {
                people = await response.Content.ReadAsAsync<Wrappers.People>();
                H1People.Text = people.title;
                H2People.Text = people.subTitle;
                populateFacultyView(people.faculty);
                populateStaffView(people.staff);
                FacultyList.SelectionChanged += FacultyList_SelectionChanged;
                StaffList.SelectionChanged += StaffList_SelectionChanged;
            }
        }

        private void populateFacultyView(List<Faculty> fac)
        {
            Ellipse el;
            ImageBrush ib;
            TextBlock tb;
            StackPanel sp;
            foreach (Faculty f in fac)
            {
                var src = new Image
                            {
                                Source = new BitmapImage(
                                    new Uri(
                                        f.imagePath))
                            };
                el = new Ellipse();
                el.Width = 100;
                el.Height = 100;
                el.Margin = new Thickness(25);
                ib = new ImageBrush();
                ib.ImageSource = src.Source;
                el.Fill = ib;
                tb = new TextBlock();
                tb.Text = f.name;
                tb.TextAlignment = TextAlignment.Center;
                sp = new StackPanel();
                sp.Children.Add(el);
                sp.Children.Add(tb);
                FacultyList.Items.Add(sp);
            }
        }

        private void populateStaffView(List<Staff> staff)
        {
            Ellipse el;
            ImageBrush ib;
            TextBlock tb;
            StackPanel sp;
            foreach (Staff s in staff)
            {
                var src = new Image
                {
                    Source = new BitmapImage(
                                    new Uri(
                                        s.imagePath))
                };
                el = new Ellipse();
                el.Width = 100;
                el.Height = 100;
                el.Margin = new Thickness(25);
                ib = new ImageBrush();
                ib.ImageSource = src.Source;
                el.Fill = ib;
                tb = new TextBlock();
                tb.Text = s.name;
                tb.TextAlignment = TextAlignment.Center;
                sp = new StackPanel();
                sp.Children.Add(el);
                sp.Children.Add(tb);
                StaffList.Items.Add(sp);
            }
        }

        private void FacultyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.Faculty faculty = people.faculty.ElementAt(((ListView)sender).SelectedIndex);
            if (faculty != null)
            {
                Frame.Navigate(typeof(PeopleDetail), faculty);
            }
        }

        private void StaffList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.Staff staff = people.staff.ElementAt(((ListView)sender).SelectedIndex);
            if (staff != null)
            {
                Frame.Navigate(typeof(PeopleDetail), staff);
            }
        }
    }
}
