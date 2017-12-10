using Project3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3.Views
{
    public sealed partial class News : Page
    {
        private const string API_NEWS = "http://ist.rit.edu/api/news/";
        static HttpClient client = new HttpClient();
        Wrappers.News news;

        public News()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (NewsList.Items.Count == 0)
            {
                populateNewAsync(sender);
            }
        }

        private async void populateNewAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_NEWS);
            if (response.IsSuccessStatusCode)
            {
                news = await response.Content.ReadAsAsync<Wrappers.News>();
                StackPanel sp;
                TextBlock dateItem;
                TextBlock titleItem;
                foreach (Wrappers.Older entry in news.older)
                {
                    string dateCsv = Regex.Replace(entry.date, "[^0-9]+", ",");
                    int[] dateList = stringToIntList(dateCsv.Split(new char[] {','}));
                    DateTime dt = new DateTime(dateList[0], dateList[1], dateList[2], dateList[3], dateList[4], dateList[5]);
                    string date = string.Format("{0:dddd, MMMM d, yyyy}", dt);
                    string title = entry.title;

                    sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;

                    dateItem = new TextBlock();
                    dateItem.Text = date;
                    dateItem.Style = Resources["ListViewItemDate"] as Style;

                    titleItem = new TextBlock();
                    titleItem.Text = title;

                    sp.Children.Add(dateItem);
                    sp.Children.Add(titleItem);

                    NewsList.Items.Add(sp);
                    NewsList.SelectionChanged += NewsList_SelectionChangedAsync;
                }
            }
        }

        private int[] stringToIntList(string[] lst)
        {
            int[] intLst = new int[lst.Length];
            for (int i = 0; i < lst.Length; i++)
            {
                int val = 0;
                Int32.TryParse(lst[i], out val);
                intLst[i] = val;
            }

            return intLst;
        }

        private void NewsList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            TextBlock date = (TextBlock)((StackPanel)((ListView)sender).SelectedItem).Children[0];
            Wrappers.Older older = news.older.ElementAt(((ListView)sender).SelectedIndex);
            older.date = date.Text;
            if (older != null)
            {
                Frame.Navigate(typeof(NewsDetail), older);
            }
        }
    }
}
